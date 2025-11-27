namespace NotaNacional.Web.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        Web.Injector.RegisterServices(services);
        Infra.Injector.RegisterInfrastructure(services);
    }
}