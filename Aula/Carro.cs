using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula
{
    class Carro
    {
        private string modelo;

        public string Modelo 
        {
            get 
            { 
                return modelo; 
            }

            set 
            { 
                modelo = value; 
            } 
        }

        public string marca 
        { 
            get
            {
                return modelo;
            }
            set
            { 
                modelo += $" | {value}"; 
            }
        }

        public int ano;
        public string cor;
        public string semAno = "";
        public string placa;

        public Carro() 
        { 

        }

        public Carro(string Modelo, string marca, int ano, string cor)
        {
            this.Modelo = Modelo;
            this.cor = cor; 
            this.marca = marca;
            this.ano = ano;
        }

        public Carro(string Modelo, string marca, int ano)
        {
            this.Modelo = Modelo;
            this.marca = marca;
            this.ano = ano;
            this.cor = "Não informado";
        }

        public Carro(string Modelo, string marca)
        {
            this.Modelo = Modelo;
            this.marca = marca;
            this.semAno = "Não informado";
            this.cor = "Não informado";
        }

        public Carro(string Modelo, string marca, string cor)
        {
            this.Modelo = Modelo;
            this.marca = marca;
            this.semAno = "Não informado";
            this.cor = cor;
        }

        public string display()
        {
            if(semAno != "")
            {
                return $"Ano: {semAno}\nModelo: {modelo}\nCor: {cor}\nPlaca: {placa}\n\n";
            }
            else
            {
                return $"Ano: {ano}\nModelo: {modelo}\nCor: {cor}\nPlaca: {placa}\n\n";
            }
        }
    }
}
