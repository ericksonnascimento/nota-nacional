using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using NotaNacional.Core.Helpers;

namespace NotaNacional.Core.Base.Validator
{
    public abstract class BaseSchemaValidator : IValidator
    {
        protected abstract string DefaultSchemaVersion { get; }
        protected abstract string SchemaFileName { get; }
        protected abstract string OperationName { get; }

        public ValidationResult Validate(object? data)
        {
            var result = new ValidationResult();
            if (data is null)
            {
                result.AddValidationError("E160", $"{OperationName} deve ser informado.");
                return result;
            }

            if (data is not XmlNode[])
            {
                result.AddValidationError("E160", $"{OperationName} deve ser um XML válido.");
                return result;
            }

            var xml = ParseHelper.GetXml(data);
            
            // Extrair versão do XML
            var schemaVersion = ExtractSchemaVersion(xml) ?? DefaultSchemaVersion;
            
            if (!ValidateSchema(xml, schemaVersion))
            {
                result.AddValidationError("E160", $"{OperationName} deve obedecer a um schema válido.");
            }

            result.IsValid = !result.Messages.Any();
            return result;
        }

        /// <summary>
        /// Extrai a versão do schema do XML procurando por versaoDados ou versao
        /// </summary>
        protected string? ExtractSchemaVersion(string xml)
        {
            try
            {
                var doc = XDocument.Parse(xml);
                
                // Procurar por versaoDados (elemento) - busca em todos os namespaces
                var versaoDados = doc.Descendants()
                    .FirstOrDefault(e => e.Name.LocalName == "versaoDados")?.Value;
                if (!string.IsNullOrEmpty(versaoDados))
                {
                    return MapVersionToSchemaPath(versaoDados);
                }
                
                // Procurar por versao (atributo no elemento cabecalho) - busca em todos os namespaces
                var cabecalho = doc.Descendants()
                    .FirstOrDefault(e => e.Name.LocalName == "cabecalho");
                if (cabecalho != null)
                {
                    var versaoAttr = cabecalho.Attribute("versao")?.Value;
                    if (!string.IsNullOrEmpty(versaoAttr))
                    {
                        return MapVersionToSchemaPath(versaoAttr);
                    }
                }
                
                // Procurar em qualquer elemento com atributo versao
                var versaoInAnyElement = doc.Descendants()
                    .FirstOrDefault(e => e.Attribute("versao") != null)?
                    .Attribute("versao")?.Value;
                if (!string.IsNullOrEmpty(versaoInAnyElement))
                {
                    return MapVersionToSchemaPath(versaoInAnyElement);
                }
            }
            catch
            {
                // Se não conseguir parsear, retorna null para usar default
            }
            
            return null;
        }

        /// <summary>
        /// Mapeia a versão (ex: "1.00", "1.01") para o caminho do schema (ex: "v100", "v101")
        /// </summary>
        protected string MapVersionToSchemaPath(string version)
        {
            return version switch
            {
                "1.00" => "v100",
                "1.01" => "v101",
                _ => DefaultSchemaVersion // Fallback para versão padrão se não reconhecida
            };
        }

        protected bool ValidateSchema(string xml, string schemaVersion)
        {
            try
            {
                var basePath = $"Schemas/nacional/{schemaVersion}";
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

