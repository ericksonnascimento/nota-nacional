using NotaNacional.Core.GerarNfse.Models;

namespace NotaNacional.Core.GerarNfse.Repositories
{

    public interface IGerarNfseRepository
    {
        WsNfseGerarNfseResult Generate(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario ,string issuer= "");
    }
}