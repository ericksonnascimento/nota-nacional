using System.Data;
using System.Data.SqlClient;
using Abrasf.Core.ConsultarLoteRps.Models;
using Abrasf.Core.ConsultarLoteRps.Repositories;
using Abrasf.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Abrasf.Infra.Repositories
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