using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_challenge_3
{
    class CricketTeam
    {
        public (int Count, int Sum, double Average) PointsCalculation(int no_of_matches)
        {
            int sum = 0;
            int[] scores = new int[no_of_matches];

            Console.WriteLine("Enter the scores for each match:");

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Match {i + 1}: ");
                scores[i] = int.Parse(Console.ReadLine());
                sum += scores[i];
            }

            double average = (double)sum / no_of_matches;
            return (no_of_matches, sum, average);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of matches played:");
            int no_of_matches = int.Parse(Console.ReadLine());

            CricketTeam team = new CricketTeam();
            var (Count, Sum, Average) = team.PointsCalculation(no_of_matches);

            Console.WriteLine($"\nResults:");
            Console.WriteLine($"Number of Matches: {Count}");
            Console.WriteLine($"Sum of Scores: {Sum}");
            Console.WriteLine($"Average Score: {Average:F2}");
            Console.Read();
        }
    }
}
