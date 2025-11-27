using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.ConsultarLoteRps.Models;
using NotaNacional.Core.ConsultarLoteRps.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class ConsultarLoteRpsRepository : IConsultarLoteRpsRepository
    {
        private readonly IConfiguration _configuration;

        public ConsultarLoteRpsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public WsNfseConsultarLoteRpsResult Find(string outerXml, string erros, string ipUsuario)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("MainConnection"));
            connection.Open();
            var parameters = new
            {
                XML_REQUISICAO = outerXml,
                ERROS = erros,
                IP_USUARIO = ipUsuario
            };

            var xmlResult =
                connection
                    .QuerySingleOrDefault<string>(
                        ConsultarLoteRpsSQLCommand.WsNfseConsultarLoteRps,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseConsultarLoteRpsResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}