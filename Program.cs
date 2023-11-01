namespace Aula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carro> carros = new List<Carro>();

            int continuar = 1;

            for(int i = 0; i < continuar; i++)
            {
                Carro car = new Carro();

                Console.WriteLine("Insira o modelo do carro: ");
                car.Modelo = Console.ReadLine();

                Console.WriteLine("Insira a marca do carro: ");
                car.marca = Console.ReadLine();

                Console.WriteLine("Insira a cor do carro: ");
                car.cor = Console.ReadLine();

                Console.WriteLine("Insira o ano do carro: ");
                car.ano = int.Parse(Console.ReadLine());

                Console.WriteLine("Você deseja adicionar mais um carro? S - Sim N - Não");
                string cont = Console.ReadLine().ToUpper();

                if(cont == "S")
                {
                    continuar++;
                }

                carros.Add(car);
            }

            foreach(Carro carro in carros)
            {
                Console.WriteLine(carro.display());
            }
        }
    }
}