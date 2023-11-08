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
                Produto produto = new Produto();

                produto.id = int.Parse(Console.ReadLine());
                produto.desc = Console.ReadLine();
                produto.preco = double.Parse(Console.ReadLine());

                if(produtos.Count > 0)
                {
                    adiciona(produtos, produto);
                }
                else
                {
                    produtos.AddFirst(produto);                   
                }

                Console.WriteLine("Continuar? S - sim");
                p = Console.ReadLine().ToUpper();

                foreach (Produto n in produtos)
                {
                    Console.WriteLine(n.toString());
                }
            }
        }

        static void adiciona(LinkedList<Produto> produtos, Produto produto)
        {
            foreach (Produto x in produtos)
            {
                if (x.desc == produto.desc)
                {
                    Console.WriteLine("Produto duplicado!");
                }
                else
                {
                    produtos.AddFirst(produto);
                }
            }
        }
    }
}