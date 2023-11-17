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

            Console.WriteLine("Insira o numero:");
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
    }
}