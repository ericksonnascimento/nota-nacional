using NotaNacional.Core.ConsultarLoteDps.Models;
    

namespace NotaNacional.Core.ConsultarLoteDps.Repositories
{

    public interface IConsultarLoteDpsRepository
    {
    WsNfseConsultarLoteDpsResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}