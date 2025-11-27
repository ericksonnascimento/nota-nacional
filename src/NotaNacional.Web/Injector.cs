using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.CancelarNfse.Handlers;
using NotaNacional.Core.CancelarNfse.Validator;
using NotaNacional.Core.ConsultarDadosCadastrais.Handlers;
using NotaNacional.Core.ConsultarDadosCadastrais.Validator;
using NotaNacional.Core.ConsultarLoteRps.Handlers;
using NotaNacional.Core.ConsultarLoteRps.Validator;
using NotaNacional.Core.ConsultarNfseFaixa.Handlers;
using NotaNacional.Core.ConsultarNfseFaixa.Validator;
using NotaNacional.Core.ConsultarNfsePorRps.Handlers;
using NotaNacional.Core.ConsultarNfsePorRps.Validator;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Handlers;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Validator;
using NotaNacional.Core.ConsultarNfseServicoTomado.Handlers;
using NotaNacional.Core.ConsultarNfseServicoTomado.Validator;
using NotaNacional.Core.ConsultarUrlNfse.Handlers;
using NotaNacional.Core.ConsultarUrlNfse.Validator;
using NotaNacional.Core.ConsultarRpsDisponivel.Handlers;
using NotaNacional.Core.ConsultarRpsDisponivel.Validator;
using NotaNacional.Core.GerarNfse.Handlers;
using NotaNacional.Core.GerarNfse.Validator;
using NotaNacional.Core.RecepcionarLoteRps.Handlers;
using NotaNacional.Core.RecepcionarLoteRps.Repositories;
using NotaNacional.Core.RecepcionarLoteRps.Validator;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Handlers;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Validator;
// SubstituirNfse não existe no padrão Nacional v101 - removido

using NotaNacional.Infra.Repositories;
using NotaNacional.Web.Service;

namespace NotaNacional.Web;

public static class Injector
{
    public static void RegisterServices(IServiceCollection services)
    {
        //Cabecalho
        services.AddScoped<ICabecalhoValidator, CabecalhoValidator>();
        
        //CancelarNfse
        services.AddScoped<ICancelarNfseValidator, CancelarNfseValidator>();
        services.AddScoped<ICancelarNfseHandler, CancelarNfseHandler>();
        
        //ConsultarLoteRps
        services.AddScoped<IConsultarLoteRpsValidator, ConsultarLoteRpsValidator>();
        services.AddScoped<IConsultarLoteRpsHandler, ConsultarLoteRpsHandler>();
        
        //ConsultarNfseFaixa
        services.AddScoped<IConsultarNfseFaixaValidator, ConsultarNfseFaixaValidator>();
        services.AddScoped<IConsultarNfseFaixaHandler, ConsultarNfseFaixaHandler>();
        
        //ConsultarNfsePorRps
        services.AddScoped<IConsultarNfsePorRpsValidator, ConsultarNfsePorRpsValidator>();
        services.AddScoped<IConsultarNfsePorRpsHandler, ConsultarNfsePorRpsHandler>();
        
        //ConsultarNfseServicoPrestado
        services.AddScoped<IConsultarNfseServicoPrestadoValidator, ConsultarNfseServicoPrestadoValidator>();
        services.AddScoped<IConsultarNfseServicoPrestadoHandler, ConsultarNfseServicoPrestadoHandler>();
        
        //ConsultarNfseServicoTomado
        services.AddScoped<IConsultarNfseServicoTomadoValidator, ConsultarNfseServicoTomadoValidator>();
        services.AddScoped<IConsultarNfseServicoTomadoHandler, ConsultarNfseServicoTomadoHandler>();
        
        //GerarNfse
        services.AddScoped<IGerarNfseValidator, GerarNfseValidator>();
        services.AddScoped<IGerarNfseHandler, GerarNfseHandler>();
        
        //RecepcionarLoteRps
        services.AddScoped<IRecepcionarLoteRpsValidator, RecepcionarLoteRpsValidator>();
        services.AddScoped<IRecepcionarLoteRpsRepository, RecepcionarLoteRpsRepository>();
        services.AddScoped<IRecepcionarLoteRpsHandler, RecepcionarLoteRpsHandler>();
        
        
        //RecepcionarLoteRpsSincrono
        services.AddScoped<IRecepcionarLoteRpsSincronoValidator, RecepcionarLoteRpsSincronoValidator>();
        services.AddScoped<IRecepcionarLoteRpsSincronoHandler, RecepcionarLoteRpsSincronoHandler>();

        //ConsultarUrlNfse
        services.AddScoped<IConsultarUrlNfseValidator, ConsultarUrlNfseValidator>();
        services.AddScoped<IConsultarUrlNfseHandler, ConsultarUrlNfseHandler>();

        //ConsultarDadosCadastrais
        services.AddScoped<IConsultarDadosCadastraisValidator, ConsultarDadosCadastraisValidator>();
        services.AddScoped<IConsultarDadosCadastraisHandler, ConsultarDadosCadastraisHandler>();

        //ConsultarRpsDisponivel
        services.AddScoped<IConsultarRpsDisponivelValidator, ConsultarRpsDisponivelValidator>();
        services.AddScoped<IConsultarRpsDisponivelHandler, ConsultarRpsDisponivelHandler>();

        //Main
        services.AddScoped<INfse, Nfse>();
    }
}