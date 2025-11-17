using System.Data;
using System.Data.SqlClient;
using Abrasf.Core.RecepcionarLoteRpsSincrono.Models;
using Abrasf.Core.RecepcionarLoteRpsSincrono.Repositories;
using Abrasf.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Abrasf.Infra.Repositories
{

    public class RecepcionarLoteRpsSincronoRepository : IRecepcionarLoteRpsSincronoRepository
    {
        private readonly IConfiguration _configuration;

        public RecepcionarLoteRpsSincronoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public WsNfseEnviarLoteRpsSincronoResult Process(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario ,string issuer = "")
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("MainConnection"));
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
                        RecepcionarLoteRpsSincronoSQLCommand.WsNfseRepecionarLoteRpsSincrono,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseEnviarLoteRpsSincronoResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}