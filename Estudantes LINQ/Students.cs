namespace Estudantes_LINQ
{
    public class Student
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public List<int> Notas { get; set; }

        public string toString()
        {
            return $"ID: {Id}\nAluno: {NomeCompleto}\nNota 1: {Notas[0]}\nNota 2: {Notas[1]}\nNota 3: {Notas[2]}\nNota 4: {Notas[3]}\nMédia: {Notas.Average()}";
        }
    }
}     