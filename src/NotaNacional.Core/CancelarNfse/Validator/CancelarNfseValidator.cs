using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.CancelarNfse.Validator
{
    public class CancelarNfseValidator : BaseSchemaValidator, ICancelarNfseValidator
    {
        protected override string SchemaVersion => "v100";
        protected override string SchemaFileName => "cancelarNfse.xsd";
        protected override string OperationName => "CancelarNfse";
    }
}