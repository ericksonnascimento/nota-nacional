using NotaNacional.Core.ConsultarDadosCadastrais.Models;

namespace NotaNacional.Core.ConsultarDadosCadastrais.Repositories
{
    public interface IConsultarDadosCadastraisRepository
    {
        WsConsultarDadosCadastraisResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}
