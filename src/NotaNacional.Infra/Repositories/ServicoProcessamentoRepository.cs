using System.Data;
using System.Data.SqlClient;
using NotaNacional.Core.ServicoProcessamento.Models;
using NotaNacional.Core.ServicoProcessamento.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace NotaNacional.Infra.Repositories
{

    public class ServicoProcessamentoRepository(IConfiguration configuration) : IServicoProcessamentoRepository
    {
        public List<LotePendente> PullPending(MunicipioProcessamento city)
        {
            var connectionString = GetConnectionString(city);
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var result = connection.Query<(string CAE, Guid COD_REQUISICAO)>(
                ServicoProcessamentoSQLCommand.WsNfseLoteAProcessar,
                commandType: CommandType.StoredProcedure
            );

            return result.Select(item => new LotePendente
            {
                NumeroProtocolo = item.COD_REQUISICAO,
                DataSolicitacao = DateTime.Now,
                InscricaoMunicipal = item.CAE,
                Quantidade = 1
            }).ToList();
        }

        public void SendToProcess(MunicipioProcessamento city, Guid protocol)
        {
            var connectionString = GetConnectionString(city);
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var parameters = new
            {
                NU_PROTOCOLO = protocol
            };

            var affectedRows = connection.Execute(ServicoProcessamentoSQLCommand.WsNfseProcessaLote, parameters,
                commandType: CommandType.StoredProcedure);
            Console.WriteLine($"Affected rows: {affectedRows}");
        }

        private string GetConnectionString(MunicipioProcessamento city)
        {
            var key = city.ToString().ToLowerInvariant();
            return configuration.GetConnectionString(key);
        }
    }
}