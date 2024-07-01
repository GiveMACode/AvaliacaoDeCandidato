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
    public DbSet<Usuario> Usuario { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //utilizando model builder para a definicao das classes e chaves primarias e estrangeiras
       
         // Configuração do relacionamento Pessoa <-> Telefones
        modelBuilder.Entity<Telefone>()
            .HasOne(t => t.Pessoa)
            .WithMany(p => p.Telefones)
            .HasForeignKey(t => t.PessoaId)
            .IsRequired(false);
    
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Pessoa)
            .WithOne(p => p.Usuario)
            .HasForeignKey<Usuario>(u => u.PessoaId);
    
    }


    }
