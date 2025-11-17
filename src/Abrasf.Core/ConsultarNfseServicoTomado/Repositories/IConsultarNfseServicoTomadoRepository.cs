using Abrasf.Core.ConsultarNfseServicoTomado.Models;

namespace Abrasf.Core.ConsultarNfseServicoTomado.Repositories
{

    public interface IConsultarNfseServicoTomadoRepository
    {
        WsNfseConsultarNfseServicoTomadoResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}