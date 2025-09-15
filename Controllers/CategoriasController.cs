using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_Api.Data;
using web_Api.Models;

namespace web_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly WebDbContext _context;

    public CategoriasController(WebDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        try
        {
            var categorias = _context.Categorias.AsNoTracking().ToList();

            if (categorias is null)
            {
                return NotFound("Categorias não encontrada...");
            }

            return Ok(categorias);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tratar a sua solicitação");
        }
    }

    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetByProductName()
    {
        try
        {
            var categorias = _context.Categorias.AsNoTracking().Include(p => p.Produtos).ToList();

            if (categorias is null)
            {
                return NotFound("Categorias não encontrada...");
            }

            return Ok(categorias);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tratar a sua solicitação");
        }
    }

    [HttpGet("{id:int}", Name = "GetNewCategoria")]
    public ActionResult<Categoria> GetById(int id)
    {
        try
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);

            if (categoria is null)
            {
                return NotFound($"Categoria de ID:{id} não encontrada...");
            }

            return Ok(categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tratar a sua solicitação");
        }
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        try
        {
            if (categoria is null)
                return BadRequest("Dados Invalidos");

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetNewCategoria",
                new { id = categoria.Id }, categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tratar a sua solicitação");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        try
        {
            if (id != categoria.Id)
            {
                return BadRequest("Dados Invalidos");
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tratar a sua solicitação");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria is null)
            {
                return NotFound($"Categoria de ID{id} não encontrada...");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tratar a sua solicitação");
        }
    }
}
