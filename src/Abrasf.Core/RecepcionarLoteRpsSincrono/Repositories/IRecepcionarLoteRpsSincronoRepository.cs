using Abrasf.Core.RecepcionarLoteRpsSincrono.Models;

namespace Abrasf.Core.RecepcionarLoteRpsSincrono.Repositories
{

    public interface IRecepcionarLoteRpsSincronoRepository
    {
        WsNfseEnviarLoteRpsSincronoResult Process(string outerXml, string cpfCnpjCertificado, string erros,string ipUsuario ,string issuer = "");
    }
}