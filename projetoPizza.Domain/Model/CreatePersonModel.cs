namespace projetoPizza.Domain.Model;

public readonly record struct CreatePersonModel(string Apelido, string Nome, DateTime Nascimento, List<string> Stack);
