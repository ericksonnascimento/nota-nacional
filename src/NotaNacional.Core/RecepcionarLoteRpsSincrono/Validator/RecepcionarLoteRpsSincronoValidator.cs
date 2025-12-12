using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.RecepcionarLoteRpsSincrono.Validator
{
    public class RecepcionarLoteRpsSincronoValidator : BaseSchemaValidator, IRecepcionarLoteRpsSincronoValidator
    {
        protected override string SchemaVersion => "v100";
        protected override string SchemaFileName => "enviarLoteDpsSincrono.xsd";
        protected override string OperationName => "EnviarLoteDpsSincrono";
    }
}