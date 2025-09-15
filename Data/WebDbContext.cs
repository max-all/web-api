using Microsoft.EntityFrameworkCore;
using web_Api.Models;

namespace web_Api.Data;

public class WebDbContext : DbContext
{
    public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
    { }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
}
