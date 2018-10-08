using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeClock;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock;  

            //用户输入时间并判断对错
            while (true)
            {
                Console.WriteLine("请输入时间，格式为 xx:xx:xx   例如: 00:00:00");
                Console.Write("请输入时间：");
                try
                {
                    String input = Console.ReadLine();
                   
                        clock = new Clock(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("输入错误");
                    continue;
                }
                break;
            }
            clock.TimeIsUp += new TimeHandler(Clock.timeAlert);  //注册事件
            Console.WriteLine("The clock is running...");
            clock.TurnOn();
        }
    }
}
