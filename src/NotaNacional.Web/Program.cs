using System.ServiceModel.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using NotaNacional.Web.Configuration;
using NotaNacional.Web.Middleware;
using NotaNacional.Web.Service;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Configura o Kestrel para aceitar certificados de cliente (mutual TLS)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        // Aceita certificados de cliente, mas não exige (AllowCertificate)
        // Para exigir certificado, use RequireCertificate
        httpsOptions.ClientCertificateMode = ClientCertificateMode.AllowCertificate;
        
        // Valida o certificado do cliente
        httpsOptions.ClientCertificateValidation = (certificate, chain, errors) =>
        {
            // Aqui você pode implementar validação customizada do certificado
            // Por padrão, retorna true para aceitar qualquer certificado válido
            // Em produção, implemente validação adequada (ex: verificar CA, revogação, etc.)
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
    });
});

builder.Services.AddSoapCore();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();

var app = builder.Build();

var settings = app.Configuration.GetSection("FileWSDL").Get<WsdlFileOptions>();
settings.AppPath = app.Environment.ContentRootPath;

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();

// Middleware para capturar certificado do cliente
app.UseMiddleware<ClientCertificateMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

var encoder = new SoapEncoderOptions()
{
    MessageVersion = MessageVersion.Soap11,
    WriteEncoding = Encoding.UTF8
};

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<INfse>("/Nfse.asmx", encoder, SoapSerializer.XmlSerializer, true, null, settings);
    endpoints.MapRazorPages();
});

app.Run();
