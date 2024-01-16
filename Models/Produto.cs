using System.Text.Json.Serialization;

namespace API_2.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco {  get; set; }
        public int Estoque { get; set; }
        public Categoria Category { get; set; }
        [JsonIgnore]
        public int CategoriaId { get; set; }
    }
}
