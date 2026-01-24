using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.RecepcionarLoteDpsSincrono.Validator
{
    public class RecepcionarLoteDpsSincronoValidator : BaseSchemaValidator, IRecepcionarLoteDpsSincronoValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string OperationName => "EnviarLoteDpsSincrono";
    }
}