using Microsoft.AspNetCore.Mvc;
using projetoPizza.Domain.Interface;

namespace projetoPizza.Controllers;
internal class PeopleDataController(IPersonService personService) : ControllerBase
{
    private readonly IPersonService _personService = personService;
    private const string GetCount = "/contagem-pessoas";

    internal void Map(WebApplication app)
    {
        app.MapGet(GetCount, Get);
    }

    private async Task<IResult> Get()
    {
        try
        {
            return Results.Ok(await _personService.GetCount());
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.ToString());
        }
    }
}