using NotaNacional.Core.RecepcionarLoteRps.Models;

namespace NotaNacional.Core.RecepcionarLoteRps.Repositories
{

    public interface IRecepcionarLoteRpsRepository
    {
        WsNfseEnviarLoteRpsResult Register(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario, string issuer = "");
    }
}