using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somasekhar_Assignments_1
{
    class task_2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number:");
            int num1 = Convert.ToInt32(Console.ReadLine()); // taking first_num input
            int num2 = Convert.ToInt32(Console.ReadLine()); // taking second_num input
            if (num1 == num2) ; // Checking equal or not
            Console.WriteLine(num1 + " and " + num2 + " are equal "); // printing output
            Console.ReadLine();
        }
    }
   
}
