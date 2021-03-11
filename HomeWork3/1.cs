using System;

namespace HomeWork01
{
    interface shape
    {
        double getMeasure();
    }

    class triangle : shape
    {
        private int a, b, c;//三角形的三边

        public triangle()
        {
            a = 0;
            b = 0;
            c = 0;
        }

        public triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public bool isTriangle()
        {
            if (a + b > c && a + c > b && b + c > a && a - b < c && a - c < b && b - c < a)
            {
                Console.WriteLine("三角形合法");
                return true;
            }
            else
            {
                Console.WriteLine("三角形不合法");
                return false;
            }

        }
        public double getMeasure()
        {
            double area = 0;
            if (isTriangle())
            {
                double p = (a + b + c) / 2;
                area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            return area;
        }
    }

    class rectangle : shape
    {
        private int a, b;

        public rectangle()
        {
            a = 0;
            b = 0;
        }

        public rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public double getMeasure()
        {
            return a * b;
        }

    }

    class square : shape
    {
        private int a;

        public square()
        {
            a = 0;
        }
        public square(int a)
        {
            this.a = a;
        }


        public double getMeasure()
        {
            return a * a;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            triangle A = new triangle(3, 4, 5);
            Console.WriteLine(A.isTriangle());
            Console.WriteLine(A.getMeasure());
            rectangle B = new rectangle(3, 4);
            Console.WriteLine(B.getMeasure());
            square C = new square(3);
            Console.WriteLine(C.getMeasure());

        }
    }

}


