using System.Xml.Serialization;

namespace NotaNacional.Core.Models.Request
{

    [XmlType]
    public class CancelarNfseRequest
    {
        public PedidoCancelamento Pedido { get; set; }
    }

    public class PedidoCancelamento
    {
        public InfPedidoCancelamento InfPedidoCancelamento { get; set; }
    }

    public class InfPedidoCancelamento
    {
        public IdentificacaoNfse Type { get; set; }
    }

    public class IdentificacaoNfse
    {
        public int Type { get; set; }
    }
}