# Client Certificate Middleware

Este middleware captura o certificado do cliente durante o handshake TLS/SSL e o disponibiliza para uso na aplicação.

## Funcionalidades

- Captura automaticamente o certificado do cliente durante o handshake TLS
- Armazena o certificado no `HttpContext.Items` para acesso posterior
- Fornece extensões para facilitar o acesso ao certificado

## Configuração

O middleware já está configurado no `Program.cs` e o Kestrel está configurado para aceitar certificados de cliente.

### Modos de Certificado

O Kestrel está configurado com `ClientCertificateMode.AllowCertificate`, que significa:
- Aceita certificados de cliente quando fornecidos
- Não exige certificado (requisições sem certificado ainda funcionam)

Para exigir certificado obrigatório, altere para:
```csharp
httpsOptions.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
```

## Como Usar

### 1. Usando Extensões do HttpContext

```csharp
using NotaNacional.Web.Middleware;

public class MeuController : ControllerBase
{
    public IActionResult MinhaAction()
    {
        var httpContext = HttpContext;
        
        // Verifica se há certificado
        if (httpContext.HasClientCertificate())
        {
            // Obtém o certificado
            var certificate = httpContext.GetClientCertificate();
            
            if (certificate != null)
            {
                // Acessa propriedades do certificado
                var subject = certificate.Subject;
                var thumbprint = certificate.Thumbprint;
                var issuer = certificate.Issuer;
                
                // Usa o certificado para validação ou autenticação
            }
        }
        
        return Ok();
    }
}
```

### 2. Obtendo Informações do Certificado

```csharp
var certInfo = HttpContext.GetClientCertificateInfo();
// Retorna um objeto com: Subject, Issuer, Thumbprint, SerialNumber, NotBefore, NotAfter, HasPrivateKey
```

### 3. Usando no Serviço SOAP

```csharp
using NotaNacional.Web.Middleware;
using Microsoft.AspNetCore.Http;

public class NfseService : INfse
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public NfseService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public BaseResponse MinhaOperacao(object header, object body)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var clientCert = httpContext?.GetClientCertificate();
        
        if (clientCert != null)
        {
            // Usa o certificado para validação ou autenticação
            var clientSubject = clientCert.Subject;
            // ...
        }
        
        // Continua o processamento
    }
}
```

### 4. Usando Diretamente do Middleware

```csharp
using NotaNacional.Web.Middleware;

var certificate = ClientCertificateMiddleware.GetClientCertificate(HttpContext);
```

## Propriedades do Certificado Disponíveis

O `X509Certificate2` fornece várias propriedades úteis:

- `Subject` - Assunto do certificado (ex: "CN=Cliente, O=Empresa")
- `Issuer` - Emissor do certificado
- `Thumbprint` - Impressão digital (hash) do certificado
- `SerialNumber` - Número de série
- `NotBefore` - Data de início da validade
- `NotAfter` - Data de expiração
- `HasPrivateKey` - Indica se possui chave privada
- `PublicKey` - Chave pública do certificado

## Validação de Certificado

A validação atual aceita qualquer certificado válido. Para produção, implemente validação customizada:

```csharp
httpsOptions.ClientCertificateValidation = (certificate, chain, errors) =>
{
    // Validação customizada
    if (errors != System.Net.Security.SslPolicyErrors.None)
        return false;
    
    // Verifica se o certificado está em uma lista de confiança
    var thumbprint = certificate.GetCertHashString();
    var allowedThumbprints = new[] { "thumbprint1", "thumbprint2" };
    
    return allowedThumbprints.Contains(thumbprint);
};
```

## Testando com Certificado de Cliente

Para testar, você precisará:

1. Gerar um certificado de cliente
2. Instalá-lo no cliente (navegador ou aplicação)
3. Configurar o cliente para usar o certificado nas requisições

### Gerando Certificado de Teste

```bash
# Gerar certificado de cliente para teste
openssl req -new -x509 -keyout client-key.pem -out client-cert.pem -days 365 -nodes
```

## Notas Importantes

- O certificado só estará disponível em conexões HTTPS
- Certificados auto-assinados podem não passar na validação padrão
- Em produção, sempre valide adequadamente os certificados de cliente
- Considere usar uma CA (Certificate Authority) confiável para certificados de cliente
