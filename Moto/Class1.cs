using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto
{
    internal class Normal : Moto
    {
        public string placa;

        public Normal()
        {

        }

        public Normal(string modelo, string marca, int cilindradas, string cor, string placa) : base(modelo, marca, cilindradas, cor)
        {
            this.placa = placa;
        }

        public string toString()
        {
            string padrao = base.toString();
            return $"\n{padrao}\nPlaca: {placa}";
        }
    }
}
