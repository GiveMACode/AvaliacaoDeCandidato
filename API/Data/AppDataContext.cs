using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data;


public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options){}

    //implementado projeto em vida longa, com adicao de banco de dados
    //utilizacao do EntityFramework para geracao de BD
    
    // Abaixo as Classes que vao virar tabelas no Banco de Dados
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Telefone> Telefones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //utilizando model builder para a definicao das classes e chaves primarias e estrangeiras
        modelBuilder.Entity<Pessoa>()
            .HasMany(p => p.Telefones)
            .WithOne(t => t.Pessoa)
            .HasForeignKey(t => t.PessoaId);
    }
    }
