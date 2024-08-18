using FluentValidation;

namespace DemoFluentValidationPlusActionFilter;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x=> x.Name).NotEmpty()
            .WithMessage("O Nome é obrigatório");
        RuleFor(x => x.Document).Length(11)
            .WithMessage("Documento inválido");

        RuleFor(x => x.Email).EmailAddress()
            .WithMessage("Endereço de e-mail inválido");

        RuleFor(x => x.Age).InclusiveBetween(18, 60)
            .WithMessage("A Idade deve ser entre 18 a 60 anos");
        
    }
}