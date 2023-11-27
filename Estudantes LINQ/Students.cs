using System.ComponentModel;

namespace Estudantes_LINQ
{
    public class Student
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public List<int> Notas { get; set; }

        public string toString()
        {
            return $"Id: {Id}\nNome: {NomeCompleto}\nNota: {Notas}";
        }
    }
}
