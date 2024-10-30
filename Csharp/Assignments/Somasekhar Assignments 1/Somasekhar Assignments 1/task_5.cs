using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somasekhar_Assignments_1
{
    class task_5
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number1");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int sum = num1 + num2;
            if(num1 == num2)
            {
                int multiply = 3 * sum;
                Console.WriteLine("The answer is:" + multiply);
            }
            else
            {
                Console.WriteLine("The sum is:" + sum);
            }
            Console.Read();
        }
    }
}

    

