using System;

namespace Практическая_работа_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            double s = 0;
            double a = 1;
            double e = Convert.ToDouble(Console.ReadLine());
            while (a >= e)
            {
                i++;
                a = (1.0 / (i * i));
                s += a;
            }
            Console.WriteLine(s);
        }            
    }
}
