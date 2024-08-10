using projetoPizza.Controllers;
using projetoPizza.Domain.Interface;
using projetoPizza.Domain.Repository;
using projetoPizza.Domain.Service;

namespace projetoPizza.Configuration;
internal static class DependencyInjection
{
    internal static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<IPersonRepository, PersonRepository>();
        services.AddTransient<IPersonService, PersonService>();
        services.AddTransient<PeopleController>();
        services.AddTransient<PeopleDataController>();
    }
}