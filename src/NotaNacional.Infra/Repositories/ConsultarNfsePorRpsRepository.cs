using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.ConsultarNfsePorRps.Models;
using NotaNacional.Core.ConsultarNfsePorRps.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class ConsultarNfsePorRpsRepository(IConfiguration configuration) : IConsultarNfsePorRpsRepository
    {
        public WsNfseConsultarNfsePorRpsResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
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
                        ConsultarNfsePorRpsSQLCommand.WsNfseConsultarNfsePorRps,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseConsultarNfsePorRpsResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}