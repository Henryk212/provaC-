using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

List<Funcionarios> funcionarios = new List<Funcionarios>();

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionarios funcionario,
    [FromServices] AppDataContext context) =>
{

    Funcionarios? funcionarioBuacar = context.Funcionario.FirstOrDefault(x => x.Nome == funcionario.Nome); 

    if (funcionarioBuacar is null)
    {
    funcionario.Nome = funcionario.Nome.ToUpper();    
    context.Funcionario.Add(funcionario);
    context.SaveChanges();
    return Results.Created($"/api/funcionario/buscar/{funcionario.Cpf}", funcionario);
    }
        return Results.BadRequest("Funcionario já cadastrado!");
});


app.MapGet("/api/funcionario/buscar/{cpf}", ([FromRoute] string cpf, [FromServices] AppDataContext context) =>
{
    Funcionarios? funcionario = context.Funcionario.FirstOrDefault(x => x.Cpf == cpf);
    if (funcionario is not null)
    {
        return Results.Ok(funcionario);
    }
    return Results.NotFound("Funcionario não encontrado!");
});

app.MapGet("/api/produto/listar", ([FromServices] AppDataContext context) =>
{
    if (context.Funcionario.Any())
    {
        return Results.Ok(context.Funcionario.ToList());
    }
    return Results.NotFound("Não existem funcionario na tabela");
});

app.Run();
