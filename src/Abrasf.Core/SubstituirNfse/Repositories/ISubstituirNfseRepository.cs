using Abrasf.Core.SubstituirNfse.Models;

namespace Abrasf.Core.SubstituirNfse.Repositories
{

    public interface ISubstituirNfseRepository
    {
        WsSubstituirNfseResult Replace(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario ,string issuer = "");
    }
}