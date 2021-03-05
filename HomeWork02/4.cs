using System;

namespace HomeWork01
{
    class Program
    {
        static bool isTPMatrix(int[][] a)
        {

            for (int i = 1; i < a.Length; i++)
            {
                for (int j = 1; j < a[i].Length; j++)
                {
                    if (a[i][j] != a[i - 1][j - 1])

                        return false;


                }

            }
            return true;

        }
        static void Main(string[] args)
        {
            int[][] a = new int[3][];
            a[0] = new int[4] { 1, 2, 3, 4 };
            a[1] = new int[4] { 5, 1, 2, 3 };
            a[2] = new int[4] { 9, 5, 1, 2 };
            Console.WriteLine(isTPMatrix(a));

            int[][] b = new int[2][];
            b[0] = new int[2] { 1, 2 };
            b[1] = new int[2] { 2, 2 };
            Console.WriteLine(isTPMatrix(b));

        }
    }

}


