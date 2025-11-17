using Abrasf.Core.Models.Response;

namespace Abrasf.Core.Base
{

    public interface IHandler
    {
        BaseResponse Handle(object header, object body, string ipUsuario);
    }
}