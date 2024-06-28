using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Controllers;

    [Route("api/pessoa")]
    [ApiController]
public class PessoaController : ControllerBase
{   //instancia do appcontext
    private readonly AppDataContext _context;
   
   // private readonly IMapper _mapper;

    //api/pessoa GET
    [HttpGet]
    public IActionResult ListarPessoasAtivas()
        {
            var listaAtivos = _context.Pessoas.Where(d => d.EstaAtivo).ToList();

            return Ok(listaAtivos);
        }

    //api/pessoa/72345678-l234-1234-1234-1234-12E4g6789i1  GET
    [HttpGet("{id}")]
    public IActionResult ListarPorId(string id)
    {
        var listaAtivos = _context.Pessoas.Include(t => t.Telefones).SingleOrDefault(d => d.PessoaId == id);
    
        if(ListarPorId == null)
        {
            return NotFound();
        }
        return Ok(listaAtivos);
    }
        


}
