using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.ConsultarLoteRps.Models;
using Abrasf.Core.ConsultarLoteRps.Repositories;
using Abrasf.Core.ConsultarLoteRps.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models.Response;

namespace Abrasf.Core.ConsultarLoteRps.Handlers
{

    public class ConsultarLoteRpsHandler : IConsultarLoteRpsHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IConsultarLoteRpsValidator _consultarLoteRpsValidator;
        private readonly IConsultarLoteRpsRepository _repository;

        public ConsultarLoteRpsHandler(ICabecalhoValidator cabecalhoValidator,
            IConsultarLoteRpsValidator consultarLoteRpsValidator,
            IConsultarLoteRpsRepository repository)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _consultarLoteRpsValidator = consultarLoteRpsValidator;
            _repository = repository;
        }

        public BaseResponse Handle(object header, object body, string ipUsuario)
        {
            string erros = string.Empty;

            try
            {
                //Validar cabecalho
                var headValidatorResult = _cabecalhoValidator.Validate(header);

                if (!headValidatorResult.IsValid)
                {
                    erros = erros.Length == 0 ? "E183" : erros + ",E183"; //A mensagem XML do cabe�alho do arquivo enviado est� fora do padr�o especificado.
                }

                ////Validar corpo
                var bodyValidator = _consultarLoteRpsValidator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Find(string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);

                try
                {
                    var result = _repository.Find(xmlString, erros, ipUsuario);
                    return BuildResponse(result);
                }
                catch (Exception)
                {
                    var result = _repository.Find(xmlString, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Find(string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }

        private ConsultarLoteRpsResposta BuildResponse(WsNfseConsultarLoteRpsResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<ConsultarLoteRpsResposta>(result.XmlResposta);
        }
    }
}