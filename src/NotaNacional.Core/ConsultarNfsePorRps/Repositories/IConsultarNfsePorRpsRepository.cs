using NotaNacional.Core.ConsultarNfsePorRps.Models;

namespace NotaNacional.Core.ConsultarNfsePorRps.Repositories
{

    public interface IConsultarNfsePorRpsRepository
    {
        WsNfseConsultarNfsePorRpsResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}