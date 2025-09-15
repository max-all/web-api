using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace web_Api.Models;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Nome { get; set; } 

    [MaxLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Preco { get; set; }

    [MaxLength(100)]
    public string? ImagemUrl { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,3)")]
    public decimal Estoque { get; set; }

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    public int? CategoriaId { get; set; }

    [JsonIgnore]
    public Categoria? Categoria { get; set; }
}
