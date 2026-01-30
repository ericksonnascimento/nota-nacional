using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace NotaNacional.Core.Models.Response
{
    [XmlRoot(ElementName = "ValidarXmlResposta", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    [XmlType("ValidarXmlResposta", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
    public class ValidarXmlResposta : BaseResponse
    {
        [XmlIgnore]
        private Collection<TcMensagemRetorno> _listaMensagemRetorno;

        [XmlArray("ListaMensagemRetorno")]
        [XmlArrayItem("MensagemRetorno", Namespace = "http://www.sped.fazenda.gov.br/nfse")]
        public Collection<TcMensagemRetorno> ListaMensagemRetorno
        {
            get
            {
                return _listaMensagemRetorno;
            }
            private set
            {
                _listaMensagemRetorno = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the ListaMensagemRetorno collection is empty.
        /// </summary>
        [XmlIgnore]
        public bool ListaMensagemRetornoSpecified
        {
            get
            {
                return (this.ListaMensagemRetorno.Count != 0);
            }
        }

        public ValidarXmlResposta()
        {
            this._listaMensagemRetorno = new Collection<TcMensagemRetorno>();
        }
    }
}

