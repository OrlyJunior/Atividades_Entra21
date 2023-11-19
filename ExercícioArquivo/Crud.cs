namespace ExercícioArquivo
{
    class Crud
    {
        //Ao testar, a variável path deve ser mudada para o local onde o projeto está em seu computador
        string path = @"C:\Users\Orly\Documents\ArquivosE21\ExercícioArquivo\bin\Debug\net6.0\contatos.txt";

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

                Console.WriteLine("\nContato adicionado com sucesso.");

                return;
            }
            else
            {
                using (StreamWriter st = File.AppendText(path))
                {
                    st.WriteLine(contato.ToString());
                }

                Console.WriteLine("\nContato adicionado com sucesso.");

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
            string id = $"Id: {Console.ReadLine()}";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (StreamWriter sr = File.CreateText(path))
            {
                for (int i = 0; i < contatos.Count; i++)
                {
                    if (contatos[i].Equals(id))
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

            Console.WriteLine("Insira o id do contato que deseja deletar:");
            string id = $"Id: {Console.ReadLine()}";

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

            for (int i = 0; i < contatos.Count; i++)
            {
                if (contatos[i].Equals(id))
                {
                    contatos[i] = $"Id: {idNovo}";
                    contatos[i + 1] = $"Nome: {nomeNovo}";
                    contatos[i + 2] = $"Número: {numeroNovo}";
                    contatos[i + 3] = $"Endereço: {enderecoNovo}";
                    contatos[i + 4] = $"Idade: {idade}";
                }
            }

            using (StreamWriter sr = File.CreateText(path))
            {
                for (int j = 0; j < contatos.Count; j++)
                {
                    sr.WriteLine(contatos[j]);
                }
            }
        }

        public void listaId()
        {
            List<string> contatos = new List<string>();

            int escreve = 0;

            using (StreamReader sr = File.OpenText(path))
            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    contatos.Add(s);
                }
            }

            Console.WriteLine("Insira o id que deseja consultar:");
            string idConsulta = $"Id: {Console.ReadLine()}";

            foreach(string i in contatos)
            {
                if (i.Equals(idConsulta) || escreve != 0)
                {
                    while (escreve < 5)
                    {
                        Console.WriteLine(i);

                        escreve++;

                        break;
                    }

                    if(escreve == 5)
                    {
                        escreve = 0;
                    }
                }
            }
        }
    }
}