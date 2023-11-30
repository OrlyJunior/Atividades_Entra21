namespace MVC3.Models
{
    public class Compromisso
    {
        //Id, data, hora, local, contato e status
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int LocalId { get; set; }
        public int ContatoId { get; set; }
        public string Status { get; set; }
    }
}
