using NotaNacional.ServiceProcess;
using Serilog;

var host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureAppConfiguration((builderContext, config) =>
    {
        config.SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory);
    })
    .ConfigureServices(services =>
    {
        NotaNacional.Infra.Injector.RegisterInfrastructure(services);
        services.AddHostedService<PendingProcessWorker>();
        services.AddLogging(configure => configure.AddSerilog());

    })
    .UseSerilog((hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);

        var writeToFile = hostingContext.Configuration.GetValue<bool>("Logging:WriteToFile");
        if (writeToFile)
        {
            var filePath = hostingContext.Configuration.GetValue<string>("Logging:FilePath") ?? "logs/log-.txt";
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            var fullPath = Path.Combine(basePath, filePath);

            loggerConfiguration.WriteTo.File(
                fullPath,
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
        }
    })
    .Build();

await host.RunAsync();
