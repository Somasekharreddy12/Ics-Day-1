using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somasekhar_Assignments_1
{
    class task_4
    {
        public static void Main()
        {
            Console.WriteLine("enter the number");
            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"{a} *{i}={ a * i}");
            }
            Console.Read();
        }

    }
}
    

