using NotaNacional.Core.ConsultarNfseDps.Models;

namespace NotaNacional.Core.ConsultarNfseDps.Repositories
{

    public interface IConsultarNfseDpsRepository
    {
        WsNfseConsultarNfseDpsResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}