using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarLoteDps.Validator
{
    public class ConsultarLoteDpsValidator : BaseSchemaValidator, IConsultarLoteDpsValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "ConsultarLoteDps";
    }
}