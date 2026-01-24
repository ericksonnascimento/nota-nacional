using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.RecepcionarLoteDps.Validator
{
    public class RecepcionarLoteDpsValidator : BaseSchemaValidator, IRecepcionarLoteDpsValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string OperationName => "EnviarLoteDps";
    }
}