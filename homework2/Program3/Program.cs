using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 2;i <= 100;i++)
            {
                for(int j = 2;j <= i;j++)
                {
                    if (i % j == 0 && i != j)
                        break;
                    if (i == j)
                        Console.WriteLine(+i + "是素数");
                }
            }
        }
    }
}