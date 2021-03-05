using System;

namespace HomeWork01
{
    class H1
    {

        static void isPNumber(int n)
        {
            if (n != 0)
            {
                bool istrue = true;
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        istrue = false;
                        break;
                    }
                }
                if (istrue == true)
                {
                    Console.WriteLine(n);
                }
            }
        }
        static int[] isFactor(int n)
        {
            int[] a = new int[100];
            int m = 0;
            for (int i = 2; i <= n; i++)
            {

                if (n % i == 0)
                {
                    a[m] = i;
                    m++;
                }

            }

            return a;

        }

        static void Main(string[] args)
        {

            Console.WriteLine("请输入想要计算的数据");

            int n;
            n = int.Parse(Console.ReadLine());
            int[] a = isFactor(n);
            Console.WriteLine("\n");
            for (int i = 0; i < a.Length; i++)
            {
                isPNumber(a[i]);
            }
        }
    }
}
