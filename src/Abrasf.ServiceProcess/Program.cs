using Abrasf.ServiceProcess;
using Serilog;

var host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureAppConfiguration((builderContext, config) =>
    {
        config.SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory);
    })
    .ConfigureServices(services =>
    {
        Abrasf.Infra.Injector.RegisterInfrastructure(services);
        services.AddHostedService<PendingProcessWorker>();
        services.AddLogging(configure => configure.AddSerilog());

    })
    .UseSerilog((hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
    })
    .Build();

await host.RunAsync();
