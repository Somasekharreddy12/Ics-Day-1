using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_challenge
{
    class Program_2
    {
        static void Main()
        {
            Console.WriteLine("enter a string");
            string input = Console.ReadLine();
            string result = SwapFirstLastCharacters(input);

            Console.WriteLine("new string:" + result);
            Console.Read();

        }
        static string SwapFirstLastCharacters(string str)
        {
            if (str.Length <=1)
            {
                return str;
            }
            char firstchar = str[0];
            char lastchar = str[1];
            string newstring = lastchar + str.Substring(1, str.Length - 2) + firstchar;
            return newstring;
            

            
        }
    }
}
