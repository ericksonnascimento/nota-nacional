using Abrasf.Core.ConsultarRpsDisponivel.Models;

namespace Abrasf.Core.ConsultarRpsDisponivel.Repositories
{
    public interface IConsultarRpsDisponivelRepository
    {
        WsConsultarRpsDisponivelResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}
