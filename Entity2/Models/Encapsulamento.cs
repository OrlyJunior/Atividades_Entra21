namespace Entity2.Models
{
    public class Encapsulamento
    {
        public int Id { get; set; }
        public List<Contato> Contato { get; set; }
        public List<Local> Local { get; set; }
        public DateTime Dia { get; set; }
        public Local Local2 { get; set; }
        public Contato Contato2 { get; set; }
    }
}
