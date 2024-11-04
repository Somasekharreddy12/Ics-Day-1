using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Day
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number == 1)
            {
                Console.WriteLine("monday");
            }
            else if (number == 2)
            {
                Console.WriteLine("tuesday");
            }
            else if (number == 3)
            {
                Console.WriteLine("wednesday");
            }
            else if (number == 4)
            {
                Console.WriteLine("thursday");
            }
            else if (number == 5)
            {
                Console.WriteLine("friday");
            }
            else if (number == 6)
            {
                Console.WriteLine("saturday");
            }
            else if (number == 7)
            {
                Console.WriteLine("sunday");
            }
            else
            {
                Console.WriteLine("Invalid number");
            }
            Console.Read();




            

                
            

        }
    }
}
