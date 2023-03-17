using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Configurations;

public static class ApplicationLayerConfiguration
{
    public static void ConfigureApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
