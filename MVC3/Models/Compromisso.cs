namespace MVC3.Models
{
    public class Compromisso
    {
        //Id, data, hora, local, contato e status
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Local { get; set; }
        public string Contato { get; set; }
        public int LocalId { get; set; }
        public int ContatoId { get; set; }
        public string Status { get; set; }
    }
}
