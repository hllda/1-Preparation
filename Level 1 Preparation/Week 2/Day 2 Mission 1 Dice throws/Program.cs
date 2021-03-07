using System;

namespace Mission_1
{
    class Program
    {
        static void Main(string[] args)
        {




            int max = 6;
            int min = 1;
            Console.WriteLine($"The numbers you can roll with one die go from {min} to {max}");

            var random = new Random();

            int die1 = random.Next(1, 7);
            int die2 = random.Next(1, 7);
            int die3 = random.Next(1, 7);
            int dice = die1 + die2 + die3;
            Console.WriteLine($"First die shows {die1}.");
            Console.WriteLine($"Second die shows {die2}.");
            Console.WriteLine($"Third die show {die3}.");


            Console.WriteLine($"Together the dice shows: {dice}");



        }
    }
}
