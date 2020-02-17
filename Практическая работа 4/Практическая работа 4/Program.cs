using System;

namespace Практическая_работа_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            for (int i=2; i<=9; i++)
            {
                for (int j=10; j<=99; j++)
                {
                    a = (j / 10) + (j % 10);
                    b = (i*j / 100) + (i*j % 100 / 10) + (i*j % 10);
                    if (a == b)
                    {
                        Console.Write(j +", ");
                    }
                }
                Console.WriteLine();
            }
            
        }
    }
}
