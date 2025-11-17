using System.Data;
using System.Data.SqlClient;
using Abrasf.Core.CancelarNfse.Models;
using Abrasf.Core.GerarNfse.Models;
using Abrasf.Core.GerarNfse.Repositories;
using Abrasf.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Abrasf.Infra.Repositories
{

    public class GerarNfseRepository : IGerarNfseRepository
    {
        private readonly IConfiguration _configuration;

        public GerarNfseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public WsNfseGerarNfseResult Generate(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario ,string issuer = "")
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
                        GerarNfseSQLCommand.WsNfseGerarNfse,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseGerarNfseResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}