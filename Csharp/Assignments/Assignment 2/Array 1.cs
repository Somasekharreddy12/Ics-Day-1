using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Array_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of an array:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            for(int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
             for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Maximum of array");
                Console.WriteLine("Minimum of array");
                Console.WriteLine("Average of array");

                    
            }

            Console.Read();

        }

    }
}
