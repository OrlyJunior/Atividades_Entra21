namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, List<Produto>> produtos = new SortedList<string, List<Produto>>();

            bool p = true;

            while (p)
            {
                p = false;

                Console.WriteLine("Qual operação deseja realizar?");
                Console.WriteLine("1 - Adicionar produto");
                Console.WriteLine("2 - Adicionar categoria");
                Console.WriteLine("3 - Listar produtos");

                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    adiciona(produtos);

                    Console.WriteLine("Deseja continuar? S - Sim");
                    string cont = Console.ReadLine().ToUpper();

                    if (cont == "S")
                    {
                        p = true;
                    }
                }

                if (op == 2)
                {
                    addCategoria(produtos);

                    Console.WriteLine("Deseja continuar? S - Sim");
                    string cont = Console.ReadLine().ToUpper();

                    if (cont == "S")
                    {
                        p = true;
                    }
                }

                if (op == 3)
                {
                    consulta(produtos);
                }
            }

            static void adiciona(SortedList<string, List<Produto>> produtos)
            {
                Console.Clear();

                Console.WriteLine("Insira a categoria do produto:");
                string categoria = Console.ReadLine();

                Produto produto = new Produto();

                Console.WriteLine("Insira o id do produto:");
                produto.Id = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira a descrição do produto:");
                produto.Desc = Console.ReadLine();

                Console.WriteLine("Insira o preço do produto: ");
                produto.Preco = double.Parse(Console.ReadLine());

                foreach(KeyValuePair<string, List<Produto>> pos in produtos)
                {
                    if (produtos.ContainsKey(categoria))
                    {
                        pos.Value.Add(produto);
                    }
                }
            }

            static void addCategoria(SortedList<string, List<Produto>> categorias)
            {
                List<Produto> lista = new List<Produto>();

                Console.WriteLine("Insira o nome da categoria:");
                string cate = Console.ReadLine();

                categorias.Add(cate, lista);
            }

            static void consulta(SortedList<string, List<Produto>> produtos)
            {
                Console.WriteLine("Insira a categoria que deseja mostrar:");
                string cat = Console.ReadLine();

                foreach(KeyValuePair<string, List<Produto>> posV in produtos)
                {
                    foreach(Produto p in posV.Value)
                    {
                        Console.WriteLine(p.toString());
                    }
                }
            }
        }
    }
}