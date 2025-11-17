using System.Xml.Serialization;

namespace Abrasf.Core.Models.Request
{

    [XmlType]
    public class Cabecalho
    {
        [XmlAttribute(AttributeName = "versao")]
        public string? Versao { get; set; }
        [XmlElement(ElementName = "versaoDados")]
        public string VersaoDados { get; set; }
    }
}