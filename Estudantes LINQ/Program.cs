namespace Estudantes_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new()
            {
                new Student { NomeCompleto = "Svetlana",Id = 111,  Notas = new List<int> { 97, 92, 81, 60 } },
                new Student { NomeCompleto = "Claire",  Id = 112,  Notas = new List<int> { 75, 84, 91, 39 } },
                new Student { NomeCompleto = "Sven",    Id = 113,  Notas = new List<int> { 88, 94, 65, 91 } },
                new Student { NomeCompleto = "Cesar",   Id = 114,  Notas = new List<int> { 97, 89, 85, 82 } },
                new Student { NomeCompleto = "Debra",   Id = 115,  Notas = new List<int> { 35, 72, 91, 70 } },
                new Student { NomeCompleto = "Fadi",    Id = 116,  Notas = new List<int> { 99, 86, 90, 94 } },
                new Student { NomeCompleto = "Hanying", Id = 117,  Notas = new List<int> { 93, 92, 80, 87 } },
                new Student { NomeCompleto = "Hugo",    Id = 118,  Notas = new List<int> { 92, 90, 83, 78 } },
                new Student { NomeCompleto = "Lance",   Id = 119,  Notas = new List<int> { 68, 79, 88, 92 } },
                new Student { NomeCompleto = "Terry",   Id = 120,  Notas = new List<int> { 99, 82, 81, 79 } },
                new Student { NomeCompleto = "Eugene",  Id = 121,  Notas = new List<int> { 96, 85, 91, 60 } },
                new Student { NomeCompleto = "Michael", Id = 122,  Notas = new List<int> { 94, 92, 91, 91 } }
            };

            bool cont = true;

            while (cont == true)
            {
                Console.Clear();

                Console.WriteLine("Que operação deseja realizar?\n1 - Ver alunos aprovados\n2 - Ver alunos reprovados\n3 - Ver alunos em ordem alfabética\n4 - Consultar aluno pelo ID\n5 - Consultar a maior nota e a maior média\n6 - Consultar a menor nota e a menor média");
                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    var alunos =
                        from notas in students
                        where notas.Notas.Average() > 80
                        orderby notas.Notas.Average()
                        select notas;

                    foreach (Student i in alunos)
                    {
                        Console.WriteLine(i.toString());
                        Console.WriteLine("Situação: Aprovado\n\n");
                    }

                    Console.ReadKey();
                }

                if (op == 2)
                {
                    var alunos =
                        from notas in students
                        where notas.Notas.Average() < 80
                        orderby notas.Notas.Average()
                        select notas;

                    foreach (Student i in alunos)
                    {
                        Console.WriteLine(i.toString());
                        Console.WriteLine("Situação: Reprovado\n\n");
                    }

                    Console.ReadKey();
                }

                if (op == 3)
                {
                    var alunos =
                        from notas in students
                        orderby notas.NomeCompleto
                        select notas;

                    foreach (Student i in alunos)
                    {
                        Console.WriteLine($"{i.toString()}\n\n");
                    }

                    Console.ReadKey();
                }

                if (op == 4)
                {
                    Console.WriteLine("Insira o ID do aluno que deseja achar:");
                    int id = int.Parse(Console.ReadLine());

                    var aluno =
                        from alunoP in students
                        where alunoP.Id == id
                        select alunoP;

                    Console.WriteLine($"\n{aluno.ToList()[0].toString()}");

                    Console.ReadKey();
                }

                if (op == 5)
                {
                    var maior =
                        from notas in students
                        select notas.Notas.Average();

                    var maiorN =
                        from notas in students
                        select notas.Notas.Max();

                    Console.WriteLine($"Maior média: {maior.ToList().Max()}\nMaior nota: {maiorN.ToList().Max()}");

                    Console.ReadKey();
                }

                if (op == 6)
                {
                    var maior =
                        from notas in students
                        select notas.Notas.Average();

                    var maiorN =
                        from notas in students
                        select notas.Notas.Min();

                    Console.WriteLine($"Menor média: {maior.ToList().Min()}\nMenor nota: {maiorN.ToList().Min()}");

                    Console.ReadKey();
                }
            }
        }
    }
}