using System;

namespace Mission_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 6;
            int min = 1;
            Console.WriteLine($"The numbers that can be rolled with one die go from {min} to {max}, you get to roll 3 dice.");

            Console.WriteLine("The first two rolls will be counted for what they show, the third roll will be tripled and the final score doubled.");

            var random = new Random();

            int die1 = random.Next(1, 7);
            int die2 = random.Next(1, 7);
            int die3 = random.Next(1, 7);
            int die3tripple = die3 * 3;
            int final = (die1 + die2 + die3tripple) * 2;

            Console.WriteLine($"First die shows {die1}.");
            Console.WriteLine($"Second die shows {die2}.");
            Console.WriteLine($"Third die shows {die3}, the third is worth triple which means a result of {die3tripple}");

            Console.WriteLine($"The final score is {final}");

        }
    }
}
