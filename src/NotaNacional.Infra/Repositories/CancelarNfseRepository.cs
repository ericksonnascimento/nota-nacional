using System.Data;
using NotaNacional.Core.CancelarNfse.Models;
using NotaNacional.Core.CancelarNfse.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class CancelarNfseRepository(IConfiguration configuration) : ICancelarNfseRepository
    {
        public WsCancelarNfseResult Cancel(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario, string issuer = "")
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("MainConnection"));
            connection.Open();
            var parameters = new
            {
                XML_REQUISICAO = outerXml,
                CPF_CNPJ_CERTIFICADO = cpfCnpjCertificado,
                ERROS = erros,
                IP_USUARIO = ipUsuario,
                MSG_ERRO = issuer
            };

            var xmlResult =
                connection
                    .QuerySingleOrDefault<string>(
                        CancelarNfseSQLCommand.WsNfseCancelar,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsCancelarNfseResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}