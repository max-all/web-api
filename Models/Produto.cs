using System.Text.Json.Serialization;

namespace web_Api.Models;

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public decimal Estoque { get; set; }
    public DateTime DataCadastro { get; set; }


    public int? CategoriaId { get; set; }
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
}
