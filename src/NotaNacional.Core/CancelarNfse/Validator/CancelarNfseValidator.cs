using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.CancelarNfse.Validator
{
    public class CancelarNfseValidator : BaseSchemaValidator, ICancelarNfseValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "CancelarNfse";
    }
}