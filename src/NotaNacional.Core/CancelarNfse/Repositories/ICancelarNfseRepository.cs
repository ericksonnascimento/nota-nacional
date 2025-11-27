using NotaNacional.Core.CancelarNfse.Models;

namespace NotaNacional.Core.CancelarNfse.Repositories
{

    public interface ICancelarNfseRepository
    {
        WsCancelarNfseResult Cancel(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario, string issuer= "");
    }
}