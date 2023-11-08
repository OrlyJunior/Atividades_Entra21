namespace AtividadeLista1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, Pessoa> pessoas = new SortedList<int, Pessoa>();

            add(pessoas);
            
            IList<int> chave = pessoas.Keys;
            foreach(KeyValuePair<int, Pessoa> k in pessoas)
            {
                Console.WriteLine($"{k.Key}\n{k.Value.Nome}\n{k.Value.Numero}");
            }
        }

        static void add(SortedList<int, Pessoa> lista)
        {
            int id = 1;

            Pessoa person = new Pessoa("Cléber", 1234567);

            lista.Add(id, person);

            id++;
        }
    }
}