using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Word_Same
    {
        static void Main()
        {
            Console.Write("enter a word:");
             string word1 = Console.ReadLine();

            Console.Write("enter a word:");
            string word2 = Console.ReadLine();
            {
                if(word1 == word2)
                {
                    Console.WriteLine("words are same");
                }
                else
                {
                    Console.WriteLine("words are not same");
                    Console.Read();
                }
            }
        }

    }
}
