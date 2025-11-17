using Abrasf.Core.ServicoProcessamento.Models;

namespace Abrasf.Core.ServicoProcessamento.Repositories
{

    public interface IServicoProcessamentoRepository
    {
        List<LotePendente> PullPending(MunicipioProcessamento city);

        void SendToProcess(MunicipioProcessamento city, Guid protocol);
    }
}