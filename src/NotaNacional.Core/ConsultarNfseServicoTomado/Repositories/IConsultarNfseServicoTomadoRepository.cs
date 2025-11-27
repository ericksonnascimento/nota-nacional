using NotaNacional.Core.ConsultarNfseServicoTomado.Models;

namespace NotaNacional.Core.ConsultarNfseServicoTomado.Repositories
{

    public interface IConsultarNfseServicoTomadoRepository
    {
        WsNfseConsultarNfseServicoTomadoResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}