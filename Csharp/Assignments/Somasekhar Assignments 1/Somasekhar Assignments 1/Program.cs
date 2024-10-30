using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somasekhar_Assignments_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("enter a number");
            int t = Convert.ToInt32(Console.ReadLine());
            if (t >= 0)
            {
                Console.WriteLine($"{t} is positive numver");
                Console.Read();

            }
            else
            {
                Console.WriteLine($"{t} is negative number");
                Console.Read();
            }
        }
    }
}
    

