using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkC
{
    class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float price;

        public Goods(int id, string name, float price)
        {
            this.Id = id;
            this.Name = name;
            this.price = price;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null &&
                   Id == goods.Id;
        }
        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Value:{price}";
        }
    }
    class Customer
    {
        public string name { get; set; }
        public string paymethod { get; set; }
        public int phonenumber { get; set; }

        public Customer()
        {
            name = null;
            paymethod = null;
            phonenumber = 0000;
        }
        public Customer(string name, string paymethod, int phonenumber)
        {
            this.name = name;
            this.paymethod = paymethod;
            this.phonenumber = phonenumber;
        }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   name == customer.name &&
                   paymethod == customer.paymethod &&
                   phonenumber == customer.phonenumber;
        }

        public override string ToString()
        {
            return "Customer name:" + name + "\n" + "Customer phonenumber:" + phonenumber + "\n" + "Customer paymethod:" + paymethod + "\n";
        }
    }
    class OrderDetails
    {

        public Goods goods { get; set; }
        public float acount;


        public OrderDetails(Goods goods)
        {
            this.goods = goods;

        }
        public float getacount()
        {
            acount = goods.price;
            return acount;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<Goods>.Default.Equals(goods, details.goods) &&
                   acount == details.acount;
        }

        public override string ToString()
        {
            return $"OrderDetail:{goods},{acount}";
        }
    }
    class Order : IComparable<Order>
    {
        public Customer customer { get; set; }
        public int id;
        public List<OrderDetails> Details = new List<OrderDetails>();



        public Order(Customer customer, int id)
        {
            this.id = id;
            this.customer = customer;
        }
        public double getAcount()
        {
            double totalacount = 0.0;
            for (int i = 0; i < Details.ToArray().Length; i++)
            {
                totalacount += Details[i].acount;
            }
            return totalacount;
        }
        public void addDetails(OrderDetails orderDetails)
        {
            if (Details.Contains(orderDetails))
            {
                Console.WriteLine("已包含该订单");
            }
            else
            {
                Details.Add(orderDetails);
            }
        }
        public void removeDetails(OrderDetails orderDetails)
        {
            if (Details.Contains(orderDetails))
            {
                Details.Remove(orderDetails);
            }
            else
            {
                Console.WriteLine("删除失败");
            }

        }

        public int CompareTo(Order other)
        {
            if (other == null)
                return 1;
            return id - other.id;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   EqualityComparer<Customer>.Default.Equals(customer, order.customer) &&
                   id == order.id &&
                   EqualityComparer<List<OrderDetails>>.Default.Equals(Details, order.Details);
        }

        public override string ToString()
        {
            for (int i = 0; i < Details.ToArray().Length; i++)
            {
                Console.WriteLine(Details[i]);
            }
            return $"Id:{id}, customer:({customer})"; ;
        }
    }


    class OrderService
    {
        public List<Order> orders = new List<Order>();

        public void addOrder(Order order)
        {
            if (orders.Contains(order))
            {
                Console.WriteLine("已包含该订单");
            }
            else
            {
                orders.Add(order);
            }
        }
        public void removeOrder(Order order)
        {
            if (orders.Contains(order))
            {
                orders.Remove(order);
            }
            else
            {
                Console.WriteLine("未找到该订单");
            }
        }


        public List<Order> FindByGoodName(string name)
        {
            var query = orders.Where(s => s.Details.Any(o => o.goods.Name == name));
            List<Order> listname = query.ToList();
            listname.Sort((p1, p2) => (int)(p1.getAcount() - p2.getAcount()));
            return listname;

        }
        public List<Order> FindByCustomer(string customername)
        {
            var query = orders
           .Where(o => o.customer.name == customername);
            List<Order> listname = query.ToList();
            listname.Sort((p1, p2) => (int)(p1.getAcount() - p2.getAcount()));
            return listname;
        }
        public void Sort(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Goods goods0 = new Goods(1, "rice", 20);
            Goods goods1 = new Goods(2, "phone", 3000);
            Goods goods2 = new Goods(3, "flower", 40);
            Goods goods3 = new Goods(4, "flower", 30);
            Customer customer = new Customer("huahua", "wechat", 2900);
            Customer customer1 = new Customer("caocao", "phone", 0832);
            OrderDetails orderDetails0 = new OrderDetails(goods0);
            OrderDetails orderDetails1 = new OrderDetails(goods1);
            OrderDetails orderDetails2 = new OrderDetails(goods2);
            OrderDetails orderDetails3 = new OrderDetails(goods3);
            Order order = new Order(customer, 01);
            Order order2 = new Order(customer1, 03);
            order.addDetails(orderDetails0);
            order.addDetails(orderDetails1);
            order2.addDetails(orderDetails2);
            order2.addDetails(orderDetails3);
            OrderService orderService = new OrderService();
            orderService.addOrder(order);
            orderService.addOrder(order2);
            List<Order> orders = orderService.FindByCustomer("huahua");
            orders.ForEach(o => Console.WriteLine(o));




        }
    }

}


