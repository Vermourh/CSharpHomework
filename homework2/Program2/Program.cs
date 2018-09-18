using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10] { 51, 3, 11, 6, 24, 9, 41, 29,66,35 };
            int max = a[0];
            int min = a[0];
            for (int i=0;i<a.Length;i++)
            {
                if (a[i] >=max)
                {
                    max = a[i];
                }
                if(a[i]<=min)
                {
                    min = a[i];
                }
            }
            int sum=0;
            foreach(int j in a)
            {
                sum += j;
            }
            double average = (double)sum / a.Length;

            Console.WriteLine("max:" + max);
            Console.WriteLine("min:" + min);
            Console.WriteLine("average:" + average);
            Console.WriteLine("sum:" + sum);
        }
    }
}
