using System.ServiceModel.Channels;
using System.Text;
using NotaNacional.Web.Configuration;
using NotaNacional.Web.Service;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

var settings = app.Configuration.GetSection("FileWSDL").Get<WsdlFileOptions>();
settings.AppPath = app.Environment.ContentRootPath;

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

// Endpoint para retornar a URL do serviço SOAP baseado no ambiente
app.MapGet("/api/nfse-service-url", () =>
{
    var baseUrl = app.Configuration["NfseService:BaseUrl"];
    
    // Se não estiver configurado ou estiver em desenvolvimento, usar URL relativa
    if (string.IsNullOrEmpty(baseUrl) || app.Environment.IsDevelopment())
    {
        return Results.Ok(new { url = "/Nfse.asmx" });
    }
    
    return Results.Ok(new { url = $"{baseUrl}/nfse.asmx" });
});

var encoder = new SoapEncoderOptions()
{
    MessageVersion = MessageVersion.Soap11,
    WriteEncoding = Encoding.UTF8
};

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<INfse>("/Nfse.asmx", encoder, SoapSerializer.XmlSerializer, true, null, settings);
});

app.Run();
