using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Project_3
    {
        static void Main()
        {
            string filePath = "sample.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    int lineCount = File.ReadAllLines(filePath).Length;

                    Console.WriteLine($"The file '{filePath}' contains {lineCount} lines.");
                }
                else
                {
                    Console.WriteLine($"The file '{filePath}' does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.Read();
            }
        }
    }
    
}

