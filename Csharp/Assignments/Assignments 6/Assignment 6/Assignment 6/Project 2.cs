using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Project_2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words separated by spaces:");

            var input = Console.ReadLine();
            List<string> words = input
                .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var result = words
                .Where(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase)
                            && word.EndsWith("m", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("\nWords starting with 'a' and ending with 'm':");
            foreach (var word in result)
            {
                Console.WriteLine(word);
                Console.Read();
            }
        }
    }
}