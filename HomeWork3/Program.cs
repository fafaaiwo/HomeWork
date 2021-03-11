using System;

namespace HomeWork01
{
    public class ShapeFactory
    {
        public static shape createShape(string s)
        {
            shape sp = null;
            switch (s){
                case "三角形":
                    sp = new triangle();
                    break;
                case "矩形":
                    sp = new rectangle();
                    break;
                case "正方形":
                    sp = new square();
                    break;
                default:
                    throw new Exception("参数错误");                   
            }
            return sp;
        }
    }

    class Program
    {      
        static void Main(string[] args)
        {
            double totalArea=0;
            Random random = new Random();
            string[] a = { "正方形", "矩形", "三角形" };
            for (int i = 0; i <= 10; i++)
            {
                int rand = random.Next(0, 3);
                shape Sp = ShapeFactory.createShape(a[rand]);
                Sp.set();
                totalArea += Sp.getMeasure();
            }
            Console.WriteLine(totalArea);
            
        }
    }

}


