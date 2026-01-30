using System.Security.Cryptography.X509Certificates;

namespace NotaNacional.Web.Middleware;

/// <summary>
/// Middleware para capturar e disponibilizar o certificado do cliente durante o handshake TLS/SSL.
/// O certificado é armazenado no HttpContext.Items para acesso posterior.
/// </summary>
public class ClientCertificateMiddleware
{
    private readonly RequestDelegate _next;
    private const string ClientCertificateKey = "ClientCertificate";

    public ClientCertificateMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Obtém o certificado do cliente da conexão
        // O certificado pode estar disponível diretamente na conexão após o handshake TLS
        var clientCertificate = context.Connection.ClientCertificate;

        // Se não estiver disponível diretamente, tenta obter da requisição
        if (clientCertificate == null)
        {
            // Em alguns casos, o certificado pode estar no header X-ARR-ClientCert (Azure/IIS)
            if (context.Request.Headers.TryGetValue("X-ARR-ClientCert", out var certHeader))
            {
                try
                {
                    var certBytes = Convert.FromBase64String(certHeader.ToString());
                    clientCertificate = new X509Certificate2(certBytes);
                }
                catch
                {
                    // Ignora erros ao tentar parsear o certificado do header
                }
            }
        }

        // Se ainda não tiver o certificado, tenta obter da conexão de forma assíncrona
        if (clientCertificate == null && context.Request.IsHttps)
        {
            try
            {
                // Aguarda o certificado estar disponível (pode ser necessário em alguns casos)
                await Task.Yield();
                clientCertificate = context.Connection.ClientCertificate;
            }
            catch
            {
                // Ignora erros
            }
        }

        if (clientCertificate != null)
        {
            // Converte para X509Certificate2 se necessário
            X509Certificate2? cert2 = null;
            try
            {
                if (clientCertificate is X509Certificate2 cert)
                {
                    cert2 = cert;
                }
                else
                {
                    cert2 = new X509Certificate2(clientCertificate);
                }
            }
            catch
            {
                // Se não conseguir converter, tenta usar o certificado original
                cert2 = clientCertificate as X509Certificate2 ?? new X509Certificate2(clientCertificate);
            }

            // Armazena o certificado no HttpContext.Items para acesso posterior
            if (cert2 != null)
            {
                context.Items[ClientCertificateKey] = cert2;
            }
        }

        // Continua o pipeline
        await _next(context);
    }

    /// <summary>
    /// Obtém o certificado do cliente do HttpContext.
    /// </summary>
    /// <param name="context">O HttpContext da requisição</param>
    /// <returns>O certificado do cliente ou null se não estiver disponível</returns>
    public static X509Certificate2? GetClientCertificate(HttpContext context)
    {
        if (context.Items.TryGetValue(ClientCertificateKey, out var cert) && cert is X509Certificate2 certificate)
        {
            return certificate;
        }

        return null;
    }
}
