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



}
