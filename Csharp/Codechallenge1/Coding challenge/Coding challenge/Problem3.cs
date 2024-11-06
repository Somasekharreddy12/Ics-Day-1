using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_challenge
{
    class Problem3
    {
        static void Main()
        {
            Console.Write("Enter the first integer:");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the second integer:");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write("Enter the third integer:");
            int num3 = int.Parse(Console.ReadLine());

            int Largest = FindLargest(num1, num2, num3);

            Console.WriteLine("the largest number is:" + Largest);
            Console.Read();
        }
        static int FindLargest(int a,int b,int c)
        {
            int max = a;
            
            if(b > max)
            {
                max = b;
            }
            if(c > max)
            {
                max = c;
            }
            return max;
           
        }
    }
}
