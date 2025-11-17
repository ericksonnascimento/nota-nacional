namespace Abrasf.Core.Helpers
{
    public class UrlNfse
    {
        const string visualize = "0";
        const string cleanCache = "1";
        const string expire = "31/12/9999 23:59:59";

        readonly string? url;
        readonly string serie;
        readonly string sequence;
        readonly string cae;
        readonly string type;
        readonly string chaveAutenticidade;

        public UrlNfse(string[] input, string? url)
        {
           this.url = url;

            cae = input[0];
            serie = input[1];
            type = input[2];
            sequence = input[3];
            chaveAutenticidade = input[4];
        }

        public string GetUrlNF()
        {
            Crypto transform = new();

            return url + "NotaDigital/Nota_Digital_204.aspx?" + transform.EncryptNF(QueryStringNF());
        }

        public string GetUrlAutenticidade()
        {
            Crypto transform = new();

            return url + "NotaDigital/VerificaAutenticidadeQRCode.aspx?" + transform.EncryptAutenticidade(QueryStringAutenticidade());
        }
        
        private string QueryStringNF()
        {
            string url = "";

            url += "VISUALIZACAO=" + visualize;
            url += "&SERIE=" + serie;
            url += "&NUMERO_SEQ=" + sequence;
            url += "&CAE=" + cae;
            url += "&TIPO_CONTRIBUINTE=" + type;
            url += "&LIMPAR_CACHE=" + cleanCache;
            url += "&__MarcaTempo__=" + expire;

            return url;
        }

        private string QueryStringAutenticidade()
        {
            string url = "";

            url += "Cae=" + cae;
            url += "&NumeroSeq=" + sequence;
            url += "&CodDocumento=" + serie;
            url += "&ChaveAutenticidade=" + chaveAutenticidade;

            return url;
        }
    }
}
