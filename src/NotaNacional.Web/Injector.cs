using NotaNacional.Core.Cabecalho.Validator;
using NotaNacional.Core.CancelarNfse.Handlers;
using NotaNacional.Core.CancelarNfse.Validator;
using NotaNacional.Core.ConsultarDadosCadastrais.Handlers;
using NotaNacional.Core.ConsultarDadosCadastrais.Validator;
using NotaNacional.Core.ConsultarLoteDps.Handlers;
using NotaNacional.Core.ConsultarLoteDps.Validator;
using NotaNacional.Core.ConsultarNfseFaixa.Handlers;
using NotaNacional.Core.ConsultarNfseFaixa.Validator;
using NotaNacional.Core.ConsultarNfseDps.Handlers;
using NotaNacional.Core.ConsultarNfseDps.Validator;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Handlers;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Validator;
using NotaNacional.Core.ConsultarNfseServicoTomado.Handlers;
using NotaNacional.Core.ConsultarNfseServicoTomado.Validator;
using NotaNacional.Core.ConsultarUrlNfse.Handlers;
using NotaNacional.Core.ConsultarUrlNfse.Validator;
using NotaNacional.Core.ConsultarDpsDisponivel.Handlers;
using NotaNacional.Core.ConsultarDpsDisponivel.Validator;
using NotaNacional.Core.GerarNfse.Handlers;
using NotaNacional.Core.GerarNfse.Validator;
using NotaNacional.Core.RecepcionarLoteDps.Handlers;
using NotaNacional.Core.RecepcionarLoteDps.Repositories;
using NotaNacional.Core.RecepcionarLoteDps.Validator;
using NotaNacional.Core.RecepcionarLoteDpsSincrono.Handlers;
using NotaNacional.Core.RecepcionarLoteDpsSincrono.Validator;
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
        
        //ConsultarLoteDps
        services.AddScoped<IConsultarLoteDpsValidator, ConsultarLoteDpsValidator>();
        services.AddScoped<IConsultarLoteDpsHandler, ConsultarLoteDpsHandler>();
        
        //ConsultarNfseFaixa
        services.AddScoped<IConsultarNfseFaixaValidator, ConsultarNfseFaixaValidator>();
        services.AddScoped<IConsultarNfseFaixaHandler, ConsultarNfseFaixaHandler>();
        
        //ConsultarNfseDps
        services.AddScoped<IConsultarNfseDpsValidator, ConsultarNfseDpsValidator>();
        services.AddScoped<IConsultarNfseDpsHandler, ConsultarNfseDpsHandler>();
        
        //ConsultarNfseServicoPrestado
        services.AddScoped<IConsultarNfseServicoPrestadoValidator, ConsultarNfseServicoPrestadoValidator>();
        services.AddScoped<IConsultarNfseServicoPrestadoHandler, ConsultarNfseServicoPrestadoHandler>();
        
        //ConsultarNfseServicoTomado
        services.AddScoped<IConsultarNfseServicoTomadoValidator, ConsultarNfseServicoTomadoValidator>();
        services.AddScoped<IConsultarNfseServicoTomadoHandler, ConsultarNfseServicoTomadoHandler>();
        
        //GerarNfse
        services.AddScoped<IGerarNfseValidator, GerarNfseValidator>();
        services.AddScoped<IGerarNfseHandler, GerarNfseHandler>();
        
        //RecepcionarLoteDps
        services.AddScoped<IRecepcionarLoteDpsValidator, RecepcionarLoteDpsValidator>();
        services.AddScoped<IRecepcionarLoteDpsRepository, RecepcionarLoteDpsRepository>();
        services.AddScoped<IRecepcionarLoteDpsHandler, RecepcionarLoteDpsHandler>();
        
        
        //RecepcionarLoteDpsSincrono
        services.AddScoped<IRecepcionarLoteDpsSincronoValidator, RecepcionarLoteDpsSincronoValidator>();
        services.AddScoped<IRecepcionarLoteDpsSincronoHandler, RecepcionarLoteDpsSincronoHandler>();

        //ConsultarUrlNfse
        services.AddScoped<IConsultarUrlNfseValidator, ConsultarUrlNfseValidator>();
        services.AddScoped<IConsultarUrlNfseHandler, ConsultarUrlNfseHandler>();

        //ConsultarDadosCadastrais
        services.AddScoped<IConsultarDadosCadastraisValidator, ConsultarDadosCadastraisValidator>();
        services.AddScoped<IConsultarDadosCadastraisHandler, ConsultarDadosCadastraisHandler>();

        //ConsultarDpsDisponivel
        services.AddScoped<IConsultarDpsDisponivelValidator, ConsultarDpsDisponivelValidator>();
        services.AddScoped<IConsultarDpsDisponivelHandler, ConsultarDpsDisponivelHandler>();

        //Main
        services.AddScoped<INfse, Nfse>();
    }
}