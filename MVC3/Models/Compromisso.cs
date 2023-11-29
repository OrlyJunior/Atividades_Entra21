namespace MVC3.Models
{
    public class Compromisso
    {
        //Id, data, hora, local, contato e status
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int LocalId { get; set; }
        public int ContatoId { get; set; }
        public string Status { get; set; }
    }
}
