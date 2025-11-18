using System.Xml;
using System.Xml.Schema;
using Abrasf.Core.Base.Validator;
using Abrasf.Core.Helpers;

namespace Abrasf.Core.Cabecalho.Validator
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
                var schema = "Schemas/nacional/cabecalho.xsd";
                var cfg = new XmlReaderSettings() { ValidationType = ValidationType.Schema };
                cfg.Schemas.Add(null, schema);
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
