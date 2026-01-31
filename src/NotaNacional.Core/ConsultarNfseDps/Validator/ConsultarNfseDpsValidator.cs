using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarNfseDps.Validator
{
    public class ConsultarNfseDpsValidator : BaseSchemaValidator, IConsultarNfseDpsValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "ConsultarNfseDps";
    }
}