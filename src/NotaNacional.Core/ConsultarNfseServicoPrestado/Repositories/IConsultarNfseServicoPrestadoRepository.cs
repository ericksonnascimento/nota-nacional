using NotaNacional.Core.ConsultarNfseServicoPrestado.Models;

namespace NotaNacional.Core.ConsultarNfseServicoPrestado.Repositories
{

    public interface IConsultarNfseServicoPrestadoRepository
    {
        WsNfseConsultarNfseServicoPrestadoResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}