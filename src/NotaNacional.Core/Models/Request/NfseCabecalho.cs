using System.Xml.Serialization;

namespace NotaNacional.Core.Models.Request
{

    [XmlType]
    public class NfseCabecalho
    {
        [XmlElement(ElementName = "cabecalho", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public Cabecalho Cabecalho { get; set; }
    }
}