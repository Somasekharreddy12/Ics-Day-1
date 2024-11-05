using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Reverse_word
    {
        public static void Main()
        {
            Reverse();
            Console.Read();
        }
            
                public static void Reverse()
        {
            Console.WriteLine("enter a word:");
            string str = Console.ReadLine();
            string reversed = "";
            for (int i=str.Length-1; i >= 0; i--)
            {
                reversed = reversed + str [i];
            }
            Console.WriteLine(reversed);
        }



    }
}
