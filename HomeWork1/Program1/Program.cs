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
            Double a, b, c;
            Console.Write("a:");
            a = Double.Parse(Console.ReadLine());
            Console.Write("b:");
            b = Double.Parse(Console.ReadLine());
            c = a * b;
            Console.WriteLine("a*b={0:f}", c);
        }
    }
}
