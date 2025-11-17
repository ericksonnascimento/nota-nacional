using System.Data;
using System.Data.SqlClient;
using Abrasf.Core.ConsultarNfseFaixa.Models;
using Abrasf.Core.ConsultarNfseFaixa.Repositories;
using Abrasf.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Abrasf.Infra.Repositories
{

    public class ConsultarNfseFaixaRepository : IConsultarNfseFaixaRepository
    {
        private readonly IConfiguration _configuration;

        public ConsultarNfseFaixaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public WsNfseConsultarNfseFaixaResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("MainConnection"));
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
                        ConsultarNfseFaixaSQLCommand.WsNfseConsultarPorFaixa,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseConsultarNfseFaixaResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}