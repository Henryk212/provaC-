using Microsoft.EntityFrameworkCore;
using PedroFranca.Models;

namespace API.Models;

public class AppDataContext : DbContext
{
    //Entity Framework Code First
    //Quais classes vão representar as tabelas no banco
    public DbSet<Funcionarios> Funcionario { get; set; }

    public DbSet<Folha> Folhas { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Configuração da String de Conexão
        optionsBuilder.UseSqlite("Data Source=HenriqueOnorato_PedroFranca.db");
    }
}