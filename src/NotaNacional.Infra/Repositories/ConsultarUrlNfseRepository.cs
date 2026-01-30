using System.Data;
using NotaNacional.Core.ConsultarUrlNfse.Models;
using NotaNacional.Core.ConsultarUrlNfse.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NotaNacional.Core.Helpers;

namespace NotaNacional.Infra.Repositories
{
    public class ConsultarUrlNfseRepository(IConfiguration configuration) : IConsultarUrlNfseRepository
    {
        public WsNfseConsultarUrlResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("MainConnection"));
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("XML_REQUISICAO", outerXml);
            parameters.Add("CPF_CNPJ_CERTIFICADO", cpfCnpjCertificado);
            parameters.Add("ERROS", erros);
            parameters.Add("IP_USUARIO", ipUsuario);
            parameters.Add("XML_RESPOSTA", dbType: DbType.String, direction: ParameterDirection.Output,size:10000);            

            var retorno = string.Empty;         

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
                retorno = "<ConsultarUrlNfseResposta xmlns=\"http://www.sped.fazenda.gov.br/nfse\">";
                retorno +="<ListaLinks>";
                var pagina = string.Empty;                    

                while (xmlResult.Read())
                {
                    var InscricaoMunicipal = Convert.ToString(xmlResult["InscricaoMunicipal"]) ?? "";
                    var serie = Convert.ToString(xmlResult["SerieNfse"]) ?? "";
                    var tipoContribuinte = Convert.ToString(xmlResult["TipoContribuinte"]) ?? "";
                    var numeroNfse = Convert.ToString(xmlResult["NumeroNfse"]) ?? "";
                    var Cnpj = Convert.ToString(xmlResult["Cnpj"]) ?? "";
                    var Cpf = Convert.ToString(xmlResult["Cpf"]) ?? "";
                    var CodigoMunicipio = Convert.ToString(xmlResult["CodigoMunicipio"]) ?? "";
                    var NumeroRps = Convert.ToString(xmlResult["NumeroRps"]) ?? "";
                    var SerieRps = Convert.ToString(xmlResult["SerieRps"]) ?? "";
                    var TipoRps = Convert.ToString(xmlResult["TipoRps"]) ?? "";
                    var ChaveAutenticidade = Convert.ToString(xmlResult["ChaveAutenticidade"]) ?? "";
                    var GerarUrl = Convert.ToString(xmlResult["GerarUrl"]) ?? "";
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
