using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoFluentValidationPlusActionFilterPlusActionFilter;

public class ValidationActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var argument in context.ActionArguments.Values)
        {
            if(argument is null)
                return;

            var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
            var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

            if (validator != null)
            {
                var validationContext = new ValidationContext<object>(argument);
                var result = validator.Validate(validationContext);

                if (!result.IsValid)
                {
                    var errorResponse = new ErrorResponse(400);
                    foreach (var error in result.Errors)
                    {
                        errorResponse.Errors.Add(error.PropertyName, error.ErrorMessage);   
                    }

                    context.Result = new BadRequestObjectResult(errorResponse);
                }
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}