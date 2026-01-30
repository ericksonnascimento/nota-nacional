using System.Data;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Models;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class ConsultarNfseServicoPrestadoRepository(IConfiguration configuration)
        : IConsultarNfseServicoPrestadoRepository
    {
        public WsNfseConsultarNfseServicoPrestadoResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("MainConnection"));
            connection.Open();
            var parameters = new
            {
                XML_REQUISICAO = outerXml,
                CPF_CNPJ_CERTIFICADO = cpfCnpjCertificado,
                ERROS = erros,
                IP_USUARIO = ipUsuario,
            };

            var xmlResult =
                connection
                    .QuerySingleOrDefault<string>(
                        ConsultarNfseServicoPrestadoSQLCommand.WsNfseConsultarServicoPrestado,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseConsultarNfseServicoPrestadoResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}