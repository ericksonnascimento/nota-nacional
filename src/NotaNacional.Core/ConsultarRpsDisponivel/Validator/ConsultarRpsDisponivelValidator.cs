using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarRpsDisponivel.Validator
{
    public class ConsultarRpsDisponivelValidator : BaseSchemaValidator, IConsultarRpsDisponivelValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string SchemaFileName => "consultarDpsDisponivel.xsd";
        protected override string OperationName => "ConsultarDpsDisponivel";
    }
}
