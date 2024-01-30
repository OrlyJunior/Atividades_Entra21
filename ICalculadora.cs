using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public interface ICalculadora
    {
        public double Soma(double x, double y);
        public double Subtracao(double x, double y);
        public double Multiplicacao(double x, double y);
        public double Divisao(double x, double y);
    }
}
