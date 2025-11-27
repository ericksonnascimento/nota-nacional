using System.ServiceModel;
using System.Xml.Serialization;

namespace NotaNacional.Core.Models.Response
{

    [XmlRoot(ElementName = "EnviarLoteRpsResposta")]
    [XmlType]
    [MessageContract(WrapperName = "EnviarLoteRpsResposta")]
    public class EnviarLoteRpsResponse : BaseResponse
    {
        [XmlElement] public string NumeroLote { get; set; }
        [XmlElement] public string DataRecebimento { get; set; }
        [XmlElement] public string Protocolo { get; set; }
    }
}