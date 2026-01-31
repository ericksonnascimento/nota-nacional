using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarRpsDisponivel.Validator
{
    public class ConsultarRpsDisponivelValidator : BaseSchemaValidator, IConsultarRpsDisponivelValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "ConsultarDpsDisponivel";
    }
}
