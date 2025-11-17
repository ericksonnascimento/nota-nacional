using Abrasf.Core.ConsultarDadosCadastrais.Models;

namespace Abrasf.Core.ConsultarDadosCadastrais.Repositories
{
    public interface IConsultarDadosCadastraisRepository
    {
        WsConsultarDadosCadastraisResult Find(string outerXml, string cpfCnpjCertificado, string erros, string ipUsuario);
    }
}
