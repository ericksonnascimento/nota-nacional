using System.Data;
using NotaNacional.Core.ServicoProcessamento.Models;
using NotaNacional.Core.ServicoProcessamento.Repositories;
using NotaNacional.Infra.Commands;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NotaNacional.Infra.Repositories
{

    public class ServicoProcessamentoRepository(IConfiguration configuration, ILogger<ServicoProcessamentoRepository> logger) : IServicoProcessamentoRepository
    {
        public List<LotePendente> PullPending(MunicipioProcessamento city)
        {
            var connectionString = GetConnectionString(city);
            if (string.IsNullOrEmpty(connectionString))
            {
                return Enumerable.Empty<LotePendente>().ToList();
            }
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var result = connection.Query<(string CAE, long COD_REQUISICAO)>(
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

        public void SendToProcess(MunicipioProcessamento city, long protocol)
        {
            var connectionString = GetConnectionString(city);
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var parameters = new
            {
                COD_REQUISICAO = protocol
            };

            var affectedRows = connection.Execute(ServicoProcessamentoSQLCommand.WsNfseProcessaLote, parameters,
                commandType: CommandType.StoredProcedure);
            logger.LogInformation("Affected rows: {AffectedRows}", affectedRows);
        }

        private string? GetConnectionString(MunicipioProcessamento city)
        {
            var key = city.ToString().ToLowerInvariant();
            return configuration.GetConnectionString(key);
        }
    }
}