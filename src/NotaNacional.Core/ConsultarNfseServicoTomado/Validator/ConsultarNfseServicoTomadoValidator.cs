using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarNfseServicoTomado.Validator
{
    public class ConsultarNfseServicoTomadoValidator : BaseSchemaValidator, IConsultarNfseServicoTomadoValidator
    {
        protected override string SchemaVersion => "v100";
        protected override string SchemaFileName => "consultarNfseServicoTomado.xsd";
        protected override string OperationName => "ConsultarNfseServicoTomado";
    }
}