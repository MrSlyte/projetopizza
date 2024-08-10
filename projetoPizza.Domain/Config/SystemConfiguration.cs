namespace projetoPizza.Domain.Config;
public record SystemConfiguration
{
    public ConnectionStringConfiguration ConnectionStrings { get; set; }
}
public readonly record struct ConnectionStringConfiguration(string DefaultConneciton);