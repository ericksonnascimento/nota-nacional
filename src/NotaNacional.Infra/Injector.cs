using NotaNacional.Core.CancelarNfse.Repositories;
using NotaNacional.Core.ConsultarDadosCadastrais.Repositories;
using NotaNacional.Core.ConsultarLoteRps.Repositories;
using NotaNacional.Core.ConsultarRpsDisponivel.Repositories;
using NotaNacional.Core.ConsultarNfseFaixa.Repositories;
using NotaNacional.Core.ConsultarNfsePorRps.Repositories;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Repositories;
using NotaNacional.Core.ConsultarNfseServicoTomado.Repositories;
using NotaNacional.Core.ConsultarUrlNfse.Repositories;
using NotaNacional.Core.GerarNfse.Repositories;
using NotaNacional.Core.RecepcionarLoteRps.Repositories;
using NotaNacional.Core.RecepcionarLoteRpsSincrono.Repositories;
using NotaNacional.Core.ServicoProcessamento.Repositories;
using NotaNacional.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace NotaNacional.Infra
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
            // SubstituirNfse não existe no padrão Nacional v101 - removido
            services.AddScoped<IGerarNfseRepository, GerarNfseRepository>();
            services.AddScoped<IRecepcionarLoteRpsSincronoRepository, RecepcionarLoteRpsSincronoRepository>();
            services.AddScoped<IConsultarUrlNfseRepository, ConsultarUrlNfseRepository>();
            services.AddScoped<IConsultarDadosCadastraisRepository, ConsultarDadosCadastraisRepository>();
            services.AddScoped<IConsultarRpsDisponivelRepository, ConsultarRpsDisponivelRepository>();  

            services.AddSingleton<IServicoProcessamentoRepository, ServicoProcessamentoRepository>();
        }
    }
}