using NotaNacional.Core.RecepcionarLoteDpsSincrono.Models;

namespace NotaNacional.Core.RecepcionarLoteDpsSincrono.Repositories
{

    public interface IRecepcionarLoteDpsSincronoRepository
    {
        WsNfseEnviarLoteDpsSincronoResult Process(string outerXml, string cpfCnpjCertificado, string erros,string ipUsuario ,string issuer = "");
    }
}