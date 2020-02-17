using System;

namespace Пактическая_работа_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int m = 4;
            int[,] mas = CreateArray(n, m);
            bool[] v = Vector1(n,m, mas);
            bool[] v2 = Vector2(n, m, mas);
            bool[] v3 = Vector3(n, m, mas);
            Console.Read();
        }
        static int[,] CreateArray(int n, int m)
        {
            int[,] mas = new int[n, m];
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = rand.Next(-100, 100);
                    Console.Write(mas[i, j] + ",");
                }
                Console.WriteLine();
            }
            return mas;
        }
        static bool[] Vector1(int n,int m, int[,] mas)
        {
            bool[] v =  new bool[m];
            for (int j = 0; j<m; j++)
            {
                v[j] = true;
                for ( int i=0; i<n; i++)
                {
                    if (mas[i, j] != 0) v[j] = false;
                    Console.Write(v[j] + ",");
                }
                Console.WriteLine();
            }
            return v;
        }
        static bool[] Vector2(int n, int m, int[,] mas)
        {
            bool[] v2 = new bool[n];
           for(int i = 0; i < n; i++)
            {
                v2[i] = true;
                for(int j=1; j<m; j++)
                {
                    if (mas[i, j] > mas[i, j - 1]) v2[i] = false;
                    Console.Write(v2[j] + ",");
                }
                Console.WriteLine();
            }
            return v2;
        }
        static bool[] Vector3(int n, int m, int[,] mas)
        {
            bool[] v3 = new bool[n];
            for (int i = 0; i < n; i++)
            {
                v3[i] = true;
                for (int j = 0; j < m; j++)
                {
                    if (mas[i, j] == mas[i, m-j-1]) v3[j] = false;
                    Console.Write(v3[j]+",");
                }
                Console.WriteLine();
            }
            return v3;
        }
    }
}