using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Schloarship
    {
        public void Merit(double fees, double marks)
        {
            double schloarshipamount = 0;

            if (marks >= 70 && marks <= 80)
            {
                schloarshipamount = 0.20 * fees;
            }
            else if (marks > 80 && marks <= 90)
            {
                schloarshipamount = 0.30 * fees;
            }
            else if (marks > 90)
            {
                schloarshipamount = 0.50 * fees;
            }
            else
            {
                Console.WriteLine("No schloarship is available");

            }
            Console.WriteLine($"The schloarship amount is:{schloarshipamount:C}");

        }
    }
    public class Program
    {
         public static void Main(string[] args)
        {
            Schloarship schloarship = new Schloarship();

            Console.Write("enter marks:");
            double marks = Convert.ToDouble(Console.ReadLine());

            Console.Write("enter fees:");
            double fees = Convert.ToDouble(Console.ReadLine());

            schloarship.Merit(marks, fees);
            Console.Read();


        }
    }
}
