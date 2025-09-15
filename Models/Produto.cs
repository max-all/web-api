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


    public int? CategoryId { get; set; }
    public Categoria? Categoria { get; set; }
}
