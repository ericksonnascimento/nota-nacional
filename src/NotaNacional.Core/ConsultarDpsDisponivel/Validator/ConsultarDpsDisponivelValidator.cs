using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarDpsDisponivel.Validator
{
    public class ConsultarDpsDisponivelValidator : BaseSchemaValidator, IConsultarDpsDisponivelValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "ConsultarDpsDisponivel";
    }
}