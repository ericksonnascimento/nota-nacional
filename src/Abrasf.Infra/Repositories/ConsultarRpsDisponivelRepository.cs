using System.Data;
using System.Data.SqlClient;
using Abrasf.Core.ConsultarRpsDisponivel.Models;
using Abrasf.Core.ConsultarRpsDisponivel.Repositories;
using Abrasf.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Abrasf.Infra.Repositories
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
