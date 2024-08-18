using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DemoFluentValidationPlusActionFilter.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    [HttpPost(Name = "PostPerson")]
    public IActionResult Post(Person person)
    {
        return Ok();
    }
}
