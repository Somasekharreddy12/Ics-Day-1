using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a word:");
            string word = Console.ReadLine();
            int length = word.Length;
            Console.WriteLine("the length of the word is:" + length);
            Console.Read();
        }
    }
}
