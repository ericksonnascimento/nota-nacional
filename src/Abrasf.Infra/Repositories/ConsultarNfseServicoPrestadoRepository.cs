using System.Data;
using System.Data.SqlClient;
using Abrasf.Core.ConsultarNfseServicoPrestado.Models;
using Abrasf.Core.ConsultarNfseServicoPrestado.Repositories;
using Abrasf.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Abrasf.Infra.Repositories
{

    public class ConsultarNfseServicoPrestadoRepository : IConsultarNfseServicoPrestadoRepository
    {
        private readonly IConfiguration _configuration;

        public ConsultarNfseServicoPrestadoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public WsNfseConsultarNfseServicoPrestadoResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("MainConnection"));
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