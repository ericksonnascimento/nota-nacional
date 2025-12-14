using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.Cabecalho.Validator
{
    public class CabecalhoValidator : BaseSchemaValidator, ICabecalhoValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string SchemaFileName => "cabecalho.xsd";
        protected override string OperationName => "Cabeçalho";
        
        /// <summary>
        /// Não inclui complexTypes.xsd porque ele também define o elemento cabecalho,
        /// o que causaria uma declaração duplicada
        /// </summary>
        protected override bool ShouldIncludeComplexTypes()
        {
            return false;
        }
    }
}
