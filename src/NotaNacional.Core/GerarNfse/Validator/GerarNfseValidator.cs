using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.GerarNfse.Validator
{
    public class GerarNfseValidator : BaseSchemaValidator, IGerarNfseValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "GerarNfse";
    }
}