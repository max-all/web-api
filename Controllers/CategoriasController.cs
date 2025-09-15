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
        var categorias = _context.Categorias.AsNoTracking().ToList();

        if(categorias is null)
        {
            return NotFound("Categorias não encontrada...");
        }

        return categorias;
    }

    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetByProductName()
    {
        var categorias = _context.Categorias.AsNoTracking().Include(p => p.Produtos).ToList();

        if (categorias is null)
        {
            return NotFound("Categorias não encontrada...");
        }

        return categorias;
    }

    [HttpGet("{id:int}", Name = "GetNewCategoria")]
    public ActionResult<Categoria> GetById(int id)
    {
        var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);

        if(categoria is null)
        {
            return NotFound("Categoria não encontrada...");
        }

        return categoria;
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
            return BadRequest();

        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetNewCategoria",
            new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.Id)
        {
            return BadRequest();
        }

        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

        if(categoria is null)
        {
            return NotFound();
        }

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return Ok(categoria);
    }
}
