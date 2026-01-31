using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.Cabecalho.Validator
{
    public class CabecalhoValidator : BaseSchemaValidator, ICabecalhoValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "Cabeçalho";
    }
}
