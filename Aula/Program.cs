namespace Aula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro jetta = new Carro("Jetta", "Renault");

            jetta.display();

            Carro city = new Carro("City", "Honda", 2015, "Prata");

            city.display();
        }
    }
}