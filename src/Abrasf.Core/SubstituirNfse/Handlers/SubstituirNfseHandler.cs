using System.Xml;
using Abrasf.Core.Base;
using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models.Response;
using Abrasf.Core.SubstituirNfse.Models;
using Abrasf.Core.SubstituirNfse.Repositories;
using Abrasf.Core.SubstituirNfse.Validator;

namespace Abrasf.Core.SubstituirNfse.Handlers
{

    public class SubstituirNfseHandler : BaseHandler, ISubstituirNfseHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly ISubstituirNfseValidator _substituirNfseValidator;
        private readonly ISubstituirNfseRepository _repository;

        public SubstituirNfseHandler(ICabecalhoValidator cabecalhoValidator, ISubstituirNfseValidator substituirNfseValidator, ISubstituirNfseRepository repository)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _substituirNfseValidator = substituirNfseValidator;
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
                    erros = erros.Length == 0 ? "E183" : erros + ",E183"; //A mensagem XML do cabeçalho do arquivo enviado está fora do padrão especificado.
                }

                ////Validar corpo
                var bodyValidator = _substituirNfseValidator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Replace(string.Empty, string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                SubstituirNfseEnvio substituir;

                try
                {
                    substituir = ParseHelper.ParseXml<SubstituirNfseEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Replace(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    string issuer = ValidateCertificate(substituir.SubstituicaoNfse.Pedido.Signature);
                    var personalDocument = ExtractPersonalDocumentFromSignature(substituir.SubstituicaoNfse.Pedido.Signature);
                    var result = _repository.Replace(xmlString, personalDocument, erros, ipUsuario ,issuer);
                    return BuildResponse(result);
                }
                catch (ValidateException ex)
                {
                    var result = _repository.Replace(xmlString, string.Empty, ex.code, ipUsuario); //Arquivo enviado com erro na assinatura.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Replace(string.Empty, string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }

        private SubstituirNfseResposta BuildResponse(WsSubstituirNfseResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<SubstituirNfseResposta>(result.XmlResposta);
        }
    }
}