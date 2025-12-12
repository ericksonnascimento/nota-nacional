using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarNfseServicoPrestado.Validator
{
    public class ConsultarNfseServicoPrestadoValidator : BaseSchemaValidator, IConsultarNfseServicoPrestadoValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string SchemaFileName => "consultarNfseServicoPrestado.xsd";
        protected override string OperationName => "ConsultarNfseServicoPrestado";
    }
}