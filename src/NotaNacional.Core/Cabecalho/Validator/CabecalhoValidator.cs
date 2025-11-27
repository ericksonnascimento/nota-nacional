using System.Xml;
using System.Xml.Schema;
using NotaNacional.Core.Base.Validator;
using NotaNacional.Core.Helpers;

namespace NotaNacional.Core.Cabecalho.Validator
{
    public class CabecalhoValidator : ICabecalhoValidator
    {
        public ValidationResult Validate(object? data)
        {
            var result = new ValidationResult();
            if (data is null)
            {
                result.AddValidationError("E160", "Cabeçalho deve ser informado.");
            }

            if (data is not XmlNode[])
            {
                result.AddValidationError("E160", "Cabecalho deve ser um XML válido.");
            }

            var header = ParseHelper.GetXml(data);
            if (!ValidateSchema(header))
            {
                result.AddValidationError("E160", "Cabecalho deve obedecer a um schema válido.");
            }

            result.IsValid = !result.Messages.Any();
            return result;
        }

        private bool ValidateSchema(string xml)
        {
            try
            {
                var signature = "Schemas/nacional/xmldsig-core-schema.xsd";
                var simpleTypes = "Schemas/nacional/simpleTypes.xsd";
                var complexTypes = "Schemas/nacional/complexTypes.xsd";
                var schema = "Schemas/nacional/cabecalho.xsd";
                var cfg = new XmlReaderSettings() { ValidationType = ValidationType.Schema };
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
                        throw new Exception(args.Message);
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
