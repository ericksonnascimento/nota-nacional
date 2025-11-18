using Abrasf.Core.Cabecalho.Validator;
using Abrasf.Core.CancelarNfse.Handlers;
using Abrasf.Core.CancelarNfse.Validator;
using Abrasf.Core.ConsultarDadosCadastrais.Handlers;
using Abrasf.Core.ConsultarDadosCadastrais.Validator;
using Abrasf.Core.ConsultarLoteRps.Handlers;
using Abrasf.Core.ConsultarLoteRps.Validator;
using Abrasf.Core.ConsultarNfseFaixa.Handlers;
using Abrasf.Core.ConsultarNfseFaixa.Validator;
using Abrasf.Core.ConsultarNfsePorRps.Handlers;
using Abrasf.Core.ConsultarNfsePorRps.Validator;
using Abrasf.Core.ConsultarNfseServicoPrestado.Handlers;
using Abrasf.Core.ConsultarNfseServicoPrestado.Validator;
using Abrasf.Core.ConsultarNfseServicoTomado.Handlers;
using Abrasf.Core.ConsultarNfseServicoTomado.Validator;
using Abrasf.Core.ConsultarUrlNfse.Handlers;
using Abrasf.Core.ConsultarUrlNfse.Validator;
using Abrasf.Core.ConsultarRpsDisponivel.Handlers;
using Abrasf.Core.ConsultarRpsDisponivel.Validator;
using Abrasf.Core.GerarNfse.Handlers;
using Abrasf.Core.GerarNfse.Validator;
using Abrasf.Core.RecepcionarLoteRps.Handlers;
using Abrasf.Core.RecepcionarLoteRps.Repositories;
using Abrasf.Core.RecepcionarLoteRps.Validator;
using Abrasf.Core.RecepcionarLoteRpsSincrono.Handlers;
using Abrasf.Core.RecepcionarLoteRpsSincrono.Validator;
// SubstituirNfse não existe no padrão Nacional v101 - removido

using Abrasf.Infra.Repositories;
using Abrasf.Web.Service;

namespace Abrasf.Web;

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