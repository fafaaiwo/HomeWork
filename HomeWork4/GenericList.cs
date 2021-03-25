using System;

namespace HomeWorkC
{
    class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void Foreach(Action<T> action)
        {
            Node<T> node = this.head;
            while (node != null)
            {
                action(node.Data);
                node = node.Next;
            }
        }
    }
    //为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。
    //通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。

    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            Console.WriteLine("打印如下");
            intlist.Foreach(m => Console.WriteLine(m));
            int max = 0, min = 0;
            intlist.Foreach(m =>
            {
                if (m > max)
                {
                    max = m;
                }
            }
            );
            intlist.Foreach(m =>
            {
                if (m < min)
                {
                    min = m;
                }
            });
            Console.WriteLine($"最大值为{max},元素最小值为{min}");
            int sum = 0;
            intlist.Foreach(m => sum += m);
            Console.WriteLine($"和为{sum}");
            int n = 0;
            intlist.Foreach(m => n++);
            Console.WriteLine($"元素平均值为{(double)sum / (double)n}");





        }
    }

}


