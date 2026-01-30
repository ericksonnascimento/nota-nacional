using System.Data;
using NotaNacional.Core.ConsultarNfseFaixa.Models;
using NotaNacional.Core.ConsultarNfseFaixa.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class ConsultarNfseFaixaRepository(IConfiguration configuration) : IConsultarNfseFaixaRepository
    {
        public WsNfseConsultarNfseFaixaResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
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
                        ConsultarNfseFaixaSQLCommand.WsNfseConsultarPorFaixa,
                        parameters, commandType: CommandType.StoredProcedure);

            return new WsNfseConsultarNfseFaixaResult()
            {
                XmlResposta = xmlResult
            };
        }
    }
}