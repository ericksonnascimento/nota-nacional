using System.Data.SqlTypes;
using System.Dynamic;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using Abrasf.Core.Base;
using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.Helpers;
using Abrasf.Core.Models.Response;
using Abrasf.Core.RecepcionarLoteRps.Models;
using Abrasf.Core.RecepcionarLoteRps.Repositories;
using Abrasf.Core.RecepcionarLoteRps.Validator;
using Newtonsoft.Json;

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
            string erros = string.Empty;

            try
            {
                //Validar cabecalho
                var headValidatorResult = _cabecalhoValidator.Validate(header);

                if (!headValidatorResult.IsValid)
                {
                    erros = erros.Length == 0 ? "E183" : erros + ",E183"; //A mensagem XML do cabeçalho do arquivo enviado está fora do padrão especificado.
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
                EnviarLoteRpsEnvio envio;

                try
                {
                    envio = ParseHelper.ParseXml<EnviarLoteRpsEnvio>(xmlString);
                }
                catch (Exception)
                {
                    var result = _repository.Register(xmlString, string.Empty, "E160", ipUsuario); //Arquivo em desacordo com o XML Schema.
                    return BuildResponse(result);
                }

                try
                {
                    DuplicateIdValidation(xmlString);
                    string issuer = ValidateCertificate(envio.Signature ?? envio.LoteRps.ListaRps[0].Signature);
                    var personalDocument = ExtractPersonalDocumentFromSignature(envio.Signature ?? envio.LoteRps.ListaRps[0].Signature);
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

        private EnviarLoteRpsResponse BuildResponse(WsNfseEnviarLoteRpsResult result)
        {
            if (string.IsNullOrEmpty(result.XmlResposta))
            {
                throw new Exception("Error");
            }

            var byteArray = Encoding.UTF8.GetBytes(result.XmlResposta);
            var stream = new MemoryStream(byteArray);
            var xDoc = XDocument.Load(stream);
            var jsonText = JsonConvert.SerializeXNode(xDoc);
            dynamic dyn = JsonConvert.DeserializeObject<ExpandoObject>(jsonText) ?? throw new Exception("Invalid object");


            return new EnviarLoteRpsResponse
            {
                NumeroLote = dyn.EnviarLoteRpsResposta.NumeroLote.ToString(),
                DataRecebimento = dyn.EnviarLoteRpsResposta.DataRecebimento.ToString("yyyy-MM-ddThh:mm:ss"),
                Protocolo = dyn.EnviarLoteRpsResposta.Protocolo
            };
        }
    }
}