using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class number
    {
        
        static void CheckIfNegative(int number)
        {
            if (number < 0)
            {
                
                throw new ArgumentException("The number cannot be negative.");
            }
            else
            {
                Console.WriteLine("The number is valid: " + number);
            }
        }

        static void main()
        {
            Console.Write("Enter a number: ");

            try
            {
                
                int number = int.Parse(Console.ReadLine());

               
                CheckIfNegative(number);
            }
            catch (ArgumentException ex)
            {
                
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (FormatException)
            {
                
                Console.WriteLine("Error: Please enter a valid integer.");
            }

            Console.WriteLine("Program execution completed.");
            Console.Read();
        }
    }
    
}


