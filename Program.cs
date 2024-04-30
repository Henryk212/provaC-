using API.Models;
using Microsoft.AspNetCore.Mvc;
using PedroFranca.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

List<Funcionarios> funcionarios = new List<Funcionarios>();
List<Folha> folhas = new List<Folha>();

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



app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext context) =>
{
    if (context.Funcionario.Any())
    {
        return Results.Ok(context.Funcionario.ToList());
    }
    return Results.NotFound("Não existem funcionario na tabela");
});

app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext context) =>
{
    Funcionarios? funcionario = context.Funcionario.FirstOrDefault(x => x.Id == folha.FuncionarioId);
    if (funcionario is not null)
    {
       
        context.Folhas.Add(folha);
        context.SaveChanges();
        return Results.Created($"/api/folha/buscar/{folha.Id}", folha);
    }
    return Results.BadRequest("Funcionario não encontrado!");
});

app.MapGet("/api/folha/buscar/{id}", ([FromRoute] string id, [FromServices] AppDataContext context) =>
{
    Folha? folha = context.Folhas.FirstOrDefault(x => x.Id == id);
    if (folha is not null)
    {
        return Results.Ok(folha);
    }
    return Results.NotFound("Folha não encontrada!");
});






app.Run();
