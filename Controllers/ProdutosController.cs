using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_Api.Data;
using web_Api.Models;

namespace web_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly WebDbContext _context;

    public ProdutosController(WebDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
    {
        var produtos = await _context.Produtos.AsNoTracking().ToListAsync();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrados...");
        }

        return Ok(produtos);
    }

    [HttpGet("{id:int:min(1)}", Name = "GetNewProduto")]
    public async Task<ActionResult<Produto>> GetByIdAsync(int id)
    {
        var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        if (produto is null)
        {
            return NotFound($"Produto de ID:{id} não encontrado...");
        }

        return Ok(produto);
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto is null)
            return BadRequest("Dados Invalidos");

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetNewProduto",
            new { id = produto.Id }, produto);
    }

    [HttpPut("{id:int:min(1)}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest("Dados Invalidos");
        }

        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(produto);
    }

    [HttpDelete("{id:int:min(1)}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

        if (produto is null)
        {
            return NotFound($"Produto de ID:{id} não encontrado...");
        }

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return Ok(produto);
    }
}
