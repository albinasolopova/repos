using System;

namespace Практическая_работа_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int m = 3;
            int[,] a = CreateArray(n, m);
            for (int j = 0; j < m; j++)
            {
                int max = 25;
                int IndexOfMax = 0;
                int min = a[0, j];
                for (int i = 0; i < n; i++)
                {
                    if (a[i, j] > max)
                    {
                        max = a[i, j];
                        IndexOfMax = i;
                    }
                }
                for (int k = 0; k < m; k++)
                {
                    if (a[IndexOfMax, k] < min)
                    {
                        min = a[IndexOfMax, k];
                    }
                }
                if (max == min)
                {
                    Console.WriteLine(IndexOfMax + ", " + j);
                    Console.ReadLine();
                }
                else
                    Console.WriteLine("Нет седловой точки");

            }
        }

        static int[,] CreateArray(int n, int m)
        {
            int[,] a = new int[n, m];
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rand.Next(-100, 100);
                    Console.Write(a[i, j] + ",");
                }
                Console.WriteLine();
            }
            return a;
        }
    }
}
