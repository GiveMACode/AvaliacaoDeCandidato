using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly AppDataContext _context;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // GET: api/usuario/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
    {
        var buscarAtivos = _context.Usuario.SingleOrDefault(d => d.id == id);

        if (buscarAtivos == null)
        {
            return NotFound();
        }

        return Ok(buscarAtivos);

    }

    // POST: api/usuario
    [HttpPost]
    public async Task<ActionResult<Usuario>> CriarUsuario(UsuarioDto usuarioDto)
    {
        // Validar modelo
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var usuario = await _usuarioService.CriarUsuarioAsync(usuarioDto.NomeUsuario, usuarioDto.Email, usuarioDto.Senha, usuarioDto.Nome, usuarioDto.CPF, usuarioDto.DataNascimento);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.id }, usuario);
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("Erro", ex.Message);
            return BadRequest(ModelState);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno ao criar o usuário: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirUsuario(Guid id)
    {
        // Verificar se o usuário está logado e ativo
        var nomeUsuario = User.Identity.Name;
        var loginAtivo = await _usuarioService.VerificarLoginAtivoAsync(nomeUsuario);
        if (!loginAtivo)
        {
            return Forbid(); // Acesso negado se o login não estiver ativo
        }

        try
        {
            await _usuarioService.ExcluirUsuarioAsync(id);
            return NoContent(); // Retornar 204 No Content em caso de sucesso na exclusão
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message); // Retornar 404 Not Found se o usuário não existir
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno ao excluir o usuário: {ex.Message}");
        }
    }
}
