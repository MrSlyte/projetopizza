using FluentValidation;
using projetoPizza.Domain.Interface;
using projetoPizza.Domain.Model;

namespace projetoPizza.Domain.Validation;
internal class PersonModelValidation : AbstractValidator<CreatePersonModel>
{
    public PersonModelValidation(IPersonRepository _personRepository)
    {
        RuleFor(person => person.Apelido).NotEmpty().DependentRules(() =>
        {
            RuleFor(person => person.Apelido)
            .MustAsync(async (apelido, canToken) => !await _personRepository.AlreadyExists(apelido))
            .WithMessage("Essa pessoa já existe");
        });
        RuleFor(person => person.Nome).NotEmpty();
        RuleFor(person => person.Stack)
            .Must(stack => stack == null || stack.Count == 0 || stack.TrueForAll(item => !string.IsNullOrEmpty(item)))
            .WithMessage("Stack não pode ter um valor branco, remova o item")
            .DependentRules(() =>
            {
                RuleForEach(person => person.Stack).MaximumLength(32).WithMessage("Máximo 32 caracteres por stack");
            });
    }
}