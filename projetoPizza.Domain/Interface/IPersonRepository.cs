using projetoPizza.Domain.Model;

namespace projetoPizza.Domain.Interface;
public interface IPersonRepository
{
    Task<Guid> Insert(CreatePersonModel Model);
    Task<GetPersonModel> GetById(Guid Id);
    Task<IEnumerable<GetPersonModel>> GetByTerm(string Term);
    Task<bool> AlreadyExists(string Nickname);
    Task<int> GetCount();
}