using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.ConsultarRpsDisponivel.Models;
using NotaNacional.Core.ConsultarRpsDisponivel.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{
    public class ConsultarRpsDisponivelRepository : IConsultarRpsDisponivelRepository    
    {
        private readonly IConfiguration _configuration;

        public ConsultarRpsDisponivelRepository(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public WsConsultarRpsDisponivelResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario)
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
                    ConsultarRpsDisponivelSQLCommand.WsConsultarRpsDisponivel,
                    parameters, commandType:CommandType.StoredProcedure);

            return new WsConsultarRpsDisponivelResult()
            {
                XmlResposta= xmlResult 
            };
        }
    }
}
