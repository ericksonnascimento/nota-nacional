using NotaNacional.Core.Base;
using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.Configuration;
using NotaNacional.Core.Helpers;
using NotaNacional.Core.Models;
using NotaNacional.Core.Models.Response;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Models;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Repositories;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Validator;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Core.RecepcionarLoteRpsSincrono.Handlers
{

    public class RecepcionarLoteRpsSincronoHandler : BaseHandler, IRecepcionarLoteRpsSincronoHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IRecepcionarLoteRpsSincronoValidator _recepcionarLoteRpsSincronoValidator;
        private readonly IRecepcionarLoteRpsSincronoRepository _repository;
        private readonly bool _apenasValidar;

        public RecepcionarLoteRpsSincronoHandler(ICabecalhoValidator cabecalhoValidator,
            IRecepcionarLoteRpsSincronoValidator recepcionarLoteRpsSincronoValidator,
            IRecepcionarLoteRpsSincronoRepository repository,
            IConfiguration configuration)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _recepcionarLoteRpsSincronoValidator = recepcionarLoteRpsSincronoValidator;
            _repository = repository;
            var handlerConfig = configuration.GetSection("HandlerConfiguration").Get<HandlerConfiguration>() ?? new HandlerConfiguration();
            _apenasValidar = handlerConfig.ApenasValidar;
        }

        public BaseResponse Handle(object header, object body, string ipUsuario, string cpfCnpjCertificado = "")
        {
            var erros = string.Empty;

            try
            {
                //Validar cabecalho
                var headValidatorResult = _cabecalhoValidator.Validate(header);

                if (!headValidatorResult.IsValid)
                {
                    erros = erros.Length == 0 ? "E183" : erros + ",E183"; //A mensagem XML do cabe�alho do arquivo enviado est� fora do padr�o especificado.
                }

                ////Validar corpo
                var bodyValidator = _recepcionarLoteRpsSincronoValidator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Process(string.Empty, string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                if (_apenasValidar)
                {
                    var result = _repository.Process(string.Empty, string.Empty, string.Empty, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                EnviarLoteDpsSincronoEnvio envio;

                try
                {
                    envio = ParseHelper.ParseXml<EnviarLoteDpsSincronoEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Process(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    var signature = envio.Signature ?? envio.LoteDps.ListaDps.FirstOrDefault()?.Signature;
                    var issuer = signature != null ? ValidateCertificate(signature) : "";
                    var personalDocument = signature != null ? ExtractPersonalDocumentFromSignature(signature) : "";
                    var result = _repository.Process(xmlString, personalDocument, erros, ipUsuario, issuer);
                    return BuildResponse(result);
                }
                catch (ValidateException ex)
                {
                    var result = _repository.Process(xmlString, string.Empty, ex.code, ipUsuario); //Arquivo enviado com erro na assinatura.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Process(string.Empty, string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }

        private NotaNacional.Core.Models.EnviarLoteDpsSincronoResposta BuildResponse(WsNfseEnviarLoteRpsSincronoResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<NotaNacional.Core.Models.EnviarLoteDpsSincronoResposta>(result.XmlResposta);
        }
    }
}