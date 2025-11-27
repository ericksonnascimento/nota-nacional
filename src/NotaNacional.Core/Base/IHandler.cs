using NotaNacional.Core.Models.Response;

namespace NotaNacional.Core.Base
{

    public interface IHandler
    {
        BaseResponse Handle(object header, object body, string ipUsuario);
    }
}