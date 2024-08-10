using projetoPizza.Domain.Model;

namespace projetoPizza.Domain.Interface;
public interface IPersonService
{
    Task<Guid> Post(CreatePersonModel Model);
    Task<GetPersonModel> GetById(Guid Id);
    Task<IEnumerable<GetPersonModel>> GetByTerm(string Term);
    Task<int> GetCount();
}