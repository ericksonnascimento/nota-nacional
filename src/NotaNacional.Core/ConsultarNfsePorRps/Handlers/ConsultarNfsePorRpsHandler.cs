using NotaNacional.Core.Base;
using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.Configuration;
using NotaNacional.Core.ConsultarNfsePorRps.Models;
using NotaNacional.Core.ConsultarNfsePorRps.Repositories;
using NotaNacional.Core.ConsultarNfsePorRps.Validator;
using NotaNacional.Core.Helpers;
using NotaNacional.Core.Models;
using NotaNacional.Core.Models.Response;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Core.ConsultarNfsePorRps.Handlers
{

    public class ConsultarNfsePorRpsHandler : BaseHandler, IConsultarNfsePorRpsHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IConsultarNfsePorRpsValidator _consultarNfsePorRpsValidator;
        private readonly IConsultarNfsePorRpsRepository _repository;
        private readonly bool _apenasValidar;

        public ConsultarNfsePorRpsHandler(ICabecalhoValidator cabecalhoValidator,
            IConsultarNfsePorRpsValidator consultarNfsePorRpsValidator,
            IConsultarNfsePorRpsRepository repository,
            IConfiguration configuration)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _consultarNfsePorRpsValidator = consultarNfsePorRpsValidator;
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
                var bodyValidator = _consultarNfsePorRpsValidator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Find(string.Empty, string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                if (_apenasValidar)
                {
                    var result = _repository.Find(string.Empty, string.Empty, string.Empty, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                ConsultarNfseDpsEnvio consulta;

                try
                {
                    consulta = ParseHelper.ParseXml<ConsultarNfseDpsEnvio>(xmlString);

                }
                catch (Exception)
                {
                    var result = _repository.Find(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    // ConsultarNfseDpsEnvio não tem Signature no padrão nacional
                    var result = _repository.Find(xmlString, string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }
                catch (ValidateException ex)
                {
                    var result = _repository.Find(xmlString, string.Empty, ex.code, ipUsuario); //Arquivo enviado com erro na assinatura.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Find(string.Empty, string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }

        private NotaNacional.Core.Models.ConsultarNfseDpsResposta BuildResponse(WsNfseConsultarNfsePorRpsResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<NotaNacional.Core.Models.ConsultarNfseDpsResposta>(result.XmlResposta);
        }


    }
}