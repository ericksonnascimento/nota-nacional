using NotaNacional.Core.Base;
using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.CancelarNfse.Models;
using NotaNacional.Core.CancelarNfse.Repositories;
using NotaNacional.Core.CancelarNfse.Validator;
using NotaNacional.Core.Configuration;
using NotaNacional.Core.Helpers;
using NotaNacional.Core.Models.Response;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Core.CancelarNfse.Handlers
{

    public class CancelarNfseHandler : BaseHandler, ICancelarNfseHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly ICancelarNfseValidator _cancelarNfseValidator;
        private readonly ICancelarNfseRepository _repository;
        private readonly bool _apenasValidar;

        public CancelarNfseHandler(ICabecalhoValidator cabecalhoValidator,
            ICancelarNfseValidator cancelarNfseValidator,
            ICancelarNfseRepository repository,
            IConfiguration configuration)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _cancelarNfseValidator = cancelarNfseValidator;
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
                var bodyValidator = _cancelarNfseValidator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Cancel(Util.XmlVazio(OperacaoNfse.CancelarNfse), string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                if (_apenasValidar)
                {
                    var result = _repository.Cancel(Util.XmlVazio(OperacaoNfse.CancelarNfse), string.Empty, string.Empty, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                NotaNacional.Core.Models.CancelarNfseEnvio cancelar;

                try
                {
                    cancelar = ParseHelper.ParseXml<NotaNacional.Core.Models.CancelarNfseEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Cancel(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    var signature = cancelar.PedRegEvento?.Signature;
                    var issuer = signature != null ? ValidateCertificate(signature) : "";
                    var personalDocument = signature != null ? ExtractPersonalDocumentFromSignature(signature) : "";
                    var result = _repository.Cancel(xmlString, personalDocument, erros, ipUsuario, issuer);
                    return BuildResponse(result);
                }
                catch (ValidateException ex)
                {
                    var result = _repository.Cancel(xmlString, string.Empty, ex.code, ipUsuario); //Arquivo enviado com erro na assinatura.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Cancel(Util.XmlVazio(OperacaoNfse.CancelarNfse), string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }

        private NotaNacional.Core.Models.CancelarNfseResposta BuildResponse(WsCancelarNfseResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<NotaNacional.Core.Models.CancelarNfseResposta>(result.XmlResposta);
        }
    }
}