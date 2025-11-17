using Abrasf.Core.ConsultarNfseFaixa.Models;

namespace Abrasf.Core.ConsultarNfseFaixa.Repositories
{

    public interface IConsultarNfseFaixaRepository
    {
        WsNfseConsultarNfseFaixaResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}