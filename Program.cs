using System;

namespace HomeWork01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int m = 0;
            String s = " ";
            String r = " ";
            double r1 = 0;
            Console.WriteLine("Please write the first number");
            r = Console.ReadLine();
            n=Int32.Parse(r);
            Console.WriteLine("\n");
            Console.WriteLine("Please write the second number");
            r = Console.ReadLine();
            m = Int32.Parse(r);
            Console.WriteLine("\n");
            Console.WriteLine("Please write the Opreater");
            s = Console.ReadLine();
            Console.WriteLine("\n");
            switch (s){
                case "+":  r1 = n + m;break;
                case "-":r1 = n - m;break;
                case "*":r1 = n * m;break;
                case "/":r1 = n / m;break;
                default:
                    r1 = 0;
                    Console.WriteLine("符号有误");
                    break;
                }
            Console.WriteLine("\n");
            Console.WriteLine(r1);
            




        }
    }
}
