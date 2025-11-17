using Abrasf.Core.ServicoProcessamento.Models;
using Abrasf.Core.ServicoProcessamento.Repositories;

namespace Abrasf.ServiceProcess;

public class PendingProcessWorker : BackgroundService
{
    private readonly ILogger<PendingProcessWorker> _logger;
    private readonly IServicoProcessamentoRepository _repository;

    private static Dictionary<MunicipioProcessamento, int> _citiesWithDuration =
        new()
        {
            { MunicipioProcessamento.Anapolis, 1500 },
            { MunicipioProcessamento.AparecidaDeGoiania, 1500 },
            { MunicipioProcessamento.Barcarena, 1500 },
            { MunicipioProcessamento.BarraMansa, 1500 },
            { MunicipioProcessamento.Brasilia, 1500 },
            { MunicipioProcessamento.CasimiroDeAbreu, 1500 },
            { MunicipioProcessamento.CruzAlta, 1500 },
            { MunicipioProcessamento.Cuiaba, 1500 },
            { MunicipioProcessamento.Dracena, 1500 },
            { MunicipioProcessamento.Dourados, 1500 },
            { MunicipioProcessamento.DuqueDeCaxias, 1500 },
            { MunicipioProcessamento.Goiania, 1500 },
            { MunicipioProcessamento.Itapora, 1500 },
            { MunicipioProcessamento.Itatiaia, 1500 },
            { MunicipioProcessamento.Itauna, 1500 },
            { MunicipioProcessamento.Macapa, 1500 },
            { MunicipioProcessamento.NovoHamburgo, 1500 },
            { MunicipioProcessamento.Oriximina, 1500 },
            { MunicipioProcessamento.PraiaGrande, 1500 },
            { MunicipioProcessamento.RibeiraoPreto, 1500 },
            { MunicipioProcessamento.SantaMaria, 1500 },
            { MunicipioProcessamento.SaoVicente, 1500 },
            { MunicipioProcessamento.Homologacao, 2000 },
            { MunicipioProcessamento.Apresentacao, 2000 },
        };

    public PendingProcessWorker(ILogger<PendingProcessWorker> logger, IServicoProcessamentoRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Processamento de notas iniciado em: {time}", DateTimeOffset.Now);
            var tasks = new Task[_citiesWithDuration.Count];
            var idx = 0;
            foreach (var city in _citiesWithDuration)
            {
                tasks[idx] = Process(stoppingToken, city.Key, city.Value);
                idx++;
            }
            await Task.WhenAll(tasks);
        }
    }
    private async Task Process(CancellationToken cancellationToken, MunicipioProcessamento city,
        int delayTimeInms = 1500)
    {
        try
        {
            while (true)
            {
                var pendingProcessing = _repository.PullPending(city);
                if (pendingProcessing.Count > 0)
                {
                    var grouped = pendingProcessing.GroupBy(item => item.InscricaoMunicipal)
                        .Select(item => new
                        {
                            item.Key,
                            Values = item.Select(x => x.NumeroProtocolo)
                        });
                    var tasks = new Task[grouped.Count()];
                    var idx = 0;
                    foreach (var item in grouped)
                    {
                        tasks[idx] = new Task(() => { RunAsync(city, item.Values.ToList()); });
                        idx++;
                    }
                    Parallel.ForEach(tasks, (t) => t.Start());
                    await Task.WhenAll(tasks);
                }

                await Task.Delay(delayTimeInms);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Erro while executing processing");

        }
    }
    private async Task RunAsync(MunicipioProcessamento city, List<Guid> protocols)
    {
        foreach (var protocol in protocols)
        {
            _repository.SendToProcess(city, protocol);
        }
    }
}