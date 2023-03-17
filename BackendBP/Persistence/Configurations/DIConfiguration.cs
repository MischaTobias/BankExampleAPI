using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Implements.Repositories;
using System.Reflection;

namespace Persistence.Configurations;

public static class DIConfiguration
{
    public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DevsuContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("DevsuDB"),
            b => b.MigrationsAssembly(typeof(DevsuContext).Assembly.FullName))
            );

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services.AddTransient(typeof(IGenericRepository<>), typeof(IGenericRepository<>));
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IPersonRepository, PersonRepository>();

        return services;
    }
}
