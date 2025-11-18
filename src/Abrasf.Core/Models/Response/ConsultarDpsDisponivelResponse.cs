using System.ServiceModel;
using System.Xml.Serialization;

namespace Abrasf.Core.Models.Response
{
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [XmlRoot(ElementName = "ConsultarDpsDisponivelResposta", Namespace = "http://www.sped.fazenda.gov.br/nfse", IsNullable = false)]
    [MessageContract(WrapperName = "ConsultarDpsDisponivelResposta")]
    public class ConsultarDpsDisponivelResposta : BaseResponse
    {
        [XmlElement("ListaDpsDisponivel", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        [XmlElement("ListaMensagemRetorno", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public object Item { get; set; }
    }
}

