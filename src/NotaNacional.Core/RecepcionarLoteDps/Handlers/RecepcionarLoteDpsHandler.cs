using NotaNacional.Core.Base;
using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.Configuration;
using NotaNacional.Core.Helpers;
using NotaNacional.Core.Models;
using NotaNacional.Core.Models.Response;
using NotaNacional.Core.RecepcionarLoteDps.Models;
using NotaNacional.Core.RecepcionarLoteDps.Repositories;
using NotaNacional.Core.RecepcionarLoteDps.Validator;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Core.RecepcionarLoteDps.Handlers
{

    public class RecepcionarLoteDpsHandler : BaseHandler, IRecepcionarLoteDpsHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IRecepcionarLoteDpsValidator _validator;
        private readonly IRecepcionarLoteDpsRepository _repository;
        private readonly bool _apenasValidar;

        public RecepcionarLoteDpsHandler(
            ICabecalhoValidator cabecalhoValidator,
            IRecepcionarLoteDpsValidator validator,
            IRecepcionarLoteDpsRepository repository,
            IConfiguration configuration)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _validator = validator;
            _repository = repository;
            var handlerConfig = configuration.GetSection("HandlerConfiguration").Get<HandlerConfiguration>() ?? new HandlerConfiguration();
            _apenasValidar = handlerConfig.ApenasValidar;
        }

        public BaseResponse Handle(object header, object body, string ipUsuario)
        {
            var erros = string.Empty;

            try
            {
                //Validar cabecalho
                var headValidatorResult = _cabecalhoValidator.Validate(header);

                if (!headValidatorResult.IsValid)
                {
                    erros = erros.Length == 0 ? "E183" : erros + ",E183"; //A mensagem XML do cabeçalho do arquivo enviado está fora do padrão especificado.
                }

                //////Validar corpo
                var bodyValidator = _validator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Register(string.Empty, string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                if (_apenasValidar)
                {
                    var result = _repository.Register(string.Empty, string.Empty, string.Empty, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                EnviarLoteDpsEnvio envio;

                try
                {
                    envio = ParseHelper.ParseXml<EnviarLoteDpsEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Register(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    var signature = envio.Signature ?? envio.LoteDps.ListaDps.FirstOrDefault()?.Signature;
                    var issuer = signature != null ? ValidateCertificate(signature) : "";
                    var personalDocument = signature != null ? ExtractPersonalDocumentFromSignature(signature) : "";
                    var result = _repository.Register(xmlString, personalDocument, erros, ipUsuario, issuer);
                    return BuildResponse(result);
                }
                catch (ValidateException ex)
                {
                    var result = _repository.Register(xmlString, string.Empty, ex.code, ipUsuario); //Arquivo enviado com erro na assinatura.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Register(string.Empty, string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result); 
            }
        }

        private NotaNacional.Core.Models.EnviarLoteDpsResposta BuildResponse(WsNfseEnviarLoteDpsResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<NotaNacional.Core.Models.EnviarLoteDpsResposta>(result.XmlResposta);
        }
    }
}