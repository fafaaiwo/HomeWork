using System;

namespace HomeWork01
{
    class C2
    {
        static void findMax(int[] a)
        {
            int max = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            Console.WriteLine("最大值：" + max);
        }
        static void findMin(int[] a)
        {
            int min = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            Console.WriteLine("最小值：" + min);
        }
        static void findAverage(int[] a)
        {
            double ave; int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum = sum + a[i];
            }
            int n = a.Length;
            ave = sum / n;
            Console.WriteLine("平均值：" + ave);
            Console.WriteLine("总和：" + sum);
        }
        static void Main(string[] args)
        {
            int[] a = { 1, 4, 6, 7, 3, 5 };
            findMax(a);
            findAverage(a);
            findMin(a);
        }
    }

}


