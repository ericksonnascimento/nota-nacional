using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.GerarNfse.Validator
{
    public class GerarNfseValidator : BaseSchemaValidator, IGerarNfseValidator
    {
        protected override string SchemaVersion => "v100";
        protected override string SchemaFileName => "gerarNfse.xsd";
        protected override string OperationName => "GerarNfse";
    }
}