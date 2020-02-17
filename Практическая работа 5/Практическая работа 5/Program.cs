using System;

namespace Практическая_работа_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Reshenie(n));
        }
        static bool Reshenie(int n)
        {
            int s = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                    s += i;
            }
            if (s == n)
                return true;
            else
                return false;
        }
    }
}
