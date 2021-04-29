using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWorkC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace HomeWorkC.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        OrderService or = new OrderService();

        Goods phone = new Goods(1, "apple", 6000);
        Goods ipad = new Goods(2, "Apple", 10000);
        Goods piano = new Goods(3, "huahua", 10000);
        Customer c1 = new Customer("flower", "wechat", 2900);
        Customer c2 = new Customer("hua", "phone", 3900);

        [TestInitialize]
        public void Init()
        {
            Order o1 = new Order(c1, 1);
            Order o2 = new Order(c2, 2);


            o1.addDetails(new OrderDetails(phone));
            o1.addDetails(new OrderDetails(ipad));
            o2.addDetails(new OrderDetails(piano));

            or.addOrder(o1);
            or.addOrder(o2);
        }
        [TestMethod]
        public void addOrder()
        {
            Order o3 = new Order(c2, 3);
            o3.addDetails(new OrderDetails(phone));
            or.addOrder(o3);
            List<Order> orders = or.QueryAll();
            Assert.AreEqual(3, orders.Count);
            CollectionAssert.Contains(orders, o3);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void removeOrderTest()
        {
            or.RemoveOrder(1);
            List<Order> orders = or.QueryAll();
            Assert.AreEqual(1, orders.Count);
        }

        [TestMethod()]
        public void FindByGoodNameTest()
        {
            Assert.AreEqual(1, or.FindByGoodName("phone"));
            Assert.AreEqual(2, or.FindByGoodName("ipad"));
        }

        [TestMethod()]
        public void FindByCustomerTest()
        {
            Assert.AreEqual(1, or.FindByCustomer("c1"));
        }

        [TestMethod()]
        public void ExportTest()
        {
            String file = "temp.xml";
            or.Export(file);
            Assert.IsTrue(File.Exists(file));

            String result = File.ReadAllText(file);
            String expect = File.ReadAllText("../../expectedOrders.xml");
            Assert.AreEqual(expect, result);

            File.Delete(file);
        }

        [TestMethod()]
        public void ImportTest()
        {
            //OrderService orderService = new OrderService();
            List<Order> expect = or.QueryAll();
            or.Import("../../expectedOrders.xml");
            List<Order> result = or.QueryAll();
            CollectionAssert.Equals(expect, result);

            or.Import("../../newOrders.xml");
            result = or.QueryAll();
            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result.Any(o => o.Id == 4));
        }

    }
}
}