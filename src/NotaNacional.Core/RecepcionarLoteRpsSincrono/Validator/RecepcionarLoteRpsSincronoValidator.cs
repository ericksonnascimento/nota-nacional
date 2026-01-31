using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.RecepcionarLoteRpsSincrono.Validator
{
    public class RecepcionarLoteRpsSincronoValidator : BaseSchemaValidator, IRecepcionarLoteRpsSincronoValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "EnviarLoteDpsSincrono";
    }
}