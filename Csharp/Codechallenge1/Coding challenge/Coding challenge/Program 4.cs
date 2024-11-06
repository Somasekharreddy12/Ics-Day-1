using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_challenge
{
    class Program_3
    {
        static void Main()
        {
            Console.WriteLine("enter a string:");
            string input = Console.ReadLine();

            Console.WriteLine("enter the count letter:");
            Char letter = Console.ReadLine()[0];

            int count = CountOccurances(input, letter);
            Console.WriteLine("{letter} appears {count} times in the string. ");
            Console.Read();
        }
        static int CountOccurances(string str,char ch)
        {
            int count = 0;
            foreach (char c in str)
            {
                if(ch == ch)
                {
                    count++;
                }
            }
            return count;
            
        }
    }
}
