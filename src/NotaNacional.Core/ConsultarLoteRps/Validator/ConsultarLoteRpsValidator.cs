using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarLoteRps.Validator
{
    public class ConsultarLoteRpsValidator : BaseSchemaValidator, IConsultarLoteRpsValidator
    {
        protected override string SchemaVersion => "v100";
        protected override string SchemaFileName => "consultarLoteDps.xsd";
        protected override string OperationName => "ConsultarLoteDps";
    }
}