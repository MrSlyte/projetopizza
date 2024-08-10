using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using projetoPizza.Domain.Config;
using projetoPizza.Domain.Interface;
using projetoPizza.Domain.Model;
using System.Linq;

namespace projetoPizza.Domain.Repository;
public record PersonRepository(IOptions<SystemConfiguration> Config) : BaseRepository(Config), IPersonRepository
{
    public async Task<Guid> Insert(CreatePersonModel Model)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = @"INSERT INTO People (Name, Nickname, Birthdate, Stack) VALUES (@Name, @Nickname, @Birthdate, @Stack) RETURNING ExternalId";

        var parametersWithStack = new
        {
            Name = Model.Nome,
            NickName = Model.Apelido,
            Birthdate = Model.Nascimento,
            Stack = string.Join('|', Model.Stack)
        };
        return await connection.ExecuteScalarAsync<Guid>(sql, parametersWithStack);
    }

    public async Task<bool> AlreadyExists(string Nickname)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = "SELECT Nickname FROM People WHERE Nickname = @Nickname LIMIT 1";

        var found = await connection.QuerySingleOrDefaultAsync<string>(sql, new { Nickname });
        return !string.IsNullOrEmpty(found);
    }

    public async Task<GetPersonModel> GetById(Guid Id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = "SELECT ExternalId as Id, Name as Nome, Nickname as Apelido, Birthdate as Nascimento, Stack FROM People WHERE ExternalId = @ExternalId LIMIT 1";
        var parameters = new DynamicParameters();
        parameters.Add("ExternalId", Id);
        var found = await connection.QuerySingleAsync(sql, new { ExternalId = Id });

        string stack = Convert.ToString(found.stack);
        var returnMethod = new GetPersonModel(found.id, found.apelido, found.nome, found.nascimento, stack.Split('|'));
        return returnMethod;
    }

    public async Task<IEnumerable<GetPersonModel>> GetByTerm(string Term)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        Term = $"%{Term}%";
        var sql = "SELECT ExternalId as Id, Name as Nome, Nickname as Apelido, Birthdate as Nascimento, Stack FROM People WHERE CONCAT(Name, NickName, Stack) LIKE @Term";
        var founds = await connection.QueryAsync(sql, new { Term });
        return (from found in founds
                let stack = Convert.ToString(found.stack)
                select new GetPersonModel(found.id, found.apelido, found.nome, found.nascimento, stack.Split('|')));
    }

    public async Task<int> GetCount()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = "SELECT count(Nickname) FROM People";
        var count = await connection.QuerySingleAsync<int>(sql);
        return count;
    }
}
