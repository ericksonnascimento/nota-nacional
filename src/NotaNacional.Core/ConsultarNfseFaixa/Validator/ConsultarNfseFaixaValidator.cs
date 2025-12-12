using NotaNacional.Core.Base.Validator;

namespace NotaNacional.Core.ConsultarNfseFaixa.Validator
{
    public class ConsultarNfseFaixaValidator : BaseSchemaValidator, IConsultarNfseFaixaValidator
    {
        protected override string DefaultSchemaVersion => "v100";
        protected override string SchemaFileName => "consultarNfseFaixa.xsd";
        protected override string OperationName => "ConsultarNfseFaixa";
    }
}