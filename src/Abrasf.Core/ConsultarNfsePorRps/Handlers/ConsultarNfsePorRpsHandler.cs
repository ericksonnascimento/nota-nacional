using Abrasf.Core.Base;
using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.ConsultarNfsePorRps.Models;
using Abrasf.Core.ConsultarNfsePorRps.Repositories;
using Abrasf.Core.ConsultarNfsePorRps.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models;
using Abrasf.Core.Models.Response;

namespace Abrasf.Core.ConsultarNfsePorRps.Handlers
{

    public class ConsultarNfsePorRpsHandler : BaseHandler, IConsultarNfsePorRpsHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IConsultarNfsePorRpsValidator _consultarNfsePorRpsValidator;
        private readonly IConsultarNfsePorRpsRepository _repository;

        public ConsultarNfsePorRpsHandler(ICabecalhoValidator cabecalhoValidator,
            IConsultarNfsePorRpsValidator consultarNfsePorRpsValidator,
            IConsultarNfsePorRpsRepository repository)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _consultarNfsePorRpsValidator = consultarNfsePorRpsValidator;
            _repository = repository;
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

        private Abrasf.Core.Models.ConsultarNfseDpsResposta BuildResponse(WsNfseConsultarNfsePorRpsResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<Abrasf.Core.Models.ConsultarNfseDpsResposta>(result.XmlResposta);
        }


    }
}