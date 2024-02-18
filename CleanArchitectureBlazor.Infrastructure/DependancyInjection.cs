using CleanArchitectureBlazor.Application;
using CleanArchitectureBlazor.Infrastructure.Context;
using CleanArchitectureBlazor.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CleanArchitectureBlazor.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddAnimalContext();

        return services;
    }

    private static void AddAnimalContext(this IServiceCollection services)
    {
        services.ConfigureOptions<AnimalDatabaseOptionsSetup>();

        services.AddDbContext<AnimalContext>((provider, options) =>
        {
            AnimalDatabaseOptions databaseOptions = provider.GetService<IOptions<AnimalDatabaseOptions>>()!.Value;

            options.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
            {
                sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
            });

            options.EnableDetailedErrors(databaseOptions.EnableDetailledErrors);
            options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddScoped<IAnimalContext>(provider => provider.GetRequiredService<AnimalContext>());
    }
}
