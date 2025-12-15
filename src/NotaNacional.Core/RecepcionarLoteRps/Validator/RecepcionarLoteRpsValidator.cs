using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.RecepcionarLoteRps.Validator
{
    public class RecepcionarLoteRpsValidator : BaseSchemaValidator, IRecepcionarLoteRpsValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string OperationName => "EnviarLoteDps";
    }
}