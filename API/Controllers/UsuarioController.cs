using API.Data;
using API.Models;
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
}
