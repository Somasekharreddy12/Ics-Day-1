using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    abstract class A
    {
        int i;
        public abstract void display();
    }
    class B : A
    {
        public int j;
        public override void display()
        {
            Console.WriteLine(j);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B obj = new B();
            obj.j = 2;
            obj.display();
            Console.ReadLine();
        }
    }
}