using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using NotaNacional.Core.Helpers;

namespace NotaNacional.Core.Base.Validator
{
    public abstract class BaseSchemaValidator : IValidator
    {
        protected abstract string DefaultSchemaVersion { get; }
        protected abstract string OperationName { get; }
        
        /// <summary>
        /// Armazena os detalhes do último erro de validação quando captureErrorDetails é true
        /// </summary>
        protected string? LastValidationError { get; private set; }

        public ValidationResult Validate(object? data)
        {
            return Validate(data, null);
        }

        /// <summary>
        /// Valida o XML usando uma versão preferencial do cabeçalho quando disponível
        /// </summary>
        public ValidationResult Validate(object? data, string? preferredVersion)
        {
            return Validate(data, preferredVersion, false);
        }

        /// <summary>
        /// Valida o XML usando uma versão preferencial do cabeçalho quando disponível
        /// </summary>
        /// <param name="data">Dados XML para validar</param>
        /// <param name="preferredVersion">Versão preferencial do cabeçalho</param>
        /// <param name="captureErrorDetails">Se true, captura detalhes dos erros de validação (usado apenas pelo ValidarXml)</param>
        public ValidationResult Validate(object? data, string? preferredVersion, bool captureErrorDetails)
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
            
            // Extrair versão do XML, priorizando a versão preferencial do cabeçalho
            var schemaVersion = ExtractSchemaVersion(xml, preferredVersion) ?? DefaultSchemaVersion;
            
            if (!ValidateSchema(xml, schemaVersion, captureErrorDetails))
            {
                if (captureErrorDetails && !string.IsNullOrEmpty(LastValidationError))
                {
                    // Usar detalhes específicos do erro quando disponíveis (apenas para ValidarXml)
                    result.AddValidationError("E160", 
                        $"{OperationName} não está em conformidade com o schema XML (versão {schemaVersion}): {LastValidationError}");
                }
                else
                {
                    // Mensagem genérica para uso normal (outras operações)
                    result.AddValidationError("E160", $"{OperationName} deve obedecer a um schema válido.");
                }
            }

            result.IsValid = !result.Messages.Any();
            return result;
        }

        /// <summary>
        /// Extrai a versão do schema do XML procurando por versaoDados ou versao
        /// </summary>
        protected string? ExtractSchemaVersion(string xml)
        {
            return ExtractSchemaVersion(xml, null);
        }

        /// <summary>
        /// Extrai a versão do schema do XML, priorizando a versão preferencial do cabeçalho quando fornecida
        /// </summary>
        protected string? ExtractSchemaVersion(string xml, string? preferredVersion)
        {
            try
            {
                // Se temos uma versão preferencial do cabeçalho, usá-la primeiro
                if (!string.IsNullOrEmpty(preferredVersion))
                {
                    return MapVersionToSchemaPath(preferredVersion);
                }

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
                
                // Procurar em qualquer elemento com atributo versao (última opção)
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
            return ValidateSchema(xml, schemaVersion, false);
        }

        /// <summary>
        /// Obtém o nome do schema principal baseado na versão
        /// </summary>
        protected virtual string GetMainSchemaFileName(string schemaVersion)
        {
            return $"schema_{schemaVersion}.xsd";
        }

        /// <summary>
        /// Obtém o caminho base onde os schemas estão localizados
        /// </summary>
        protected virtual string GetSchemaBasePath()
        {
            // Tenta encontrar o diretório de execução da aplicação
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory ?? AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
            
            // Procura pelo diretório Schemas a partir do diretório base
            var schemaPath = Path.Combine(baseDirectory, "Schemas");
            if (Directory.Exists(schemaPath))
            {
                return schemaPath;
            }
            
            // Se não encontrar, tenta subir um nível (para projetos de teste ou desenvolvimento)
            var parentDir = Directory.GetParent(baseDirectory)?.FullName;
            if (parentDir != null)
            {
                schemaPath = Path.Combine(parentDir, "Schemas");
                if (Directory.Exists(schemaPath))
                {
                    return schemaPath;
                }
            }
            
            // Fallback: retorna o diretório base
            return baseDirectory;
        }

        /// <summary>
        /// Valida o schema XML, opcionalmente capturando detalhes dos erros
        /// </summary>
        /// <param name="xml">XML para validar</param>
        /// <param name="schemaVersion">Versão do schema a usar</param>
        /// <param name="captureErrorDetails">Se true, captura detalhes dos erros em LastValidationError</param>
        protected bool ValidateSchema(string xml, string schemaVersion, bool captureErrorDetails)
        {
            LastValidationError = null;
            var validationErrors = new List<string>();
            
            try
            {
                var schemaBasePath = GetSchemaBasePath();
                // Todos os schemas estão agora diretamente em Schemas/nacional/
                var basePath = Path.Combine(schemaBasePath, "nacional");
                var mainSchema = Path.Combine(basePath, GetMainSchemaFileName(schemaVersion));
                
                // Verificar se o schema principal existe
                if (!File.Exists(mainSchema))
                {
                    throw new FileNotFoundException($"Schema não encontrado: {mainSchema}");
                }
                
                var cfg = new XmlReaderSettings() 
                { 
                    ValidationType = ValidationType.Schema 
                };
                
                // Criar um resolver customizado que resolve caminhos relativos corretamente
                // O resolver usa a pasta nacional como base para resolver imports relativos (ex: xmldsig-core-schema.xsd)
                var resolver = new SchemaPathResolver(basePath);
                cfg.Schemas.XmlResolver = resolver;
                
                // Converter para caminho absoluto e adicionar o schema principal
                // O schema principal já inclui todas as definições necessárias
                var mainSchemaUri = new Uri(Path.GetFullPath(mainSchema));
                
                // Adicionar apenas o schema principal (ele já inclui tudo que precisa)
                cfg.Schemas.Add(null, mainSchemaUri.ToString());
                
                // Se precisamos capturar detalhes, configurar o ValidationEventHandler
                if (captureErrorDetails)
                {
                    cfg.ValidationEventHandler += (sender, args) =>
                    {
                        if (args.Severity == XmlSeverityType.Error)
                        {
                            var lineInfo = args.Exception != null 
                                ? $"Linha {args.Exception.LineNumber}, Posição {args.Exception.LinePosition}"
                                : "";
                            validationErrors.Add($"{lineInfo}: {args.Message}");
                        }
                    };
                }
                
                var reader = XmlReader.Create(new StringReader(xml), cfg);
                var document = new XmlDocument();
                document.Load(reader);
                
                document.Validate((sender, args) =>
                {
                    if (args.Severity == XmlSeverityType.Error)
                    {
                        if (captureErrorDetails)
                        {
                            var lineInfo = args.Exception != null 
                                ? $"Linha {args.Exception.LineNumber}, Posição {args.Exception.LinePosition}"
                                : "";
                            validationErrors.Add($"{lineInfo}: {args.Message}");
                        }
                        else
                        {
                            throw new Exception($"Error: {args.Message}. Location: {args.Exception?.LinePosition}-{args.Exception?.LineNumber}");
                        }
                    }
                });

                // Se capturou erros, armazenar para uso posterior
                if (captureErrorDetails && validationErrors.Any())
                {
                    LastValidationError = string.Join("; ", validationErrors);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                if (captureErrorDetails)
                {
                    LastValidationError = validationErrors.Any() 
                        ? string.Join("; ", validationErrors) + $"; Erro geral: {ex.Message}"
                        : $"Erro na validação do schema: {ex.Message}";
                }
                return false;
            }
        }
    }

    /// <summary>
    /// Resolver customizado para resolver caminhos de schemas relativos
    /// </summary>
    internal class SchemaPathResolver(string basePath) : XmlUrlResolver
    {
        private readonly string _basePath = basePath ?? throw new ArgumentNullException(nameof(basePath));

        public override object? GetEntity(Uri absoluteUri, string? role, Type? ofObjectToReturn)
        {
            try
            {
                // Se for um caminho de arquivo local, garantir que está resolvido corretamente
                if (absoluteUri.IsFile)
                {
                    var localPath = absoluteUri.LocalPath;
                    if (File.Exists(localPath))
                    {
                        return base.GetEntity(absoluteUri, role, ofObjectToReturn);
                    }
                }

                return base.GetEntity(absoluteUri, role, ofObjectToReturn);
            }
            catch
            {
                // Se falhar, tentar resolver em relação ao basePath
                var fileName = Path.GetFileName(absoluteUri.ToString());
                if (!string.IsNullOrEmpty(fileName))
                {
                    var resolvedPath = Path.Combine(_basePath, fileName);
                    if (File.Exists(resolvedPath))
                    {
                        var resolvedUri = new Uri(Path.GetFullPath(resolvedPath));
                        return base.GetEntity(resolvedUri, role, ofObjectToReturn);
                    }
                }
                throw;
            }
        }

        public override Uri ResolveUri(Uri? baseUri, string? relativeUri)
        {
            if (string.IsNullOrEmpty(relativeUri))
            {
                return base.ResolveUri(baseUri, relativeUri);
            }

            // Se há um baseUri, usar o diretório dele como base
            if (baseUri != null && baseUri.IsFile)
            {
                var baseDir = Path.GetDirectoryName(baseUri.LocalPath);
                if (!string.IsNullOrEmpty(baseDir))
                {
                    var resolvedPath = Path.Combine(baseDir, relativeUri);
                    if (File.Exists(resolvedPath))
                    {
                        return new Uri(Path.GetFullPath(resolvedPath));
                    }
                }
            }

            // Se não há baseUri ou não encontrou, tentar resolver em relação ao basePath
            var resolvedPathFromBase = Path.Combine(_basePath, relativeUri);
            if (File.Exists(resolvedPathFromBase))
            {
                return new Uri(Path.GetFullPath(resolvedPathFromBase));
            }

            return base.ResolveUri(baseUri, relativeUri);
        }
    }
}

