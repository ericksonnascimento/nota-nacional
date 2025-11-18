using Abrasf.Core.Base;
using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.GerarNfse.Models;
using Abrasf.Core.GerarNfse.Repositories;
using Abrasf.Core.GerarNfse.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models.Response;

namespace Abrasf.Core.GerarNfse.Handlers
{

    public class GerarNfseHandler : BaseHandler, IGerarNfseHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IGerarNfseValidator _gerarNfseValidator;
        private readonly IGerarNfseRepository _repository;

        public GerarNfseHandler(ICabecalhoValidator cabecalhoValidator,
            IGerarNfseValidator gerarNfseValidator,
            IGerarNfseRepository repository)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _gerarNfseValidator = gerarNfseValidator;
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
                var bodyValidator = _gerarNfseValidator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Generate(string.Empty, string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                Abrasf.Core.Models.GerarNfseEnvio consulta;

                try
                {
                    consulta = ParseHelper.ParseXml<Abrasf.Core.Models.GerarNfseEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Generate(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    var signature = consulta.Dps?.Signature;
                    var issuer = signature != null ? ValidateCertificate(signature) : "";
                    var personalDocument = signature != null ? ExtractPersonalDocumentFromSignature(signature) : "";
                    var result = _repository.Generate(xmlString, personalDocument, erros, ipUsuario, issuer);
                    return BuildResponse(result);
                }
                catch (ValidateException ex)
                {
                    var result = _repository.Generate(xmlString, string.Empty, ex.code, ipUsuario); //Arquivo enviado com erro na assinatura.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Generate(string.Empty, string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }

        private Abrasf.Core.Models.GerarNfseResposta BuildResponse(WsNfseGerarNfseResult result)
        {
            return string.IsNullOrEmpty(result.XmlResposta) 
                ? throw new Exception("Error") : 
                ParseHelper.ParseXml<Abrasf.Core.Models.GerarNfseResposta>(result.XmlResposta);
        }
    }
}