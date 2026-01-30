using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.RecepcionarLoteDpsSincrono.Models;
using NotaNacional.Core.RecepcionarLoteDpsSincrono.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class RecepcionarLoteDpsSincronoRepository(IConfiguration configuration)
        : IRecepcionarLoteDpsSincronoRepository
    {
        public WsNfseEnviarLoteDpsSincronoResult Process(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario ,string issuer = "")
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
                        RecepcionarLoteDpsSincronoSQLCommand.WsNfseRepecionarLoteDpsSincrono,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseEnviarLoteDpsSincronoResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}