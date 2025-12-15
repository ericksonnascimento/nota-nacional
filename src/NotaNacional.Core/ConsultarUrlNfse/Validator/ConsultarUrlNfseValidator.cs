using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarUrlNfse.Validator
{
    public class ConsultarUrlNfseValidator : BaseSchemaValidator, IConsultarUrlNfseValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string OperationName => "ConsultarUrlNfse";
    }
}
