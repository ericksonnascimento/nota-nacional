using Abrasf.Core.CancelarNfse.Models;

namespace Abrasf.Core.CancelarNfse.Repositories
{

    public interface ICancelarNfseRepository
    {
        WsCancelarNfseResult Cancel(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario, string issuer= "");
    }
}