using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using API.Models;

namespace API.Controllers;

[Route("api/pessoa")]
[ApiController]
public class PessoaController : ControllerBase
{   //instancia do appcontext
    private readonly AppDataContext _context;

    public PessoaController(AppDataContext context)
    {
        _context = context;
    }

    // private readonly IMapper _mapper;

    //api/pessoa GET
    [HttpGet]
    public IActionResult ListarPessoasAtivas()
    {
        var listaAtivos = _context.Pessoas.Where(d => d.EstaAtivo).ToList();
        if (listaAtivos == null)
        {
            return NotFound("No Active people found");
        }
        return Ok(listaAtivos);
    }
    //api/pessoa/72345678-l234-1234-1234-1234-12E4g6789i1  GET
    [HttpGet("{id}")]
    public IActionResult ListarPorId(Guid id)
    {
        var listaAtivos = _context.Pessoas.Include(t => t.Telefones).SingleOrDefault(d => d.Id == id);

        if (ListarPorId == null)
        {
            return NotFound();
        }
        return Ok(listaAtivos);
    }

    // api/pessoa/ POST
    [HttpPost]
    public IActionResult CadastrarPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();

        return CreatedAtAction(nameof(ListarPorId),
        new { id = pessoa.Id }, pessoa);
    }

    }
    


