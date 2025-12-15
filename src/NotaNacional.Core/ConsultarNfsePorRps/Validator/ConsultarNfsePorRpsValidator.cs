using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarNfsePorRps.Validator
{
    public class ConsultarNfsePorRpsValidator : BaseSchemaValidator, IConsultarNfsePorRpsValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string OperationName => "ConsultarNfseDps";
    }
}