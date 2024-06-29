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
    //listar todas as pessoas ativas, nao exclusas
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

    //listar Pessoas por id
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

    //Cadastrar Pessoas
    // api/pessoa/ POST
    [HttpPost]
    public IActionResult CadastrarPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();

        return CreatedAtAction(nameof(ListarPorId),
        new { id = pessoa.Id }, pessoa);
    }

    //Deletar logico
    //api/pessoa/72345678-l234-1234-1234-1234-12E4g6789i1  DELETE    
    [HttpDelete("{id}")]
    public IActionResult DeletarLogico(Guid id)
    {

        var pessoaDelete = _context.Pessoas.SingleOrDefault(d => d.Id == id);

        if (pessoaDelete == null)
        {
            return NotFound();
        }

        pessoaDelete.Deletar();

        _context.SaveChanges();

        return NoContent();

    }

    //Cadastrar telefone para a Pessoa por ID
    [HttpPost("{id}/telefones")]
    public IActionResult AtualizarTelefone(Guid id, Telefone telefone)    
    {
        telefone.PessoaId = id;
            
            var pessoa = _context.Pessoas.Any(d => d.Id == id);

            if (!pessoa) 
            {
                return NotFound();
            }

            _context.Telefones.Add(telefone);
            _context.SaveChanges();

            return NoContent();
    }

    //listar todas as pessoas exclusas logicamente
    [HttpGet]
    public IActionResult ListarPessoasExcluidas()
    {
        var listaExclusa = _context.Pessoas.Where(d => d.EstaAtivo).ToList();
        if (listaExclusa == null)
        {
        return Ok(listaExclusa);    
        }
        
        return NotFound("No Active people found");
    }
    

}


