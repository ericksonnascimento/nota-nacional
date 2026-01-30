using System.Data;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Models;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class RecepcionarLoteRpsSincronoRepository(IConfiguration configuration)
        : IRecepcionarLoteRpsSincronoRepository
    {
        public WsNfseEnviarLoteRpsSincronoResult Process(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario ,string issuer = "")
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
                        RecepcionarLoteRpsSincronoSQLCommand.WsNfseRepecionarLoteRpsSincrono,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseEnviarLoteRpsSincronoResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}