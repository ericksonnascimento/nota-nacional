using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarNfsePorRps.Validator
{
    public class ConsultarNfsePorRpsValidator : BaseSchemaValidator, IConsultarNfsePorRpsValidator
    {
        protected override string SchemaVersion => "v100";
        protected override string SchemaFileName => "consultarNfseDps.xsd";
        protected override string OperationName => "ConsultarNfseDps";
    }
}