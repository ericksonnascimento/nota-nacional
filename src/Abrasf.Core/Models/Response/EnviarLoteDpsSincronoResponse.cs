using System;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Abrasf.Core.Models.Response
{
    [Serializable]
    [XmlType(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [XmlRoot(ElementName = "EnviarLoteDpsSincronoResposta", Namespace = "http://www.sped.fazenda.gov.br/nfse", IsNullable = false)]
    [MessageContract(WrapperName = "EnviarLoteDpsSincronoResposta")]
    public class EnviarLoteDpsSincronoResposta : BaseResponse
    {
        [XmlElement(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public string NumeroLote { get; set; }

        [XmlElement(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public DateTime? DataRecebimento { get; set; }

        [XmlElement(Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public string Protocolo { get; set; }

        [XmlElement("ListaNfse", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        [XmlElement("ListaMensagemRetorno", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        [XmlElement("ListaMensagemRetornoLote", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public object Item { get; set; }
    }
}

