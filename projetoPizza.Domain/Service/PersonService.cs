using FluentValidation;
using projetoPizza.Domain.Interface;
using projetoPizza.Domain.Model;
using projetoPizza.Domain.Validation;

namespace projetoPizza.Domain.Service;
public class PersonService(IPersonRepository personRepository) : IPersonService
{
    private readonly IPersonRepository _personRepository = personRepository;

    public async Task<Guid> Post(CreatePersonModel Model)
    {
        var validator = await (new PersonModelValidation(_personRepository)).ValidateAsync(Model);
        if (!validator.IsValid)
            throw new ValidationException(validator.Errors);

        return await _personRepository.Insert(Model);
    }

    public async Task<GetPersonModel> GetById(Guid Id)
    {
        return await _personRepository.GetById(Id);
    }

    public async Task<IEnumerable<GetPersonModel>> GetByTerm(string Term)
    {
        return await _personRepository.GetByTerm(Term);
    }

    public async Task<int> GetCount()
    {
        return await _personRepository.GetCount();
    }
}
