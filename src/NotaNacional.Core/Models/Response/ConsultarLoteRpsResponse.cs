using System.ServiceModel;
using System.Xml.Serialization;

namespace NotaNacional.Core.Models.Response
{

    [XmlType]
    [MessageContract(WrapperName = "ConsultarLoteRpsResposta")]
    public class ConsultarLoteRpsResponse : BaseResponse
    {
        [XmlElement] public string ConsultarLoteRpsResposta { get; set; }
    }
}