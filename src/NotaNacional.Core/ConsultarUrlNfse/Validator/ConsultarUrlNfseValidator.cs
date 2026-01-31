using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarUrlNfse.Validator
{
    public class ConsultarUrlNfseValidator : BaseSchemaValidator, IConsultarUrlNfseValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "ConsultarUrlNfse";
    }
}
