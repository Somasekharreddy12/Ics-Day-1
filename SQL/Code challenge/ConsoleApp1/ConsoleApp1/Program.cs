using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    abstract class A
    {
        public int i;
        public abstract void display();
    }
    class B : A
    {
        public int j;
        public int sum;
        public override void display()
        {
            sum = i + j;
            Console.WriteLine(+i + "\n" + +j);
            Console.WriteLine("sum is:"+ sum);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A obj = new B();
            obj.i = 2;
            B obj1 = new B();
            obj1.j = 10;
            obj.display();
            Console.ReadLine();
        }
    }
}