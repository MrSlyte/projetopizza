using Microsoft.Extensions.Options;
using projetoPizza.Domain.Config;

namespace projetoPizza.Domain.Repository;
public record BaseRepository
{
    protected readonly SystemConfiguration _config;
    protected readonly string _connectionString;

    protected BaseRepository(IOptions<SystemConfiguration> Config)
    {
        _config = Config.Value;
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        _connectionString = _config.ConnectionStrings.DefaultConneciton
            .Replace("{DB_USER}", dbUser)
            .Replace("{DB_HOST}", dbHost)
            .Replace("{DB_PASSWORD}", dbPass)
            .Replace("{DB_PORT}", dbPort)
            .Replace("{DB_NAME}", dbName);
    }
}