namespace ExercícioArquivo
{
    class Crud
    {
        string path = @"C:\Users\orly.junior\Documents\ExercícioArquivo\contatos.txt";

        public void add()
        {
            Contato contato = new();

            Console.WriteLine("Insira o id:");
            contato.id = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o nome:");
            contato.nome = Console.ReadLine();

            Console.WriteLine("Insira o número:");
            contato.numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o endereço:");
            contato.endereco = Console.ReadLine();

            Console.WriteLine("Insira a idade:");
            contato.idade = int.Parse(Console.ReadLine());

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(contato.ToString());
                }

                return;
            }
            else
            {
                using (StreamWriter st = File.AppendText(path))
                {
                    st.WriteLine(contato.ToString());
                }

                return;
            }
        }

        public void show()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public void deletar()
        {
            List<string> contatos = new List<string>();

            using (StreamReader sr = File.OpenText(path))
            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    contatos.Add(s);
                }
            }

            Console.WriteLine("Insira o id do contato que deseja deletar:");
            string id = Console.ReadLine();

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (StreamWriter sr = File.CreateText(path))
            {
                for (int i = 0; i < contatos.Count; i++)
                {
                    if (contatos[i].Contains(id))
                    {
                        contatos.RemoveAt(i);
                        contatos.RemoveAt(i);
                        contatos.RemoveAt(i);
                        contatos.RemoveAt(i);
                        contatos.RemoveAt(i);
                        contatos.RemoveAt(i);
                    }

                    
                }

                for (int j = 0; j < contatos.Count; j++)
                {
                    sr.WriteLine(contatos[j]);
                }
            }
        }

        public void alterar()
        {
            List<string> contatos = new List<string>();



            using (StreamReader sr = File.OpenText(path))
            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    contatos.Add(s);
                }
            }

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Console.WriteLine(contatos[4]);

            Console.WriteLine("Insira o id do contato que deseja deletar:");
            string id = Console.ReadLine();

            Console.WriteLine("Insira o novo id do contato:");
            string idNovo = Console.ReadLine();

            Console.WriteLine("Insira o novo nome do contato:");
            string nomeNovo = Console.ReadLine();

            Console.WriteLine("Insira o novo número do contato:");
            string numeroNovo = Console.ReadLine();

            Console.WriteLine("Insira o novo endereço do contato:");
            string enderecoNovo = Console.ReadLine();

            Console.WriteLine("Insira a nova idade do contato: ");
            string idade = Console.ReadLine();

            using (StreamWriter sr = File.CreateText(path))
            {
                for (int i = 0; i < contatos.Count; i++)
                {
                    if (contatos[i].Contains(id))
                    {
                        contatos[i] = $"Id: {idNovo}";
                        contatos[i + 1] = $"Nome: {nomeNovo}";
                        contatos[i + 2] = $"Número: {numeroNovo}";
                        contatos[i + 3] = $"Endereço: {enderecoNovo}";

                        Console.WriteLine(contatos[i + 4]);

                        contatos[i + 4] = $"Idade: {idade}";
                    }
                }

                for (int j = 0; j < contatos.Count; j++)
                {
                    sr.WriteLine(contatos[j]);
                }
            }
        }
    }
}