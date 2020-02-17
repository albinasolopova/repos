using System;

namespace Практическая_работа_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = 5;
            double a = 0;
            double s = 0;
            for (int i = 1; i <=n; i++)
            {
                a  = 1.0 + (1.0 / (i * i));
                s += a; 
            }
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
