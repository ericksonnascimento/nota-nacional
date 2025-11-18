using System.ServiceModel;
using System.Xml.Serialization;

namespace Abrasf.Core.Models.Response
{

    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [MessageContract(WrapperName = "ConsultarLoteDpsResposta")]
    public class ConsultarLoteDpsResponse : BaseResponse
    {
        [XmlElement(Namespace = "http://www.sped.fazenda.gov.br/nfse")] 
        public string ConsultarLoteDpsResposta { get; set; }
    }
}

