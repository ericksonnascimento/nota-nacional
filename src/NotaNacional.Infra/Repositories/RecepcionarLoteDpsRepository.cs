using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.RecepcionarLoteDps.Models;
using NotaNacional.Core.RecepcionarLoteDps.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class RecepcionarLoteDpsRepository(IConfiguration configuration) : IRecepcionarLoteDpsRepository
    {
        public WsNfseEnviarLoteDpsResult Register(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario, string issuer = "")
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
                        RecepcionarLoteDpsSQLCommand.WsEnviarLoteDps,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseEnviarLoteDpsResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}