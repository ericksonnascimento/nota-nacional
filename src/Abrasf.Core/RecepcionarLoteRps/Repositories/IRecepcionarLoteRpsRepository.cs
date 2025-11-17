using Abrasf.Core.RecepcionarLoteRps.Models;

namespace Abrasf.Core.RecepcionarLoteRps.Repositories
{

    public interface IRecepcionarLoteRpsRepository
    {
        WsNfseEnviarLoteRpsResult Register(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario, string issuer = "");
    }
}