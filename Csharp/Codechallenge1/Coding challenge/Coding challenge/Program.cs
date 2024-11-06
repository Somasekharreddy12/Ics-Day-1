using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a string:");
            string input = Console.ReadLine();
            Console.Write("remove position of the character(0-based index):");
            int position = int.Parse(Console.ReadLine());
            string result = RemoveCharacter(input, position);
            Console.WriteLine("string result:" + result);
            Console.Read();
        }
        static string RemoveCharacter(string str,int pos)
        {
            if(pos < 0 || pos >=str.Length)
            {
                Console.WriteLine("position is not in range:");
                return str;
            }
            return str.Remove(pos, 1);
            
        }
    }
}
