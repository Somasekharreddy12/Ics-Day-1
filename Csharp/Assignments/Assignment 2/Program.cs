using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class swapping
    {
        static void Main(string[] args)
        {
            int number1, number2, temp;
            Console.WriteLine("enter first number:");
            number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("enter second number:");
            number2 = int.Parse(Console.ReadLine());
            temp = number1;
            number1 = number2;
            number2 = temp;
            Console.WriteLine("After swapping:");
            Console.WriteLine("first number:"+number1);
            Console.WriteLine("Second number:"+number2);
            Console.ReadLine();
        }
    }
}
