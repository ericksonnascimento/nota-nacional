using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.ConsultarNfseDps.Models;
using NotaNacional.Core.ConsultarNfseDps.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class ConsultarNfseDpsRepository : IConsultarNfseDpsRepository
    {
        private readonly IConfiguration _configuration;

        public ConsultarNfseDpsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public WsNfseConsultarNfseDpsResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("MainConnection"));
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
                        ConsultarNfseDpsSQLCommand.WsNfseConsultarNfseDps,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseConsultarNfseDpsResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}