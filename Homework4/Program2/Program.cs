using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class MyException : ApplicationException
    {
        private int idnumber;
        public MyException(String message, int id)
           : base(message)
        {
            this.idnumber = id;
        }

        public int getId()
        {
            return idnumber;
        }
    }

    public class OrderDetails
    {
        public string GoodsName { get; set; }
        public int GoodsPrice { get; set; }
        public int GoodsNum;
        public int TotalPrice
        {
            get
            {
                return GoodsPrice * GoodsNum;
            }
        }
        //输出订单详情
        public void PrintDetails()
        {
            if (GoodsNum > 0)
                Console.WriteLine($"{GoodsName} * {GoodsNum}，单价{GoodsPrice}元，共{GoodsPrice * GoodsNum}元 ");
        }
        public OrderDetails(string goodsname, int goodsprice)
        {
            this.GoodsName = goodsname;
            this.GoodsPrice = goodsprice;
        }
    }
        //商品A,B,C
    public class Order
    {
        public OrderDetails goodsADetails = new OrderDetails("goodsA", 2);
        public OrderDetails goodsBDetails = new OrderDetails("goodsB", 3);
        public OrderDetails goodsCDetails = new OrderDetails("goodsC", 4);
        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        //整个订单的价格
        public int TotalPrice()
        {
            int totalPrice = 0;
            foreach (OrderDetails details in orderDetails)
            {
                totalPrice += details.TotalPrice;
            }
            return totalPrice;
        }

        public string Nums { get; set; }
        public string Name { get; set; }
        public Order(string nums, string name)
        {
            Nums = nums;
            Name = name;
        }
    }

    

    public class OrderService
    {
        public List<Order> orders = new List<Order>();
        //添加订单
        public void AddOrder(string nums)
        {
            string name = "Vermouth";
            Order order = new Order(nums, name);
       
            Random random = new Random();
            int goodsANum = random.Next(20);
            int goodsBNum = random.Next(20);
            int goodsCNum = random.Next(20);

            order.goodsADetails.GoodsNum = goodsANum;
            order.orderDetails.Add(order.goodsADetails);
            order.goodsBDetails.GoodsNum = goodsBNum;
            order.orderDetails.Add(order.goodsBDetails);
            order.goodsCDetails.GoodsNum = goodsCNum;
            order.orderDetails.Add(order.goodsCDetails);

            orders.Add(order);
            Console.WriteLine("添加订单成功，订单号:"+order.Nums+"客户姓名："+order.Name);
            foreach (OrderDetails details in order.orderDetails)
            {
                details.PrintDetails();
            }
            Console.WriteLine("共计"+order.TotalPrice()+"元");

        }
        //删除订单
        public void DelOrder(string nums)
        {
            try
            {
                foreach (Order order in orders)
                {
                    if (order.Nums == nums)
                    {
                        Console.WriteLine("成功删除订单，订单号"+order.Nums+" 客户姓名："+order.Name);
                        orders.Remove(order);
                        return;
                    }
                }
            }
            catch(Exception )
            {
                Console.WriteLine("没有找到该订单！", 3);
            }
        }
        //修改订单
        public void ModOrder(string nums)
        {
            foreach (Order order in orders)
            {
                if (order.Nums == nums)
                {
                    order.goodsADetails.GoodsNum = 2;
                    order.goodsCDetails.GoodsNum = 2;
                    Console.WriteLine("成功修改订单，订单号："+order.Nums+" 客户姓名："+order.Name);
                    foreach (OrderDetails details in order.orderDetails)
                    {
                        details.PrintDetails();
                    }
                    Console.WriteLine("共计:"+order.TotalPrice()+"元。");
                    return;
                }
            }
            throw new MyException("没有找到该订单！", 3);
        }
        //查询订单
        //通过订单号
        public void FindOrderByNums(string nums)
        {
            foreach (Order order in orders)
            {
                if (order.Nums == nums)
                {
                    Console.WriteLine("通过订单号找到订单，订单号："+order.Nums+"客户姓名:"+order.Name);
                    foreach (OrderDetails details in order.orderDetails)
                    {
                        details.PrintDetails();
                    }
                    Console.WriteLine("共计:"+order.TotalPrice()+"元。");
                    return;
                }
            }
        }
        //通过商品名称
        public void FindOrderByGoods(string goodsname)
        {
            foreach (Order order in orders)
            {
                foreach (OrderDetails detail in order.orderDetails)
                {
                    if (detail.GoodsName == goodsname && detail.GoodsNum > 0)
                    {
                        Console.WriteLine("通过商品名称找到订单，订单号：" + order.Nums + " 客户姓名:" + order.Name);
                        foreach (OrderDetails details in order.orderDetails)
                        {
                            details.PrintDetails();
                        }
                        Console.WriteLine("共计:" + order.TotalPrice() + "元。");
                        break;
                    }
                }
            }
        }
        //通过客户姓名
        public void FindOrderByName(string name)
        {
            foreach (Order order in orders)
            {
                if (order.Name == name)
                {
                    Console.WriteLine("通过客户姓名找到订单，订单号："+order.Nums+" 客户姓名:"+order.Name);
                    foreach (OrderDetails details in order.orderDetails)
                    {
                        details.PrintDetails();
                    }
                    Console.WriteLine("共计:"+order.TotalPrice()+"元。");
                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
       
            orderService.AddOrder("001");
            orderService.AddOrder("002");
            orderService.AddOrder("003");
            orderService.AddOrder("004");
            orderService.AddOrder("005");
            //删除订单
            try
            {
                orderService.DelOrder("002");
                orderService.DelOrder("004");
                orderService.DelOrder("003");
                orderService.DelOrder("006");  //出现异常
            }
            catch (MyException e)
            {
                Console.WriteLine("删除订单失败，出错种类" + e.getId());
            }

            //修改订单
            try
            {
                orderService.ModOrder("003");
                orderService.ModOrder("005");
                orderService.ModOrder("006");   //出现异常

            }
            catch (MyException e)
            {
                Console.WriteLine("修改订单失败，出错种类" + e.getId());
            }

            orderService.FindOrderByNums("005");
            orderService.FindOrderByName("Vermouth");
            orderService.FindOrderByGoods("goodsA");

            Console.ReadKey();
        }
    }
}
