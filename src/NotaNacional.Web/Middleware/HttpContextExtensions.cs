using System.Security.Cryptography.X509Certificates;

namespace NotaNacional.Web.Middleware;

/// <summary>
/// Extensões para facilitar o acesso ao certificado do cliente no HttpContext.
/// </summary>
public static class HttpContextExtensions
{
    private const string ClientCertificateKey = "ClientCertificate";

    /// <summary>
    /// Obtém o certificado do cliente da requisição atual.
    /// </summary>
    /// <param name="context">O HttpContext da requisição</param>
    /// <returns>O certificado do cliente ou null se não estiver disponível</returns>
    public static X509Certificate2? GetClientCertificate(this HttpContext context)
    {
        if (context.Items.TryGetValue(ClientCertificateKey, out var cert) && cert is X509Certificate2 certificate)
        {
            return certificate;
        }

        return null;
    }

    /// <summary>
    /// Verifica se a requisição possui um certificado do cliente.
    /// </summary>
    /// <param name="context">O HttpContext da requisição</param>
    /// <returns>True se o certificado estiver disponível, caso contrário False</returns>
    public static bool HasClientCertificate(this HttpContext context)
    {
        return context.Items.ContainsKey(ClientCertificateKey) && 
               context.Items[ClientCertificateKey] is X509Certificate2;
    }

    /// <summary>
    /// Obtém informações do certificado do cliente em formato legível.
    /// </summary>
    /// <param name="context">O HttpContext da requisição</param>
    /// <returns>Um objeto anônimo com informações do certificado ou null</returns>
    public static object? GetClientCertificateInfo(this HttpContext context)
    {
        var cert = context.GetClientCertificate();
        if (cert == null)
        {
            return null;
        }

        return new
        {
            Subject = cert.Subject,
            Issuer = cert.Issuer,
            Thumbprint = cert.Thumbprint,
            SerialNumber = cert.SerialNumber,
            NotBefore = cert.NotBefore,
            NotAfter = cert.NotAfter,
            HasPrivateKey = cert.HasPrivateKey
        };
    }
}
