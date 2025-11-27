using NotaNacional.Core.ConsultarUrlNfse.Models;

namespace NotaNacional.Core.ConsultarUrlNfse.Repositories
{
    public interface IConsultarUrlNfseRepository
    {
        WsNfseConsultarUrlResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}



