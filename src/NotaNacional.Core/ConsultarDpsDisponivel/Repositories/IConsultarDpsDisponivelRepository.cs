using NotaNacional.Core.ConsultarDpsDisponivel.Models;

namespace NotaNacional.Core.ConsultarDpsDisponivel.Repositories
{
    public interface IConsultarDpsDisponivelRepository
    {
        WsConsultarDpsDisponivelResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}