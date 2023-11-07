namespace Heranca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            criaPessoa();

            criaCliente();
        }

        static void criaPessoa()
        {
            Pessoa pessoa = new Pessoa(1, "Jéfferson");

            Console.WriteLine(pessoa.toString());
        }

        static void criaCliente()
        {
            Cliente cliente = new Cliente(2, "Cléber", 123123, 456456);
            Console.WriteLine(cliente.toString());
        }
    }
}