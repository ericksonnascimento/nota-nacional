using System.ServiceModel;
using System.Xml.Serialization;

namespace Abrasf.Core.Models.Response
{

    [XmlRoot(ElementName = "EnviarLoteDpsResposta", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [MessageContract(WrapperName = "EnviarLoteDpsResposta")]
    public class EnviarLoteDpsResponse : BaseResponse
    {
        [XmlElement(Namespace = "http://www.sped.fazenda.gov.br/nfse")] 
        public string NumeroLote { get; set; }
        
        [XmlElement(Namespace = "http://www.sped.fazenda.gov.br/nfse")] 
        public string DataRecebimento { get; set; }
        
        [XmlElement(Namespace = "http://www.sped.fazenda.gov.br/nfse")] 
        public string Protocolo { get; set; }
    }
}

