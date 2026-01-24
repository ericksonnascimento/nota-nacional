using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.ConsultarLoteDps.Models;
using NotaNacional.Core.ConsultarLoteDps.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class ConsultarLoteDpsRepository : IConsultarLoteDpsRepository
    {
        private readonly IConfiguration _configuration;

        public ConsultarLoteDpsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public WsNfseConsultarLoteDpsResult Find(string outerXml, string erros, string ipUsuario)
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
                        ConsultarLoteDpsSQLCommand.WsNfseConsultarLoteDps,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseConsultarLoteDpsResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}