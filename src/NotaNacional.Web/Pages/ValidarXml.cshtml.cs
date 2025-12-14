using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NotaNacional.Web.Pages;

public class ValidarXmlModel : PageModel
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public ValidarXmlModel(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public string NfseServiceUrl { get; private set; } = "/nfse.asmx";

    public void OnGet()
    {
        var baseUrl = _configuration["NfseService:BaseUrl"];
        
        // Se não estiver configurado ou estiver em desenvolvimento, usar URL relativa
        if (!string.IsNullOrEmpty(baseUrl) && !_environment.IsDevelopment())
        {
            NfseServiceUrl = $"{baseUrl}/nfse.asmx";
        }
    }
}
