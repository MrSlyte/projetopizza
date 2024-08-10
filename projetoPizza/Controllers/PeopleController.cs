using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using projetoPizza.Domain.Interface;
using projetoPizza.Domain.Model;

namespace projetoPizza.Controllers;

internal class PeopleController(IPersonService personService) : ControllerBase
{
    private const string PostRoute = "/pessoas";
    private const string GetTermRoute = "/pessoas";
    private const string GetByIdRoute = "/pessoas/{id:guid}";

    private readonly IPersonService _personService = personService;
    internal void Map(WebApplication app)
    {
        app.MapPost(PostRoute, Post);
        app.MapGet(GetByIdRoute, GetById);
        app.MapGet(GetTermRoute, GetByTerm);
    }

    private async Task<IResult> Post(CreatePersonModel Model)
    {
        try
        {
            var id = await _personService.Post(Model);
            return Results.Created(new Uri($"/pessoas/{id}", uriKind: UriKind.Relative), id);
        }
        catch(ValidationException valEx)
        {
            return Results.UnprocessableEntity(valEx.Errors);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.ToString());
        }
    }

    private async Task<IResult> GetById(Guid Id)
    {
        try
        {
            var id = await _personService.GetById(Id);
            return Results.Created(new Uri($"/pessoas/{id}", uriKind: UriKind.Relative), id);
        }
        catch (Exception ex)
        {
            return Results.NotFound(ex.ToString());
        }
    }

    private async Task<IResult> GetByTerm(string t)
    {
        try
        {
            var result = await _personService.GetByTerm(t);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.ToString());
        }
    }
}
