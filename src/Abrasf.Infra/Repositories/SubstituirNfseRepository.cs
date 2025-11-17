using System.Data;
using System.Data.SqlClient;
using Abrasf.Core.SubstituirNfse.Models;
using Abrasf.Core.SubstituirNfse.Repositories;
using Abrasf.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Abrasf.Infra.Repositories
{

    public class SubstituirNfseRepository : ISubstituirNfseRepository
    {
        private readonly IConfiguration _configuration;

        public SubstituirNfseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public WsSubstituirNfseResult Replace(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario ,string issuer = "")
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
                        SubstituirNfseSQLCommand.WsNfseSubstituir,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsSubstituirNfseResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}