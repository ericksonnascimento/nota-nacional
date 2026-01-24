using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.ConsultarDpsDisponivel.Models;
using NotaNacional.Core.ConsultarDpsDisponivel.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{
    public class ConsultarDpsDisponivelRepository : IConsultarDpsDisponivelRepository    
    {
        private readonly IConfiguration _configuration;

        public ConsultarDpsDisponivelRepository(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public WsConsultarDpsDisponivelResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
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
                    ConsultarDpsDisponivelSQLCommand.WsConsultarDpsDisponivel,
                    parameters, commandType:CommandType.StoredProcedure);

            return new WsConsultarDpsDisponivelResult()
            {
                XmlResposta= xmlResult 
            };
        }
    }
}