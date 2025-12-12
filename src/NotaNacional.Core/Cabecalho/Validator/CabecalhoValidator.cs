using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.Cabecalho.Validator
{
    public class CabecalhoValidator : BaseSchemaValidator, ICabecalhoValidator
    {
        protected override string SchemaVersion => "v100";
        protected override string SchemaFileName => "cabecalho.xsd";
        protected override string OperationName => "Cabeçalho";
    }
}
