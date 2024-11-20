using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_challenge_3
{
    class Problem_4
    {
        public delegate int CalculatorDelegate(int a, int b);

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static void PerformOperation(int a, int b, CalculatorDelegate operation, string operationName)
        {
            int result = operation(a, b);
            Console.WriteLine($"{operationName}: {result}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first integer:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second integer:");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("\nCalculator Functions:");

            PerformOperation(num1, num2, Add, "Addition");
            PerformOperation(num1, num2, Subtract, "Subtraction");
            PerformOperation(num1, num2, Multiply, "Multiplication");
            Console.Read();
        }
    }
}