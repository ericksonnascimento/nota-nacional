using Abrasf.Core.CancelarNfse.Repositories;
using Abrasf.Core.ConsultarDadosCadastrais.Repositories;
using Abrasf.Core.ConsultarLoteRps.Repositories;
using Abrasf.Core.ConsultarRpsDisponivel.Repositories;
using Abrasf.Core.ConsultarNfseFaixa.Repositories;
using Abrasf.Core.ConsultarNfsePorRps.Repositories;
using Abrasf.Core.ConsultarNfseServicoPrestado.Repositories;
using Abrasf.Core.ConsultarNfseServicoTomado.Repositories;
using Abrasf.Core.ConsultarUrlNfse.Repositories;
using Abrasf.Core.GerarNfse.Repositories;
using Abrasf.Core.RecepcionarLoteRps.Repositories;
using Abrasf.Core.RecepcionarLoteRpsSincrono.Repositories;
using Abrasf.Core.ServicoProcessamento.Repositories;
using Abrasf.Core.SubstituirNfse.Repositories;
using Abrasf.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Abrasf.Infra
{

    public static class Injector
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRecepcionarLoteRpsRepository, RecepcionarLoteRpsRepository>();
            services.AddScoped<IConsultarLoteRpsRepository, ConsultarLoteRpsRepository>();
            services.AddScoped<IConsultarNfseFaixaRepository, ConsultarNfseFaixaRepository>();
            services.AddScoped<IConsultarNfsePorRpsRepository, ConsultarNfsePorRpsRepository>();
            services.AddScoped<IConsultarNfseServicoPrestadoRepository, ConsultarNfseServicoPrestadoRepository>();
            services.AddScoped<IConsultarNfseServicoTomadoRepository, ConsultarNfseServicoTomadoRepository>();
            services.AddScoped<ICancelarNfseRepository, CancelarNfseRepository>();
            services.AddScoped<ISubstituirNfseRepository, SubstituirNfseRepository>();
            services.AddScoped<IGerarNfseRepository, GerarNfseRepository>();
            services.AddScoped<IRecepcionarLoteRpsSincronoRepository, RecepcionarLoteRpsSincronoRepository>();
            services.AddScoped<IConsultarUrlNfseRepository, ConsultarUrlNfseRepository>();
            services.AddScoped<IConsultarDadosCadastraisRepository, ConsultarDadosCadastraisRepository>();
            services.AddScoped<IConsultarRpsDisponivelRepository, ConsultarRpsDisponivelRepository>();  

            services.AddSingleton<IServicoProcessamentoRepository, ServicoProcessamentoRepository>();
        }
    }
}