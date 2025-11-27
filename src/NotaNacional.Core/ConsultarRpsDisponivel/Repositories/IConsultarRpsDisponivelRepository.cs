using NotaNacional.Core.ConsultarRpsDisponivel.Models;

namespace NotaNacional.Core.ConsultarRpsDisponivel.Repositories
{
    public interface IConsultarRpsDisponivelRepository
    {
        WsConsultarRpsDisponivelResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}
