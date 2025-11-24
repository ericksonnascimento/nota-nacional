using Abrasf.Core.Base;
using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.Configuration;
using Abrasf.Core.ConsultarNfseFaixa.Models;
using Abrasf.Core.ConsultarNfseFaixa.Repositories;
using Abrasf.Core.ConsultarNfseFaixa.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models.Response;
using Microsoft.Extensions.Configuration;

namespace Abrasf.Core.ConsultarNfseFaixa.Handlers
{

    public class ConsultarNfseFaixaHandler : BaseHandler, IConsultarNfseFaixaHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IConsultarNfseFaixaValidator _consultarNfseFaixaValidator;
        private readonly IConsultarNfseFaixaRepository _repository;
        private readonly bool _apenasValidar;

        public ConsultarNfseFaixaHandler(ICabecalhoValidator cabecalhoValidator,
            IConsultarNfseFaixaValidator consultarNfseFaixaValidator,
            IConsultarNfseFaixaRepository repository,
            IConfiguration configuration)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _consultarNfseFaixaValidator = consultarNfseFaixaValidator;
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
                    erros = erros.Length == 0 ? "E183" : erros + ",E183"; //A mensagem XML do cabe�alho do arquivo enviado est� fora do padr�o especificado.
                }

                ////Validar corpo
                var bodyValidator = _consultarNfseFaixaValidator.Validate(body);

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
                Abrasf.Core.Models.ConsultarNfseFaixaEnvio consulta;

                try
                {
                    consulta = ParseHelper.ParseXml<Abrasf.Core.Models.ConsultarNfseFaixaEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Find(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    // ConsultarNfseFaixaEnvio não tem Signature no padrão nacional
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

        private Abrasf.Core.Models.ConsultarNfseFaixaResposta BuildResponse(WsNfseConsultarNfseFaixaResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<Abrasf.Core.Models.ConsultarNfseFaixaResposta>(result.XmlResposta);
        }
    }
}