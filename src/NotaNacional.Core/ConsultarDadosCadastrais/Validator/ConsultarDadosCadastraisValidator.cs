using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarDadosCadastrais.Validator
{
    public class ConsultarDadosCadastraisValidator : BaseSchemaValidator, IConsultarDadosCadastraisValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string SchemaFileName => "consultarDadosCadastrais.xsd";
        protected override string OperationName => "ConsultarDadosCadastrais";
    }
}
