using NotaNacional.Core.RecepcionarLoteRpsSincrono.Models;

namespace NotaNacional.Core.RecepcionarLoteRpsSincrono.Repositories
{

    public interface IRecepcionarLoteRpsSincronoRepository
    {
        WsNfseEnviarLoteRpsSincronoResult Process(string outerXml, string cpfCnpjCertificado, string erros,string ipUsuario ,string issuer = "");
    }
}