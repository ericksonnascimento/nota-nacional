using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarUrlNfse.Validator
{
    public class ConsultarUrlNfseValidator : BaseSchemaValidator, IConsultarUrlNfseValidator
    {
        protected override string SchemaVersion => "v100";
        protected override string SchemaFileName => "consultarUrlNfse.xsd";
        protected override string OperationName => "ConsultarUrlNfse";
    }
}
