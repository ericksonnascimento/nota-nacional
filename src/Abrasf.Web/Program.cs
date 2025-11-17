using System.ServiceModel.Channels;
using System.Text;
using Abrasf.Web.Configuration;
using Abrasf.Web.Service;
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

app.UseRouting();

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
