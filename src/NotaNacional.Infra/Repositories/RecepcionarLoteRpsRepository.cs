using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.RecepcionarLoteRps.Models;
using NotaNacional.Core.RecepcionarLoteRps.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class RecepcionarLoteRpsRepository : IRecepcionarLoteRpsRepository
    {
        private readonly IConfiguration _configuration;

        public RecepcionarLoteRpsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public WsNfseEnviarLoteRpsResult Register(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario, string issuer = "")
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
                        RecepcionarLoteRpsSQLCommand.WsEnviarLoteRps,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseEnviarLoteRpsResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}