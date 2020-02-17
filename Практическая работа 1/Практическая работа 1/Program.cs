using System;

namespace Практическая_работа_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = Convert.ToDouble(Console.ReadLine());
            double y;
            if (x <= -1)
            {
                y = 1 / x;
            }
            else if(x >= 2)
            {
                y = 4;
            }
            else
            {
                y = x * x;
            }
            Console.WriteLine(y);
            Console.ReadLine();
        }
    }
}
