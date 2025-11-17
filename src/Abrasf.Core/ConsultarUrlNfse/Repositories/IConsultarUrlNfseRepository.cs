using Abrasf.Core.ConsultarUrlNfse.Models;

namespace Abrasf.Core.ConsultarUrlNfse.Repositories
{
    public interface IConsultarUrlNfseRepository
    {
        WsNfseConsultarUrlResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}



