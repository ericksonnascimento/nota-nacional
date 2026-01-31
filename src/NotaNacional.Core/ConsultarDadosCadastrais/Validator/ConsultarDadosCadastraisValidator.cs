using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarDadosCadastrais.Validator
{
    public class ConsultarDadosCadastraisValidator : BaseSchemaValidator, IConsultarDadosCadastraisValidator
    {
        protected override string DefaultSchemaVersion => "v101";
        protected override string OperationName => "ConsultarDadosCadastrais";
    }
}
