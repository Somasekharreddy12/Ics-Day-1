using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Displaying_marks
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter thr 10 values: ");
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());

            }

            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                total = total + array[i];

            }
            Console.WriteLine("Total " + total);
            Console.WriteLine("Average mark is: ");

            int average = 0;
            for (int i = 0; i < array.Length; i++)
            {
                average = total / array[i];

            }
            Console.WriteLine(average);

            int minimum = array.Min();
            Console.WriteLine("minium mark is: " + minimum);
            int maximum = array.Max();
            Console.WriteLine("maximum mark is: " + maximum);


            Console.WriteLine("Ascending");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;

                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("Descending");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;

                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.Read();
        }
    }
}