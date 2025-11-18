using System.ServiceModel;
using System.Xml.Serialization;

namespace Abrasf.Core.Models.Response
{
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [XmlRoot(ElementName = "ConsultarNfseDpsResposta", Namespace = "http://www.sped.fazenda.gov.br/nfse", IsNullable = false)]
    [MessageContract(WrapperName = "ConsultarNfseDpsResposta")]
    public class ConsultarNfseDpsResposta : BaseResponse
    {
        [XmlElement("CompNfse", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        [XmlElement("ListaMensagemRetorno", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public object Item { get; set; }
    }
}

