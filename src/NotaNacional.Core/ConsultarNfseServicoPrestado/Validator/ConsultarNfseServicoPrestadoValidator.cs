using System.Xml;
using System.Xml.Schema;
using NotaNacional.Core.Base.Validator;
using NotaNacional.Core.Helpers;

namespace NotaNacional.Core.ConsultarNfseServicoPrestado.Validator
{

    public class ConsultarNfseServicoPrestadoValidator : IConsultarNfseServicoPrestadoValidator
    {
        private const string Operation = "ConsultarNfseServicoPrestado";
        public ValidationResult Validate(object? data)
        {
            var result = new ValidationResult();
            if (data is null)
            {
                result.AddValidationError("E160", $"{Operation} deve ser informado.");
            }

            if (data is not XmlNode[])
            {
                result.AddValidationError("E160", $"{Operation} deve ser um XML válido.");
            }

            var body = ParseHelper.GetXml(data);

            if (!ValidateSchema(body))
            {
                result.AddValidationError("E160", $"{Operation} deve obedecer a um schema válido.");
            }

            result.IsValid = !result.Messages.Any();
            return result;
        }

        private bool ValidateSchema(string xml)
        {
            try
            {
                var signature = "Schemas/nacional/v100/xmldsig-core-schema.xsd";
                var simpleTypes = "Schemas/nacional/v100/simpleTypes.xsd";
                var complexTypes = "Schemas/nacional/v100/complexTypes.xsd";
                var consultarNfseServicoPrestado = "Schemas/nacional/v100/consultarNfseServicoPrestado.xsd";
                var cfg = new XmlReaderSettings()
                {
                    ValidationType = ValidationType.Schema
                };
                cfg.Schemas.Add(null, simpleTypes);
                cfg.Schemas.Add(null, complexTypes);
                cfg.Schemas.Add(null, consultarNfseServicoPrestado);
                cfg.Schemas.Add(null, signature);
                cfg.Schemas.XmlResolver = new XmlUrlResolver();
                var reader = XmlReader.Create(new StringReader(xml), cfg);
                var document = new XmlDocument();
                document.Load(reader);
                document.Validate((sender, args) =>
                {
                    if (args.Severity == XmlSeverityType.Error)
                    {
                        throw new Exception($"Error: {args.Message}. Location: {args.Exception.LinePosition}-{args.Exception.LineNumber}");
                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}