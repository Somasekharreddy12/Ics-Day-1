using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Coding_challenge_3
{
    class Problem_3
    {
        static void Main(string[] args)
        {
            string fileName = "Csharp.txt";
            Console.WriteLine($"Working with file: {fileName}");

            Console.WriteLine("Enter the text you want to append to the file:");
            string userInput = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, append: true))
                {
                    writer.WriteLine(userInput);
                }

                Console.WriteLine("Text successfully appended to the file.");

                Console.WriteLine("\nFile contents:");
                using (StreamReader reader = new StreamReader(fileName))
                {
                    Console.WriteLine(reader.ReadToEnd());
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
