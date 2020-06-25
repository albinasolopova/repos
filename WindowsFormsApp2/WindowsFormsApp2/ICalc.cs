using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    interface ICalc
    {
        double a { get; set; }
        void Save(double a);
        double Substract(double b);
        double Miltiply(double b);
        double Sum(double b);
        double Division(double b);
        double Sqrt();
        void Clear();
    }
}
