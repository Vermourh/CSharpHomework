using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            string s;
            Console.WriteLine("input a number:");
            s = Console.ReadLine();
            a = int.Parse(s);
            for(int i=1;i<=a;i++)
            {
                if (a % i == 0)
                    Console.WriteLine(i+"是" + s+"的素数因子");
                continue;
            }
        }
    }
}
