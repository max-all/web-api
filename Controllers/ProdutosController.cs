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
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos.AsNoTracking().ToList();

        if(produtos is null)
        {
            return NotFound("Produtos não encontrados...");
        }

        return produtos;
    }

    [HttpGet("{id:int}", Name = "GetNewProduto")]
    public ActionResult<Produto> GetById(int id)
    {
        var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.Id == id);

        if(produto is null)
        {
            return NotFound("Produto não encontrado...");
        }

        return produto;
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto is null)
            return BadRequest();

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetNewProduto",
            new {id = produto.Id}, produto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }

        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(produto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

        if(produto is null)
        {
            return NotFound();
        }

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return Ok(produto);
    }
}
