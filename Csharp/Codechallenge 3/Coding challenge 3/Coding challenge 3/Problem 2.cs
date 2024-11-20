using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_challenge_3
{
    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public static Box Add(Box box1, Box box2)
        {
            Box result = new Box
            {
                Length = box1.Length + box2.Length,
                Breadth = box1.Breadth + box2.Breadth
            };
            return result;
        }
        public void Display()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }

    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the dimensions of the first box:");
            Console.Write("Length: ");
            double length1 = double.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the dimensions of the second box:");
            Console.Write("Length: ");
            double length2 = double.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth2 = double.Parse(Console.ReadLine());

            Box box1 = new Box { Length = length1, Breadth = breadth1 };
            Box box2 = new Box { Length = length2, Breadth = breadth2 };

            Box box3 = Box.Add(box1, box2);

            Console.WriteLine("\n Third box Details:");
            box3.Display();
            Console.Read();
            
        }
    }
}


