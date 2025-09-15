using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace web_Api.Models;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [MaxLength(100)]
    public string? ImagemUrl { get; set; }

    public ICollection<Produto>? Produtos { get; set; }
}   
