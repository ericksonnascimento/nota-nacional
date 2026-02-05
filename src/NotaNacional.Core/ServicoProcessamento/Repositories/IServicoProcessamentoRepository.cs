using NotaNacional.Core.ServicoProcessamento.Models;

namespace NotaNacional.Core.ServicoProcessamento.Repositories
{

    public interface IServicoProcessamentoRepository
    {
        List<LotePendente> PullPending(MunicipioProcessamento city);

        void SendToProcess(MunicipioProcessamento city, long protocol);
    }
}