using Abrasf.Core.Base;
using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models;
using Abrasf.Core.Models.Response;
using Abrasf.Core.RecepcionarLoteRpsSincrono.Models;
using Abrasf.Core.RecepcionarLoteRpsSincrono.Repositories;
using Abrasf.Core.RecepcionarLoteRpsSincrono.Validator;

namespace Abrasf.Core.RecepcionarLoteRpsSincrono.Handlers
{

    public class RecepcionarLoteRpsSincronoHandler : BaseHandler, IRecepcionarLoteRpsSincronoHandler
    {
        private readonly ICabecalhoValidator _cabecalhoValidator;
        private readonly IRecepcionarLoteRpsSincronoValidator _recepcionarLoteRpsSincronoValidator;
        private readonly IRecepcionarLoteRpsSincronoRepository _repository;

        public RecepcionarLoteRpsSincronoHandler(ICabecalhoValidator cabecalhoValidator,
            IRecepcionarLoteRpsSincronoValidator recepcionarLoteRpsSincronoValidator,
            IRecepcionarLoteRpsSincronoRepository repository)
        {
            _cabecalhoValidator = cabecalhoValidator;
            _recepcionarLoteRpsSincronoValidator = recepcionarLoteRpsSincronoValidator;
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
                var bodyValidator = _recepcionarLoteRpsSincronoValidator.Validate(body);

                if (!bodyValidator.IsValid)
                {
                    erros = erros.Length == 0 ? "E160" : erros + ",E160"; //Arquivo em desacordo com o XML Schema.
                }

                if (erros.Length != 0)
                {
                    var result = _repository.Process(string.Empty, string.Empty, erros, ipUsuario);
                    return BuildResponse(result);
                }

                var xmlString = ParseHelper.GetXml(body);
                EnviarLoteDpsSincronoEnvio envio;

                try
                {
                    envio = ParseHelper.ParseXml<EnviarLoteDpsSincronoEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Process(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    string issuer = ValidateCertificate(envio.Signature ?? envio.LoteDps.ListaDps[0].Signature);
                    var personalDocument = ExtractPersonalDocumentFromSignature(envio.Signature ?? envio.LoteDps.ListaDps[0].Signature);
                    var result = _repository.Process(xmlString, personalDocument, erros, ipUsuario, issuer);
                    return BuildResponse(result);
                }
                catch (ValidateException ex)
                {
                    var result = _repository.Process(xmlString, string.Empty, ex.code, ipUsuario); //Arquivo enviado com erro na assinatura.
                    return BuildResponse(result);
                }
            }
            catch (Exception)
            {
                var result = _repository.Process(string.Empty, string.Empty, "E232", ipUsuario); //Ocorreu um erro no processamento do arquivo.
                return BuildResponse(result);
            }
        }

        private EnviarLoteDpsSincronoResposta BuildResponse(WsNfseEnviarLoteRpsSincronoResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            return ParseHelper.ParseXml<EnviarLoteDpsSincronoResposta>(result.XmlResposta);
        }
    }
}