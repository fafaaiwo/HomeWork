using System;

namespace HomeWork01
{
    class Program
    {
        static void isFactor()
        {

            for (int i = 2; i <= 100; i++)
            {
                bool factor = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        factor = false;
                        break;
                    }


                }
                if (factor)
                {
                    Console.Write(i);
                    Console.Write("  ");
                }


            }
        }
        static void Main(string[] args)
        {
            isFactor();
        }
    }

}


