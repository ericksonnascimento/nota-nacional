using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarNfseServicoPrestado.Validator
{
    public class ConsultarNfseServicoPrestadoValidator : BaseSchemaValidator, IConsultarNfseServicoPrestadoValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "ConsultarNfseServicoPrestado";
    }
}