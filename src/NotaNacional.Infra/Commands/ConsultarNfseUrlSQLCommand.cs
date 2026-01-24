namespace NotaNacional.Infra.Commands
{
    public class ConsultarNfseUrlSQLCommand
    {
        public static string WsNfseConsultarUrl = "dbo.NOTA_FISCAL_WS_CONSULTAR_LINKS_UTEIS";   

        public static string WSNfseConsultaUrlMunicipio = "SELECT VALOR FROM PARAMETROS WHERE NOME_PARAMETRO = 'URL_SISTEMA_ONLINE'";

    }
    

    
}
