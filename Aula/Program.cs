namespace Aula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carro> carros = new List<Carro>();

            int continuar = 1;

            for (int i = 0; i < continuar; i++)
            {
                Carro car = new Carro();

                Console.WriteLine("Insira a placa do carro: ");
                car.placa = Console.ReadLine();

                bool certo = true;

                while (certo == true)
                {
                    foreach (var placas in carros)
                    {
                        while (car.placa == placas.placa)
                        {
                            Console.WriteLine("Placa inválida!");
                            Console.WriteLine("Insira a placa do carro: ");
                            car.placa = Console.ReadLine();
                        }
                        certo = false;
                    }

                    while (car.placa.Length < 7 || car.placa.Length > 8)
                    {
                        Console.WriteLine("Placa inválida!");
                        Console.WriteLine("Insira a placa do carro: ");
                        car.placa = Console.ReadLine();
                    }

                    certo = false;
                }
                Console.WriteLine("Insira o modelo do carro: ");
                car.Modelo = Console.ReadLine();

                Console.WriteLine("Insira a marca do carro: ");
                car.marca = Console.ReadLine();

                Console.WriteLine("Insira o ano do carro: ");
                car.ano = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira a cor do carro: ");
                car.cor = Console.ReadLine();

                carros.Add(car);

                Console.WriteLine("Você deseja continuar? S - Sim N - Não");

                string contD = Console.ReadLine().ToUpper();

                if (contD == "S")
                {
                    continuar++;
                }

                Console.Clear();
            }

            foreach (Carro carro in carros)
            {
                Console.WriteLine(carro.display());
            }

            int continuarD = 1;
            Console.WriteLine("Deseja apagar um carro? S - Sim N - Não");

            string cont = Console.ReadLine().ToUpper();

            if (cont == "S")
            {
                for (int j = 0; j < continuarD; j++)
                {
                    Console.WriteLine("Insira a placa do carro que deseja deletar: ");
                    string placaD = Console.ReadLine();

                    foreach (Carro deletar in carros)
                    {
                        if (placaD == deletar.placa)
                        {
                            carros.Remove(deletar);

                            foreach (Carro carro in carros)
                            {
                                Console.WriteLine(carro.display());
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Essa placa não existe!");
                        }
                    }

                    Console.WriteLine("Deseja apagar mais um carro? S - Sim N - Não");
                    string contD2 = Console.ReadLine();

                    if(contD2 == "S")
                    {
                        continuarD++;
                    }

                    Console.Clear();
                }
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Fim");
            }

            foreach (Carro carro in carros)
            {
                Console.WriteLine(carro.display());
            }

            Console.WriteLine("Deseja editar algum carro? S - Sim N - Não");
            string contE = Console.ReadLine().ToUpper();

            if(contE == "S")
            {
                int continuarE = 1;
                for (int k = 0; k < continuarE; k++)
                {
                    Console.WriteLine("Digite a placa do carro que deseja editar: ");
                    var placaE = Console.ReadLine();

                    foreach (Carro editar in carros)
                    {
                        if (placaE == editar.placa)
                        {
                            int posicao = carros.IndexOf(editar);

                            Carro car = new Carro();

                            Console.WriteLine("Insira a placa do carro: ");
                            car.placa = Console.ReadLine();

                            var certo = true;

                            while (certo == true)
                            {
                                foreach (var placas in carros)
                                {
                                    while (car.placa == placas.placa)
                                    {
                                        Console.WriteLine("Placa inválida!");
                                        Console.WriteLine("Insira a placa do carro: ");
                                        car.placa = Console.ReadLine();
                                    }
                                    certo = false;
                                }

                                while (car.placa.Length < 7 || car.placa.Length > 8)
                                {
                                    Console.WriteLine("Placa inválida!");
                                    Console.WriteLine("Insira a placa do carro: ");
                                    car.placa = Console.ReadLine();
                                }

                                certo = false;
                            }
                            Console.WriteLine("Insira o modelo do carro: ");
                            car.Modelo = Console.ReadLine();

                            Console.WriteLine("Insira a marca do carro: ");
                            car.marca = Console.ReadLine();

                            Console.WriteLine("Insira o ano do carro: ");
                            car.ano = int.Parse(Console.ReadLine());

                            Console.WriteLine("Insira a cor do carro: ");
                            car.cor = Console.ReadLine();

                            carros[posicao] = car;

                            carros.Remove(editar);

                            foreach (Carro carro in carros)
                            {
                                Console.WriteLine(carro.display());
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Essa placa não existe!");
                        }

                        foreach (Carro carro in carros)
                        {
                            Console.WriteLine(carro.display());
                        }
                    }

                    Console.WriteLine("Deseja editar mais um carro? S - Sim N - Não");
                    string opcaoE = Console.ReadLine().ToUpper();

                    if(opcaoE == "S")
                    {
                        continuarE++;
                    }
                }
            }

            foreach (Carro carro in carros)
            {
                Console.WriteLine(carro.display());
            }
        } 
    }
}