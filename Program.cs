using DemoFluentValidationPlusActionFilter;
using DemoFluentValidationPlusActionFilterPlusActionFilter;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationActionFilter)));

builder.Services.AddValidatorsFromAssemblyContaining<PersonValidator>();

// Responsável por fazer as validações de forma automatica, 
// descomentando essa linha (15) não é necessário um ActionFilter para recuperar os erros.

// builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
