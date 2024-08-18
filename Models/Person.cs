using FluentValidation;

namespace DemoFluentValidationPlusActionFilter;

public record Person 
{
    public string Name { get; set; } = string.Empty!;
    public string Document { get; set; } = string.Empty!;
    public string  Email { get; set; } = string.Empty!;
    public  int Age { get; set; }

    public (bool IsValid, IEnumerable<string> Errors) Validate(IValidator<Person> validator)
    {
        var validate = validator.Validate(this);
        var errors = validate.Errors.Select(x => x.ErrorMessage);

        return (validate.IsValid, errors);
    }
}
