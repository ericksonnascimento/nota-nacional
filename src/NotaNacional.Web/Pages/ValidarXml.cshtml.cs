using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NotaNacional.Web.Pages;

public class ValidarXmlModel(IConfiguration configuration, IWebHostEnvironment environment)
    : PageModel
{
    public string NfseServiceUrl { get; private set; } = "/nfse.asmx";

    public void OnGet()
    {
        var baseUrl = configuration["NfseService:BaseUrl"];
        
        // Se não estiver configurado ou estiver em desenvolvimento, usar URL relativa
        if (!string.IsNullOrEmpty(baseUrl) && !environment.IsDevelopment())
        {
            NfseServiceUrl = $"{baseUrl}/nfse.asmx";
        }
    }
}
