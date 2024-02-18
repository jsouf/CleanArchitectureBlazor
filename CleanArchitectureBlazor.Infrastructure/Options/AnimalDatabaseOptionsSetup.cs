using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CleanArchitectureBlazor.Infrastructure.Options;

public class AnimalDatabaseOptionsSetup : IConfigureOptions<AnimalDatabaseOptions>
{
    private const string ConfigurationSectionName = nameof(AnimalDatabaseOptions);

    private readonly IConfiguration _configuration;

    public AnimalDatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(AnimalDatabaseOptions options)
    {
        string? connectionString = _configuration.GetConnectionString("AnimalConnection");
        options.ConnectionString = connectionString;

        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
