using NotaNacional.Core.RecepcionarLoteDps.Models;

namespace NotaNacional.Core.RecepcionarLoteDps.Repositories
{

    public interface IRecepcionarLoteDpsRepository
    {
        WsNfseEnviarLoteDpsResult Register(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario, string issuer = "");
    }
}