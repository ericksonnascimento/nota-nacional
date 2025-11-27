using NotaNacional.Core.ConsultarNfseFaixa.Models;

namespace NotaNacional.Core.ConsultarNfseFaixa.Repositories
{

    public interface IConsultarNfseFaixaRepository
    {
        WsNfseConsultarNfseFaixaResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}