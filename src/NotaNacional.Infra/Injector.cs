using NotaNacional.Core.CancelarNfse.Repositories;
using NotaNacional.Core.ConsultarDadosCadastrais.Repositories;
using NotaNacional.Core.ConsultarDpsDisponivel.Repositories;
using NotaNacional.Core.ConsultarNfseFaixa.Repositories;
using NotaNacional.Core.ConsultarNfseDps.Repositories;
using NotaNacional.Core.ConsultarNfseServicoPrestado.Repositories;
using NotaNacional.Core.ConsultarNfseServicoTomado.Repositories;
using NotaNacional.Core.ConsultarUrlNfse.Repositories;
using NotaNacional.Core.GerarNfse.Repositories;
using NotaNacional.Core.RecepcionarLoteDps.Repositories;
using NotaNacional.Core.ConsultarLoteDps.Repositories;
using NotaNacional.Core.RecepcionarLoteDpsSincrono.Repositories;
using NotaNacional.Core.ServicoProcessamento.Repositories;
using NotaNacional.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace NotaNacional.Infra
{

    public static class Injector
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRecepcionarLoteDpsRepository, RecepcionarLoteDpsRepository>();
            services.AddScoped<IConsultarLoteDpsRepository, ConsultarLoteDpsRepository>();
            services.AddScoped<IConsultarNfseFaixaRepository, ConsultarNfseFaixaRepository>();
            services.AddScoped<IConsultarNfseDpsRepository, ConsultarNfseDpsRepository>();
            services.AddScoped<IConsultarNfseServicoPrestadoRepository, ConsultarNfseServicoPrestadoRepository>();
            services.AddScoped<IConsultarNfseServicoTomadoRepository, ConsultarNfseServicoTomadoRepository>();
            services.AddScoped<ICancelarNfseRepository, CancelarNfseRepository>();
            // SubstituirNfse não existe no padrão Nacional v101 - removido
            services.AddScoped<IGerarNfseRepository, GerarNfseRepository>();
            services.AddScoped<IRecepcionarLoteDpsSincronoRepository, RecepcionarLoteDpsSincronoRepository>();
            services.AddScoped<IConsultarUrlNfseRepository, ConsultarUrlNfseRepository>();
            services.AddScoped<IConsultarDadosCadastraisRepository, ConsultarDadosCadastraisRepository>();
            services.AddScoped<IConsultarDpsDisponivelRepository, ConsultarDpsDisponivelRepository>();  

            services.AddSingleton<IServicoProcessamentoRepository, ServicoProcessamentoRepository>();
        }
    }
}