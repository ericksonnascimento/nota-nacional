using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarNfseServicoTomado.Validator
{
    public class ConsultarNfseServicoTomadoValidator : BaseSchemaValidator, IConsultarNfseServicoTomadoValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string OperationName => "ConsultarNfseServicoTomado";
    }
}