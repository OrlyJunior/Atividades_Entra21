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
        public string placa;
        public string semAno = "Não informado";

        public string display()
        {
            if(semAno != "")
            {
                return $"\nPlaca: {placa}\nModelo: {modelo}\nCor: {cor}\nAno: {ano}\n";
            }
            else
            {
                return $"\nPlaca: {placa}\nModelo: {modelo}\n Cor: {cor}\nAno: {semAno}\n";
            }
        }
    }
}
