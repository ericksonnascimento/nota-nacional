using Abrasf.Core.ConsultarNfseServicoPrestado.Models;

namespace Abrasf.Core.ConsultarNfseServicoPrestado.Repositories
{

    public interface IConsultarNfseServicoPrestadoRepository
    {
        WsNfseConsultarNfseServicoPrestadoResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}