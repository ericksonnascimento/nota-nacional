using System.Security.Cryptography.X509Certificates;

namespace NotaNacional.Web.Middleware;

/// <summary>
/// Exemplos de como usar o certificado do cliente em diferentes cenários.
/// Este arquivo serve apenas como referência e não deve ser compilado.
/// </summary>
public class ExemploUso
{
    // Exemplo 1: Usando em um Controller ou PageModel
    public class ExemploController
    {
        public IResult MinhaAction(HttpContext context)
        {
            // Verifica se há certificado do cliente
            if (context.HasClientCertificate())
            {
                var cert = context.GetClientCertificate();
                
                if (cert != null)
                {
                    // Acessa propriedades do certificado
                    var subject = cert.Subject;
                    var thumbprint = cert.Thumbprint;
                    var issuer = cert.Issuer;
                    var serialNumber = cert.SerialNumber;
                    
                    // Usa para autenticação/autorização
                    // Exemplo: verificar se o certificado está em uma lista permitida
                    var allowedThumbprints = new[] { "thumbprint1", "thumbprint2" };
                    if (allowedThumbprints.Contains(thumbprint))
                    {
                        // Cliente autorizado
                        return Results.Ok(new { message = "Autorizado", client = subject });
                    }
                }
            }
            
            return Results.Unauthorized();
        }
    }

    // Exemplo 2: Usando em um serviço com IHttpContextAccessor
    public class ExemploService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExemploService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ObterClienteDoCertificado()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
                return "Desconhecido";

            var cert = context.GetClientCertificate();
            if (cert == null)
                return "Sem certificado";

            // Extrai o CN (Common Name) do Subject
            var subjectParts = cert.Subject.Split(',');
            var cn = subjectParts.FirstOrDefault(p => p.Trim().StartsWith("CN="));
            
            return cn?.Replace("CN=", "").Trim() ?? cert.Subject;
        }
    }

    // Exemplo 3: Validação customizada do certificado
    public static class CertificadoValidator
    {
        public static bool ValidarCertificado(X509Certificate2? certificate)
        {
            if (certificate == null)
                return false;

            // Verifica se o certificado não expirou
            if (DateTime.Now > certificate.NotAfter || DateTime.Now < certificate.NotBefore)
                return false;

            // Verifica se o certificado tem uma extensão específica
            // Exemplo: verificar se tem Extended Key Usage para Client Authentication
            var ekuExtension = certificate.Extensions.OfType<X509EnhancedKeyUsageExtension>().FirstOrDefault();
            if (ekuExtension != null)
            {
                var oid = new System.Security.Cryptography.Oid("1.3.6.1.5.5.7.3.2"); // Client Authentication
                var hasClientAuth = ekuExtension.EnhancedKeyUsages.Cast<System.Security.Cryptography.Oid>()
                    .Any(x => x.Value == oid.Value);
                
                if (!hasClientAuth)
                    return false;
            }

            return true;
        }

        public static bool VerificarThumbprintPermitido(X509Certificate2? certificate, string[] thumbprintsPermitidos)
        {
            if (certificate == null)
                return false;

            return thumbprintsPermitidos.Contains(certificate.Thumbprint, StringComparer.OrdinalIgnoreCase);
        }
    }

    // Exemplo 4: Logging do certificado (para auditoria)
    public static class CertificadoLogger
    {
        public static void LogCertificadoInfo(HttpContext context, ILogger logger)
        {
            var cert = context.GetClientCertificate();
            if (cert != null)
            {
                var info = context.GetClientCertificateInfo();
                logger.LogInformation("Certificado do cliente: {CertInfo}", info);
            }
            else
            {
                logger.LogWarning("Requisição sem certificado do cliente de {RemoteIp}", 
                    context.Connection.RemoteIpAddress);
            }
        }
    }
}
