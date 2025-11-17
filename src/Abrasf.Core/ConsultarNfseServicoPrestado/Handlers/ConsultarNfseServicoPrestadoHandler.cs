using Abrasf.Core.Base;
using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.ConsultarNfseServicoPrestado.Models;
using Abrasf.Core.ConsultarNfseServicoPrestado.Repositories;
using Abrasf.Core.ConsultarNfseServicoPrestado.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models.Response;

namespace Abrasf.Core.ConsultarNfseServicoPrestado.Handlers
{

    public class ConsultarNfseServicoPrestadoHandler : BaseHandler, IConsultarNfseServicoPrestadoHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IConsultarNfseServicoPrestadoValidator _consultarNfseServicoPrestadoValidator;
        private readonly IConsultarNfseServicoPrestadoRepository _repository;

        public ConsultarNfseServicoPrestadoHandler(ICabecalhoValidator cabecalhoValidator,
            IConsultarNfseServicoPrestadoValidator consultarNfseServicoPrestadoValidator,
            IConsultarNfseServicoPrestadoRepository repository)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _consultarNfseServicoPrestadoValidator = consultarNfseServicoPrestadoValidator;
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
                var bodyValidator = _consultarNfseServicoPrestadoValidator.Validate(body);

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
                ConsultarNfseServicoPrestadoEnvio consulta;

                try
                {
                    consulta = ParseHelper.ParseXml<ConsultarNfseServicoPrestadoEnvio>(xmlString);

                }
                catch (Exception)
                {
                    var result = _repository.Find(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    var personalDocument = ExtractPersonalDocumentFromSignature(consulta.Signature);
                    var result = _repository.Find(xmlString, personalDocument, erros, ipUsuario);
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

        private ConsultarNfseServicoPrestadoResposta BuildResponse(WsNfseConsultarNfseServicoPrestadoResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<ConsultarNfseServicoPrestadoResposta>(result.XmlResposta);
        }
    }
}