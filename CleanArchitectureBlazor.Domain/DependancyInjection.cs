using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBlazor.Domain;

public static class DependancyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
