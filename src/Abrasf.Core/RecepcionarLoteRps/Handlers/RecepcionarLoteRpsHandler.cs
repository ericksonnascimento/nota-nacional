using Abrasf.Core.Base;
using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models;
using Abrasf.Core.Models.Response;
using Abrasf.Core.RecepcionarLoteRps.Models;
using Abrasf.Core.RecepcionarLoteRps.Repositories;
using Abrasf.Core.RecepcionarLoteRps.Validator;

namespace Abrasf.Core.RecepcionarLoteRps.Handlers
{

    public class RecepcionarLoteRpsHandler : BaseHandler, IRecepcionarLoteRpsHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IRecepcionarLoteRpsValidator _validator;
        private readonly IRecepcionarLoteRpsRepository _repository;

        public RecepcionarLoteRpsHandler(
            ICabecalhoValidator cabecalhoValidator,
            IRecepcionarLoteRpsValidator validator,
            IRecepcionarLoteRpsRepository repository)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _validator = validator;
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

                //////Validar corpo
                var bodyValidator = _validator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Register(string.Empty, string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                EnviarLoteDpsEnvio envio;

                try
                {
                    envio = ParseHelper.ParseXml<EnviarLoteDpsEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Register(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    var signature = envio.Signature ?? envio.LoteDps.ListaDps.FirstOrDefault()?.Signature;
                    var issuer = signature != null ? ValidateCertificate(signature) : "";
                    var personalDocument = signature != null ? ExtractPersonalDocumentFromSignature(signature) : "";
                    var result = _repository.Register(xmlString, personalDocument, erros, ipUsuario, issuer);
                    return BuildResponse(result);
                }
                catch (ValidateException ex)
                {
                    var result = _repository.Register(xmlString, string.Empty, ex.code, ipUsuario); //Arquivo enviado com erro na assinatura.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Register(string.Empty, string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result); 
            }
        }

        private Abrasf.Core.Models.EnviarLoteDpsResposta BuildResponse(WsNfseEnviarLoteRpsResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<Abrasf.Core.Models.EnviarLoteDpsResposta>(result.XmlResposta);
        }
    }
}