using System.Data;
using NotaNacional.Core.ConsultarDpsDisponivel.Models;
using NotaNacional.Core.ConsultarDpsDisponivel.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{
    public class ConsultarDpsDisponivelRepository(IConfiguration configuration) : IConsultarDpsDisponivelRepository
    {
        public WsConsultarDpsDisponivelResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
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
                    ConsultarDpsDisponivelSQLCommand.WsConsultarDpsDisponivel,
                    parameters, commandType:CommandType.StoredProcedure);

            return new WsConsultarDpsDisponivelResult()
            {
                XmlResposta= xmlResult 
            };
        }
    }
}