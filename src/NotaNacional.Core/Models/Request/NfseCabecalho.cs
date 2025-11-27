using System.Xml.Serialization;

namespace NotaNacional.Core.Models.Request
{

    [XmlType]
    public class NfseCabecalho
    {
        [XmlElement(ElementName = "cabecalho", Namespace = "http://www.abrasf.org.br/nfse.xsd")]
        public Cabecalho Cabecalho { get; set; }
    }
}