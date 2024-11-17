using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Project_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by spaces:");

            var input = Console.ReadLine();
            List<int> numbers = input
                .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var result = numbers
                .Select(n => new { Number = n, Square = n * n })
                .Where(x => x.Square > 20);

            Console.WriteLine("\nNumbers and their squares (where square > 20):");
            foreach (var item in result)
            {
                Console.WriteLine($"Number: {item.Number}, Square: {item.Square}");
                Console.Read();
            }
        }
    }
}
    
