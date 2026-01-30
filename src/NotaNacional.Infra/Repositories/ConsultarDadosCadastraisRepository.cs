using System.Data;
using NotaNacional.Core.ConsultarDadosCadastrais.Models;
using NotaNacional.Core.ConsultarDadosCadastrais.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{
    public class ConsultarDadosCadastraisRepository(IConfiguration configuration) : IConsultarDadosCadastraisRepository
    {
        public WsConsultarDadosCadastraisResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("MainConnection"));
            connection.Open();
            var parameters = new
            {
                XML_REQUISICAO = outerXml,
                CPF_CNPJ_CERTIFICADO = cpfCnpjCertificado,
                ERROS = erros,
                IP_USUARIO = ipUsuario

            };

            var xmlResult =
                connection
                    .QuerySingleOrDefault<string>(
                    ConsultarDadosCadastraisSQLCommand.WsConsutarDadosCadastrais, 
                    parameters, commandType:CommandType.StoredProcedure);

                    return new WsConsultarDadosCadastraisResult()
                    {
                        XmlResposta = xmlResult
                    };
        }
    }
}
