using System.ServiceModel.Channels;
using System.Text;
using NotaNacional.Web.Configuration;
using NotaNacional.Web.Service;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();

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
