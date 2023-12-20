using System.ComponentModel.DataAnnotations.Schema;

namespace Entity2.Models
{
    public class Compromisso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Contato Contato { get; set; }
        public Local Local { get; set; }
        public DateTime Dia { get; set; }
        public int LocalId { get; set; }
        public int ContatoId { get; set; }
    }
}
