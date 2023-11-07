namespace Moto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            criaMoto();

            criaViagem();

            criaCompeticao();
        }

        static void criaMoto()
        {
            Moto moto = new Moto("Kawasaki Ninja", "Honda", 3, "Vermelho");

            Console.WriteLine(moto.toString());
        }

        static void criaViagem()
        {
            Normal normal= new Normal("Kawasaki Samurai", "Suzuki", 2, "Azul", "ABC1234");

            Console.WriteLine(normal.toString());
        }

        static void criaCompeticao()
        {
            Competicao competicao = new Competicao("Kawasaki", "Mitsubishi", 2, "Prata", 7);

            Console.WriteLine(competicao.toString());
        }
    }
}