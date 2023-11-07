using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto
{
    class Moto 
    {
        public string modelo;
        public string marca;
        public int cilindradas;
        public string cor;

        public Moto()
        {

        }

        public Moto(string modelo, string marca, int cilindradas, string cor)
        {
            this.modelo = modelo;
            this.marca = marca;
            this.cilindradas = cilindradas;
            this.cor = cor;
        }

        public string toString()
        {
            return $"Modelo: {modelo}\nMarca: {marca}\nCilindradas: {cilindradas}";
        }
    }
}
