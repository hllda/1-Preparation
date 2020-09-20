using System;

namespace Mission_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int shots = random.Next(10, 20);

            int hits = random.Next(0, shots);

            double hitaccuracy = ((double)hits / (double)shots) * 100;


            Console.WriteLine($"Shots: {shots}");
            Console.WriteLine($"Hits: {hits}");
            Console.WriteLine($"Hit accuracy: {hitaccuracy}%");

        }
    }
}
