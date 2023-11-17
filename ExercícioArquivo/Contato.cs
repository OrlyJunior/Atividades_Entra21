using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercícioArquivo
{
    class Contato
    {
        public string nome;
        public int numero;
        public string endereco;
        public int idade;
        public int id;

        public string ToString()
        {
            return $"Id: {id}\nNome: {nome}\nEndereço: {endereco}\nNúmero: {numero}\nIdade: {idade}\n";
        }
    }
}
