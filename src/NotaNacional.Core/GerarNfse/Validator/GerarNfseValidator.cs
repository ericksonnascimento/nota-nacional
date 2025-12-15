using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.GerarNfse.Validator
{
    public class GerarNfseValidator : BaseSchemaValidator, IGerarNfseValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string OperationName => "GerarNfse";
    }
}