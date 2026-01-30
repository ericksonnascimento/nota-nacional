using System.Data;
using NotaNacional.Core.ConsultarRpsDisponivel.Models;
using NotaNacional.Core.ConsultarRpsDisponivel.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{
    public class ConsultarRpsDisponivelRepository(IConfiguration configuration) : IConsultarRpsDisponivelRepository
    {
        public WsConsultarRpsDisponivelResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
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
                    ConsultarRpsDisponivelSQLCommand.WsConsultarRpsDisponivel,
                    parameters, commandType:CommandType.StoredProcedure);

            return new WsConsultarRpsDisponivelResult()
            {
                XmlResposta= xmlResult 
            };
        }
    }
}
