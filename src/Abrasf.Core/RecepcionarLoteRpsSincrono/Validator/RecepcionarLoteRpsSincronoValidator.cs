using System.Xml;
using System.Xml.Schema;
using Abrasf.Core.Base.Validator;
using Abrasf.Core.Helpers;

namespace Abrasf.Core.RecepcionarLoteRpsSincrono.Validator
{

    public class RecepcionarLoteRpsSincronoValidator : IRecepcionarLoteRpsSincronoValidator
    {
        private const string Operation = "RecepcionarLoteRpsSincrono";
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
                var signature = "Schemas/204/signature.xsd";
                var simpleTypes = "Schemas/204/simpleTypes.xsd";
                var complexTypes = "Schemas/204/complexTypes.xsd";
                var enviarLoteRpsSincrono = "Schemas/204/enviarLoteRpsSincrono.xsd";
                var cfg = new XmlReaderSettings()
                {
                    ValidationType = ValidationType.Schema
                };
                cfg.Schemas.Add(null, simpleTypes);
                cfg.Schemas.Add(null, complexTypes);
                cfg.Schemas.Add(null, enviarLoteRpsSincrono);
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}