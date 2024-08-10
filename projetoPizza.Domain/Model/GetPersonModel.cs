namespace projetoPizza.Domain.Model;

public readonly record struct GetPersonModel(Guid Id, string Apelido, string Nome, DateTime Nascimento, IEnumerable<string> Stack);
