using System.ServiceModel.Channels;
using System.Text;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using NotaNacional.Core.Base.Validator;
using NotaNacional.Web.Configuration;
using NotaNacional.Web.Middleware;
using NotaNacional.Web.Service;
using Serilog;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Configura Serilog
var loggerConfig = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console();

var writeToFile = builder.Configuration.GetValue<bool>("Logging:WriteToFile");
if (writeToFile)
{
    var filePath = builder.Configuration.GetValue<string>("Logging:FilePath") ?? "logs/log-.txt";
    loggerConfig.WriteTo.File(
        filePath,
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
}

Log.Logger = loggerConfig.CreateLogger();
builder.Host.UseSerilog();

// Configura o Kestrel para aceitar certificados de cliente (mutual TLS)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        // Lê configuração do appsettings para determinar o modo do certificado
        var requireCert = builder.Configuration.GetValue<bool>("ClientCertificate:RequireCertificate", false);
        var acceptSelfSigned = builder.Configuration.GetValue<bool>("ClientCertificate:AcceptSelfSigned", true);
        
        // Define o modo baseado na configuração
        // AllowCertificate: aceita certificado quando fornecido, mas não exige
        // RequireCertificate: exige certificado obrigatório
        httpsOptions.ClientCertificateMode = requireCert 
            ? ClientCertificateMode.RequireCertificate 
            : ClientCertificateMode.AllowCertificate;
        
        // Valida o certificado do cliente
        httpsOptions.ClientCertificateValidation = (certificate, chain, errors) =>
        {
            // Se não há certificado e estamos em modo RequireCertificate, rejeita
            if (certificate == null)
            {
                return false;
            }

            // Em desenvolvimento ou se configurado para aceitar auto-assinados
            // Aceita certificados mesmo com erros de validação da cadeia
            // Isso permite usar certificados auto-assinados para testes com SOAP UI
            if (builder.Environment.IsDevelopment() || acceptSelfSigned)
            {
                // Aceita qualquer certificado (incluindo auto-assinados)
                // O middleware irá fazer o log detalhado do certificado
                return true;
            }

            // Em produção, valida adequadamente
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

// Configura o forwarding de certificado do cliente (necessário quando atrás de IIS/reverse proxy)
builder.Services.AddCertificateForwarding(options =>
{
    options.CertificateHeader = "X-ARR-ClientCert";
});
builder.Services.AddRazorPages();

var app = builder.Build();

// Configura logger de diagnóstico para o BaseSchemaValidator
var schemaValidatorLogger = app.Services.GetService<ILoggerFactory>()?.CreateLogger("BaseSchemaValidator");
if (schemaValidatorLogger != null)
{
    BaseSchemaValidator.SetDiagnosticLogger(schemaValidatorLogger);
}

var settings = app.Configuration.GetSection("FileWSDL").Get<WsdlFileOptions>();
settings.AppPath = app.Environment.ContentRootPath;

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();

// Middleware para forwarding de certificado (IIS/reverse proxy)
app.UseCertificateForwarding();

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
