using System.Linq;
using System.Xml;
using System.Xml.Schema;
using NotaNacional.Core.Helpers;

namespace NotaNacional.Core.Base.Validator
{
    public abstract class BaseSchemaValidator : IValidator
    {
        protected abstract string SchemaVersion { get; }
        protected abstract string SchemaFileName { get; }
        protected abstract string OperationName { get; }

        public ValidationResult Validate(object? data)
        {
            var result = new ValidationResult();
            if (data is null)
            {
                result.AddValidationError("E160", $"{OperationName} deve ser informado.");
            }

            if (data is not XmlNode[])
            {
                result.AddValidationError("E160", $"{OperationName} deve ser um XML válido.");
            }

            var xml = ParseHelper.GetXml(data);
            if (!ValidateSchema(xml))
            {
                result.AddValidationError("E160", $"{OperationName} deve obedecer a um schema válido.");
            }

            result.IsValid = !result.Messages.Any();
            return result;
        }

        protected bool ValidateSchema(string xml)
        {
            try
            {
                var basePath = $"Schemas/nacional/{SchemaVersion}";
                var signature = $"{basePath}/xmldsig-core-schema.xsd";
                var simpleTypes = $"{basePath}/simpleTypes.xsd";
                var complexTypes = $"{basePath}/complexTypes.xsd";
                var schema = $"{basePath}/{SchemaFileName}";
                
                var cfg = new XmlReaderSettings() 
                { 
                    ValidationType = ValidationType.Schema 
                };
                
                cfg.Schemas.Add(null, simpleTypes);
                cfg.Schemas.Add(null, complexTypes);
                cfg.Schemas.Add(null, schema);
                cfg.Schemas.Add(null, signature);
                cfg.Schemas.XmlResolver = new XmlUrlResolver();
                
                var reader = XmlReader.Create(new StringReader(xml), cfg);
                var document = new XmlDocument();
                document.Load(reader);
                document.Validate((sender, args) =>
                {
                    if (args.Severity == XmlSeverityType.Error)
                    {
                        throw new Exception($"Error: {args.Message}. Location: {args.Exception?.LinePosition}-{args.Exception?.LineNumber}");
                    }
                });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

