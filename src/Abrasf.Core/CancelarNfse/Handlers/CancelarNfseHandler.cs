using Abrasf.Core.Base;
using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.CancelarNfse.Models;
using Abrasf.Core.CancelarNfse.Repositories;
using Abrasf.Core.CancelarNfse.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models.Response;

namespace Abrasf.Core.CancelarNfse.Handlers
{

    public class CancelarNfseHandler : BaseHandler, ICancelarNfseHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly ICancelarNfseValidator _cancelarNfseValidator;
        private readonly ICancelarNfseRepository _repository;

        public CancelarNfseHandler(ICabecalhoValidator cabecalhoValidator,
            ICancelarNfseValidator cancelarNfseValidator,
            ICancelarNfseRepository repository)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _cancelarNfseValidator = cancelarNfseValidator;
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
                var bodyValidator = _cancelarNfseValidator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Cancel(string.Empty, string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                CancelarNfseEnvio cancelar;

                try
                {
                    cancelar = ParseHelper.ParseXml<CancelarNfseEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Cancel(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    string issuer = ValidateCertificate(cancelar.Pedido.Signature);
                    var personalDocument = ExtractPersonalDocumentFromSignature(cancelar.Pedido.Signature);
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
                var result = _repository.Cancel(string.Empty, string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }

        private CancelarNfseResposta BuildResponse(WsCancelarNfseResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<CancelarNfseResposta>(result.XmlResposta);
        }
    }
}