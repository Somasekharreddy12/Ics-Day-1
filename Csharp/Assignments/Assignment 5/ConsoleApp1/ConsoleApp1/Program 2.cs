using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program_2
    {
        static void Main()
        {
            string[] lines =
            {
            "Welcome to Csharp training.",
            "C sharp training done by Bhanu ma'am.",
            "We are 39 members in C sharp training.",
            "Im very Comfortable with C sharp class. ",

           
            
        };
            
            string filePath = "output.txt";

            try
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Successfully written to the file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.Read();
            }
        }
    }
    
}

