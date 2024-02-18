namespace CleanArchitectureBlazor.Infrastructure.Options;

public class AnimalDatabaseOptions
{
    public string? ConnectionString { get; set; } = "";
    public int MaxRetryCount { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailledErrors { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}
