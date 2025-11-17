using Abrasf.Core.ConsultarNfsePorRps.Models;

namespace Abrasf.Core.ConsultarNfsePorRps.Repositories
{

    public interface IConsultarNfsePorRpsRepository
    {
        WsNfseConsultarNfsePorRpsResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}