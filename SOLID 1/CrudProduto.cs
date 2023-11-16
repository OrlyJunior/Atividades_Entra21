namespace SOLID_1
{
    class CrudProduto
    {
        List<Produto> produtos = new();

        public bool salvar(Produto produto)
        {
            Console.Clear();

            bool id = true;

            bool existe = false;

            while (id == true)
            {
                Console.WriteLine("Insira o id do Produto:");
                produto.Id = int.Parse(Console.ReadLine());

                foreach (Produto i in produtos)
                {
                    if (produto.Id == i.Id)
                    {
                        Console.WriteLine("Já existe um produto com esse id!");

                        existe = true;

                        break;
                    }
                    else
                    {
                        existe = false;
                    }
                }

                if (existe == false)
                {
                    id = false;
                }
            }

            Console.WriteLine("Insira a descrição do Produto:");
            produto.Descricao = Console.ReadLine();

            Console.WriteLine("Insira o preço do Produto:");
            produto.Preco = double.Parse(Console.ReadLine());


            produtos.Add(produto);

            Console.WriteLine("Produto adicionado com sucesso.");

            return true;
        }

        public bool consultar()
        {
            Console.WriteLine("Insira o id que quer encontrar:");
            int consulta = int.Parse(Console.ReadLine());

            bool encontrou = false;

            foreach (Produto i in produtos)
            {
                if (i.Id == consulta)
                {
                    Console.WriteLine(i.toString());

                    encontrou = true;

                    break;
                }
            }

            if (encontrou == false)
            {
                Console.WriteLine("Esse produto não existe!");
            }

            return true;
        }

        public bool consultarTodos()
        {
            foreach (Produto i in produtos)
            {
                Console.WriteLine(i.toString());
            }

            if (produtos.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados!");
            }

            return true;
        }

        public bool deletar()
        {
            Console.WriteLine("Insira o id do produto que deseja deletar: ");
            int deleta = int.Parse(Console.ReadLine());

            bool encontrou = false;

            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i].Id == deleta)
                {
                    produtos.RemoveAt(i);

                    Console.WriteLine("Produto deletado com sucesso.");

                    encontrou = true;

                    break;
                }
            }

            if (encontrou == false)
            {
                Console.WriteLine("Esse produto não existe!");
            }

            return true;
        }

        public bool alterar()
        {
            Produto produto = new();

            Console.WriteLine("Insira o novo id do Produto:");
            produto.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a nova descrição do Produto:");
            produto.Descricao = Console.ReadLine();

            Console.WriteLine("Insira o novo preço do Produto:");
            produto.Preco = double.Parse(Console.ReadLine());

            Console.WriteLine("Insira o id do produto que deseja alterar: ");
            int altera = int.Parse(Console.ReadLine());

            bool encontrou = false;

            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i].Id == altera)
                {
                    produtos[i] = produto;

                    Console.WriteLine("Produto alterado com sucesso.");

                    encontrou = true;
                    break;
                }
            }

            if (encontrou == false)
            {
                Console.WriteLine("Esse produto não existe!");
            }

            return true;
        }
    }
}