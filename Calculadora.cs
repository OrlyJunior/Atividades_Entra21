using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Calculadora : ICalculadora
    {
        public double Resultado {  get; set; }

        public double Divisao(double x, double y)
        {
            Resultado = x / y;

            if(y != 0)
            {
                return Resultado;
            }
            else
            {
                throw new ArgumentException(nameof(Resultado), "Essa divisão é impossível!");
            }
        }

        public double Multiplicacao(double x, double y)
        {
            Resultado = x * y;

            if (y != 0 || x != 0)
            {
                return Resultado;
            }
            else
            {
                throw new ArgumentException(nameof(Resultado), "Essa multiplicação é impossível!");
            }
        }

        public double Soma(double x, double y)
        {
            Resultado = x + y;

            if (y != 0 || x != 0)
            {
                return Resultado;
            }
            else
            {
                throw new ArgumentException(nameof(Resultado), "Essa soma é impossível!");
            }
        }

        public double Subtracao(double x, double y)
        {
            Resultado = x - y;

            if (y != 0 || x != 0)
            {
                return Resultado;
            }
            else
            {
                throw new ArgumentException(nameof(Resultado), "Essa subtração é impossível!");
            }
        }
    }
}
