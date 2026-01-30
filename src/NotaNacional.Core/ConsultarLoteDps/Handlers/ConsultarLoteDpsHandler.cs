using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.Configuration;
using NotaNacional.Core.ConsultarLoteDps.Models;
using NotaNacional.Core.ConsultarLoteDps.Repositories;
using NotaNacional.Core.ConsultarLoteDps.Validator;
using NotaNacional.Core.Helpers;
using NotaNacional.Core.Models.Response;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Core.ConsultarLoteDps.Handlers
{

    public class ConsultarLoteDpsHandler : IConsultarLoteDpsHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IConsultarLoteDpsValidator _consultarLoteDpsValidator;
        private readonly IConsultarLoteDpsRepository _repository;
        private readonly bool _apenasValidar;

        public ConsultarLoteDpsHandler(ICabecalhoValidator cabecalhoValidator,
            IConsultarLoteDpsValidator consultarLoteDpsValidator,
            IConsultarLoteDpsRepository repository,
            IConfiguration configuration)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _consultarLoteDpsValidator = consultarLoteDpsValidator;
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
                    erros = erros.Length == 0 ? "E183" : erros + ",E183"; //A mensagem XML do cabeçalho do arquivo enviado está fora do padrão especificado.
                }

                ////Validar corpo
                var bodyValidator = _consultarLoteDpsValidator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Find(string.Empty, cpfCnpjCertificado, erros, ipUsuario);
                    return BuildResponse(result);
                }

                if (_apenasValidar)
                {
                    var result = _repository.Find(string.Empty, cpfCnpjCertificado, string.Empty, ipUsuario);
                    return BuildResponse(result);
                }
                
                var xmlString = ParseHelper.GetXml(body);

                try
                {
                    var result = _repository.Find(xmlString, cpfCnpjCertificado, erros, ipUsuario);
                    return BuildResponse(result);
                }
                catch (Exception)
                {
                    var result = _repository.Find(xmlString, cpfCnpjCertificado, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Find(string.Empty, cpfCnpjCertificado, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }

        private NotaNacional.Core.Models.ConsultarLoteDpsResposta BuildResponse(WsNfseConsultarLoteDpsResult result) 
            => string.IsNullOrEmpty(result.XmlResposta) ? throw new Exception("Error") 
                : ParseHelper.ParseXml<NotaNacional.Core.Models.ConsultarLoteDpsResposta>(result.XmlResposta);
    }
}