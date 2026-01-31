using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarNfsePorRps.Validator
{
    public class ConsultarNfsePorRpsValidator : BaseSchemaValidator, IConsultarNfsePorRpsValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "ConsultarNfseDps";
    }
}