namespace NotaNacional.Core.Helpers
{
    public class UrlNfse(string[] input, string? url)
    {
        const string visualize = "0";
        const string cleanCache = "1";
        const string expire = "31/12/9999 23:59:59";

        readonly string serie = input[1];
        readonly string sequence = input[3];
        readonly string cae = input[0];
        readonly string type = input[2];
        readonly string chaveAutenticidade = input[4];

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
            var url = "";

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
            var url = "";

            url += "Cae=" + cae;
            url += "&NumeroSeq=" + sequence;
            url += "&CodDocumento=" + serie;
            url += "&ChaveAutenticidade=" + chaveAutenticidade;

            return url;
        }
    }
}
