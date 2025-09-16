using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure;


//aqui seria o contexto do banco de dados, onde ficaria a configuração do Entity Framework, as DbSets, etc
//é onde será feita a conexão com o banco de dados, traduzindo as operações do código em operações no banco de dados
public class ProductClientHubDbContext : DbContext
{
    //variavel que representa a tabela de clientes no banco de dados
    //o nome do atributo deve sempre ser o mesmo nome da tabela no banco de dados (Clients)
    public DbSet<Client> Clients { get; set; } = default!;

    //variavel que representa a tabela de produtos no banco de dados
    //o nome do atributo deve sempre ser o mesmo nome da tabela no banco de dados (Products)
    public DbSet<Product> Products { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //aqui é onde se configura a conexão com o banco de dados, nesse caso, está sendo usado o SQLite como banco de dados
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\ander\\Documents\\Estudos\\C#\\C# e .NET - Curso Introdutório\\ProductClientHubDB (1).db");

    }
}

