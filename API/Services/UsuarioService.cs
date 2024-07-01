using API.Data;
using API.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public interface IUsuarioService
{
    Task<Usuario> CriarUsuarioAsync(string nomeUsuario, string email, string senha, string nome, string cpf, DateTime dataNascimento);
    Task ExcluirUsuarioAsync(Guid usuarioId);

    Task<bool> VerificarLoginAtivoAsync(string nomeUsuario);
}   


public class UsuarioService : IUsuarioService
{
    private readonly AppDataContext _context;

    public UsuarioService(AppDataContext context)
    {
        _context = context;
    }

    public async Task<Usuario> CriarUsuarioAsync(string nomeUsuario, string email, string senha, string nome, string cpf, DateTime dataNascimento)
    {
        // Verificar se já existe um usuário com o mesmo email
        if (await _context.Usuario.AnyAsync(u => u.Email == email))
        {
            throw new ArgumentException("Este email já está em uso.");
        }

        // Verificar se já existe uma pessoa com o mesmo CPF
        if (await _context.Pessoas.AnyAsync(p => p.CPF == cpf))
        {
            throw new ArgumentException("Este CPF já está cadastrado.");
        }

        // Hash da senha
        string senhaHash = HashSenha(senha);

        // Criar a pessoa
        var pessoa = new Pessoa
        {
            Nome = nome,
            CPF = cpf,
            DataNascimento = dataNascimento
        };

        // Criar o usuário
        var usuario = new Usuario
        {
            NomeUsuario = nomeUsuario,
            Email = email,
            Senha = senhaHash,
            Pessoa = pessoa
        };

        _context.Pessoas.Add(pessoa);
        _context.Usuario.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }

    public async Task ExcluirUsuarioAsync(Guid usuarioId)
    {
        var usuario = await _context.Usuario.FindAsync(usuarioId);
        if (usuario == null)
        {
            throw new ArgumentException("Usuário não encontrado.");
        }

        usuario.EstaAtivo = true; // Marcando usuário como excluído logicamente
        await _context.SaveChangesAsync();
    }

    public async Task<bool> VerificarLoginAtivoAsync(string nomeUsuario)
    {
        var usuario = await _context.Usuario.SingleOrDefaultAsync(u => u.NomeUsuario == nomeUsuario);
        if (usuario == null)
        {
            return false; // Usuário não encontrado
        }

        return usuario.EstaAtivo;
    }
    // Método para hash da senha usando BCrypt
    private string HashSenha(string senha)

    
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    
    }

