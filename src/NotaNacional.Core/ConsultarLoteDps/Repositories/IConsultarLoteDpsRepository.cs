using NotaNacional.Core.ConsultarLoteDps.Models;
    

namespace NotaNacional.Core.ConsultarLoteDps.Repositories
{

    public interface IConsultarLoteDpsRepository
    {
    WsNfseConsultarLoteDpsResult Find(string outerXml, string erros, string ipUsuario);
    }
}