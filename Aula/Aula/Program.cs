namespace Aula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carro> lista = new List<Carro>();

            int continuar = 1;
            for (int i = 0; i < continuar; i++)
            {
                Console.Clear();

                Console.WriteLine("Insira a operação que deseja realizar: ");

                Console.WriteLine("Adicionar carro: A");
                Console.WriteLine("Deletar carro: D");
                Console.WriteLine("Editar carro: E");
                Console.WriteLine("Consultar carro: S");
                Console.WriteLine("Consultar todos os carros: C");

                string operacao = Console.ReadLine().ToUpper();

                if (operacao == "A")
                {
                    Console.Clear();

                    Carro carro = new Carro();

                    string p = "f";

                    while (p == "f")
                    {
                        p = "e";

                        Console.WriteLine("Insira a placa do carro: ");
                        carro.placa = Console.ReadLine();

                        foreach (Carro car in lista)
                        {
                            Console.WriteLine(car.placa);
                            if (car.placa == carro.placa)
                            {
                                Console.WriteLine("Essa placa já existe!");

                                p = "f";
                            }
                        }

                        if(carro.placa.Length > 7 || carro.placa.Length < 7)
                        {
                            Console.WriteLine("A placa é maior ou menor do que o tamanho padrão!");

                            p = "f";
                        }
                    }

                    Console.WriteLine("Insira o modelo do carro: ");
                    carro.Modelo = Console.ReadLine();

                    Console.WriteLine("Insira a marca do carro: ");
                    carro.marca = Console.ReadLine();

                    Console.WriteLine("Insira a cor do carro: ");
                    carro.cor = Console.ReadLine();

                    Console.WriteLine("Insira o ano do carro: ");
                    carro.ano = int.Parse(Console.ReadLine());

                    lista.Add(carro);

                    Console.WriteLine(carro.display());

                    Console.WriteLine("Deseja continuar? S - Sim N - Não");
                    string cont = Console.ReadLine().ToUpper();

                    if (cont == "S")
                    {
                        continuar++;
                    }
                    else
                    {
                        return;
                    }
                }

                if (operacao == "D")
                {
                    Console.Clear();

                    Console.WriteLine("Insira a placa do carro que deseja deletar: ");
                    string placaD = Console.ReadLine();

                    for (int k = 0; k < lista.Count; k++)
                    {
                        if (placaD == lista[k].placa)
                        {
                            lista.RemoveAt(k);
                        }
                    }

                    Console.WriteLine("Deseja continuar? S - Sim N - Não");
                    string cont = Console.ReadLine().ToUpper();

                    if (cont == "S")
                    {
                        continuar++;
                    }
                    else
                    {
                        return;
                    }
                }

                if (operacao == "E")
                {
                    Console.Clear();

                    Console.WriteLine("Insira a placa do carro que deseja alterar: ");
                    string placaE = Console.ReadLine();

                    for (int pos = 0; pos < lista.Count; pos++)
                    {
                        if (lista[pos].placa == placaE)
                        {
                            lista.RemoveAt(pos);

                            Carro carro = new Carro();

                            string p = "e";

                            while (p == "e")
                            {
                                Console.WriteLine("Insira a placa do carro: ");
                                carro.placa = Console.ReadLine();

                                string erro = "a";

                                foreach (Carro car in lista)
                                {
                                    if (car.placa == carro.placa)
                                    {
                                        Console.WriteLine("Essa placa já existe!");

                                        erro = "e";

                                        break;
                                    }
                                }

                                if (carro.placa.Length < 7 || carro.placa.Length > 8)
                                {
                                    Console.WriteLine("A placa tem mais ou menos que 7 digitos!");
                                }
                                else
                                {
                                    if (erro == "a")
                                    {
                                        p = "f";
                                    }
                                    else
                                    {
                                        p = "e";
                                    }

                                }
                            }
                            Console.WriteLine("Insira o modelo do carro: ");
                            carro.Modelo = Console.ReadLine();

                            Console.WriteLine("Insira a marca do carro: ");
                            carro.marca = Console.ReadLine();

                            Console.WriteLine("Insira a cor do carro: ");
                            carro.cor = Console.ReadLine();

                            Console.WriteLine("Insira o ano do carro: ");
                            carro.ano = int.Parse(Console.ReadLine());

                            lista.Add(carro);
                        }

                        Console.WriteLine("Deseja continuar? S - Sim N - Não");
                        string cont = Console.ReadLine().ToUpper();

                        if (cont == "S")
                        {
                            continuar++;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                if (operacao == "S")
                {
                    Console.WriteLine("Insira a placa do carro que você deseja consultar: ");
                    string placaS = Console.ReadLine();

                    foreach (Carro n in lista)
                    {
                        if (n.placa == placaS)
                        {
                            Console.WriteLine(n.display());
                        }
                    }

                    Console.WriteLine("Deseja continuar? S - Sim N - Não");
                    string cont = Console.ReadLine().ToUpper();

                    if (cont == "S")
                    {
                        continuar++;
                    }
                    else
                    {
                        return;
                    }
                }

                if (operacao == "C")
                {
                    foreach (Carro l in lista)
                    {
                        Console.WriteLine(l.display());
                    }

                    Console.WriteLine("Deseja continuar? S - Sim N - Não");
                    string cont = Console.ReadLine().ToUpper();

                    if (cont == "S")
                    {
                        continuar++;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}