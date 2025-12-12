using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarRpsDisponivel.Validator
{
    public class ConsultarRpsDisponivelValidator : BaseSchemaValidator, IConsultarRpsDisponivelValidator
    {
        protected override string SchemaVersion => "v100";
        protected override string SchemaFileName => "consultarDpsDisponivel.xsd";
        protected override string OperationName => "ConsultarDpsDisponivel";
    }
}
