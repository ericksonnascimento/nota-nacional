using System.Data;
using NotaNacional.Core.ConsultarNfseServicoTomado.Models;
using NotaNacional.Core.ConsultarNfseServicoTomado.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class ConsultarNfseServicoTomadoRepository(IConfiguration configuration)
        : IConsultarNfseServicoTomadoRepository
    {
        public WsNfseConsultarNfseServicoTomadoResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("MainConnection"));
            connection.Open();
            var parameters = new
            {
                XML_REQUISICAO = outerXml,
                CPF_CNPJ_CERTIFICADO = cpfCnpjCertificado,
                ERROS = erros,
                IP_USUARIO = ipUsuario
            };

            var xmlResult =
                connection
                    .QuerySingleOrDefault<string>(
                        ConsultarNfseServicoTomadoSQLCommand.WsNfseConsultarServicoTomado,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseConsultarNfseServicoTomadoResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}