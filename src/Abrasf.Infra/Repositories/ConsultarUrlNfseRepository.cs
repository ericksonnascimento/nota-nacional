using System.Data;
using System.Data.SqlClient;
using Abrasf.Core.ConsultarUrlNfse.Models;
using Abrasf.Core.ConsultarUrlNfse.Repositories;
using Abrasf.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;
using Abrasf.Core.Helpers;

namespace Abrasf.Infra.Repositories
{
    public class ConsultarUrlNfseRepository : IConsultarUrlNfseRepository
    {
        private readonly IConfiguration _configuration;

        public ConsultarUrlNfseRepository(IConfiguration configuration)
        {
            _configuration = configuration;     
        }
        public WsNfseConsultarUrlResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("MainConnection"));
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("XML_REQUISICAO", outerXml);
            parameters.Add("CPF_CNPJ_CERTIFICADO", cpfCnpjCertificado);
            parameters.Add("ERROS", erros);
            parameters.Add("IP_USUARIO", ipUsuario);
            parameters.Add("XML_RESPOSTA", dbType: DbType.String, direction: ParameterDirection.Output,size:10000);            

            string retorno = string.Empty;         

            var Urlmunicipio = connection.QuerySingleOrDefault<string>(
                        ConsultarNfseUrlSQLCommand.WSNfseConsultaUrlMunicipio,
                        parameters, commandType: CommandType.Text);

            var xmlResult =
                connection
                    .ExecuteReader(
                        ConsultarNfseUrlSQLCommand.WsNfseConsultarUrl,
                        parameters, commandType: CommandType.StoredProcedure);

            if (xmlResult.FieldCount > 0)    
            {              
                retorno = "<ConsultarUrlNfseResposta xmlns=\"http://www.abrasf.org.br/nfse.xsd\">";
                retorno +="<ListaLinks>";
                string pagina = string.Empty;                    

                while (xmlResult.Read())
                {
                    string InscricaoMunicipal = Convert.ToString(xmlResult["InscricaoMunicipal"]) ?? "";
                    string serie = Convert.ToString(xmlResult["SerieNfse"]) ?? "";
                    string tipoContribuinte = Convert.ToString(xmlResult["TipoContribuinte"]) ?? "";
                    string numeroNfse = Convert.ToString(xmlResult["NumeroNfse"]) ?? "";
                    string Cnpj = Convert.ToString(xmlResult["Cnpj"]) ?? "";
                    string Cpf = Convert.ToString(xmlResult["Cpf"]) ?? "";
                    string CodigoMunicipio = Convert.ToString(xmlResult["CodigoMunicipio"]) ?? "";
                    string NumeroRps = Convert.ToString(xmlResult["NumeroRps"]) ?? "";
                    string SerieRps = Convert.ToString(xmlResult["SerieRps"]) ?? "";
                    string TipoRps = Convert.ToString(xmlResult["TipoRps"]) ?? "";
                    string ChaveAutenticidade = Convert.ToString(xmlResult["ChaveAutenticidade"]) ?? "";
                    string GerarUrl = Convert.ToString(xmlResult["GerarUrl"]) ?? "";
                    if (string.IsNullOrEmpty(pagina))
                    {
                        pagina = Convert.ToString(xmlResult["Pagina"]) ?? string.Empty;
                    }
                        string[] input = {
                        InscricaoMunicipal,
                        serie ,
                        tipoContribuinte ,
                        numeroNfse,
                        ChaveAutenticidade

                        };

                    UrlNfse urlGenerator = new(input, Urlmunicipio);
                    string urlNfseGerada;
                    string urlAutenticidade;

                    if (String.Equals(GerarUrl, "0"))
                    {
                        urlNfseGerada = "Serviço temporariamente indisponível";
                        urlAutenticidade = "Serviço temporariamente indisponível";
                    }
                    else
                    {
                        urlNfseGerada = urlGenerator.GetUrlNF();
                        urlAutenticidade = urlGenerator.GetUrlAutenticidade();                    
                    }

                    retorno += "<Links>";

                    retorno += "<IdentificacaoNfse>";
                    retorno += "<Numero>" + numeroNfse + "</Numero>";

                    retorno += "<CpfCnpj>";
                    if (Cnpj.Length > 11)
                    {
                        retorno += "<Cnpj>" + Cnpj + "</Cnpj>";
                    }
                    else {
                        retorno += "<Cpf>" + Cpf + "</Cpf>";
                    }
                    retorno += "</CpfCnpj>";

                    retorno += "<InscricaoMunicipal>" + InscricaoMunicipal + "</InscricaoMunicipal>";
                    retorno += "<CodigoMunicipio>" + CodigoMunicipio + "</CodigoMunicipio>";
                    retorno += "</IdentificacaoNfse>";
                    
                    retorno += "<IdentificacaoRps>";
                    retorno += "<Numero>" + NumeroRps + "</Numero>";
                    retorno += "<Serie>" + SerieRps + "</Serie>";
                    retorno += "<Tipo>" + TipoRps + "</Tipo>";
                    retorno += "</IdentificacaoRps>";

                    retorno += "<UrlVisualizacaoNfse>" + urlNfseGerada + "</UrlVisualizacaoNfse>";               
                    retorno += "<UrlVerificaAutenticidade>" + urlAutenticidade + "</UrlVerificaAutenticidade>";

                    retorno += "</Links>";
                }

                retorno += "<Pagina>" + pagina + "</Pagina>";
                retorno += "</ListaLinks>";
                retorno += "</ConsultarUrlNfseResposta>";
            }
            else
            {                
                 retorno = parameters.Get<string>("XML_RESPOSTA");
            }
           
            return new WsNfseConsultarUrlResult()
            {
                XmlResposta = retorno
            };
        }
    }
}
