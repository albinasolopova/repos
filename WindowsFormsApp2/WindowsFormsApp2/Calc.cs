using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Calc : ICalc
    {
        public double a { get ; set ; }

        public void Clear()
        {
            this.a = 0;
        }

        public double Division(double b)
        {
            return a / b;
        }

        public double Miltiply(double b)
        {
            return a * b;
        }

        public void Save(double a)
        {
            this.a = a;
        }

        public double Substract(double b)
        {
            return a - b;
        }

        public double Sum(double b)
        {
            return a + b;
        }
        public double Sqrt ()
        {
            return Math.Sqrt(a);
        }
    }
}
