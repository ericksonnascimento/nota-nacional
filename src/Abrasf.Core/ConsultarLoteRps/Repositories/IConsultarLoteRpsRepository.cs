using Abrasf.Core.ConsultarLoteRps.Models;
    

namespace Abrasf.Core.ConsultarLoteRps.Repositories
{

    public interface IConsultarLoteRpsRepository
    {
    WsNfseConsultarLoteRpsResult Find(string outerXml, string erros, string ipUsuario);
    }
}