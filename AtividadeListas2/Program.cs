namespace AtividadeListas2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Produto> produtos = new LinkedList<Produto>();

            string p = "S";

            while (p == "S")
            {
                Console.Clear();

                Console.WriteLine("Selecione uma operação:");

                Console.WriteLine("1 - Adicionar produto");
                Console.WriteLine("2 - Listar produtos");
                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    Produto produto = new Produto();
                    Console.WriteLine("Informe o id: ");
                    produto.Id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Informe a descrição: ");
                    produto.Desc = Console.ReadLine();

                    Console.WriteLine("Informe o preço: ");
                    produto.Preco = double.Parse(Console.ReadLine());

                    adiciona(produtos, produto);

                    Console.WriteLine("Continuar? S - sim");
                    p = Console.ReadLine().ToUpper();
                }

                if(op == 2)
                {
                    foreach (Produto n in produtos)
                    {
                        Console.WriteLine(n.toString());
                    }

                    Console.WriteLine("Continuar? S - sim");
                    p = Console.ReadLine().ToUpper();
                }
            }
        }
        static void adiciona(LinkedList<Produto> produtos, Produto produto)
        {
            if(produtoExist(produtos, produto)){
                Console.WriteLine("Produto já cadastrado");
            }
            else
            {
                produtos.AddLast(produto);
            }            
        }

        static bool produtoExist(LinkedList<Produto> produtos, Produto produto)
        {
            foreach(Produto n in produtos)
            {
                if (n.Desc.Equals(produto.Desc))
                {
                    return true;
                }
            }
            return false;
        }
    }
}