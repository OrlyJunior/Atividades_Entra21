using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessaBancoDeDados.Entidades
{
    public class Contato
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Numero { get; set; }

        public string Cidade { get; set; }

        public Contato() { }

        public Contato(string nome, string numero, string cidade)
        {
            this.Nome = nome;
            this.Numero = numero;
            this.Cidade = cidade;
        }

        public string toString()
        {
            return $"Id: {Id}\nNome: {Nome}\nNúmero: {Numero}\nCidade: {Cidade}\n";
        }
    }
}