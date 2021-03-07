using System;

namespace Mission_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int firstRoll = random.Next(0, 11);

            int half = 10 - firstRoll;

            int secondRoll = random.Next(0, half + 1);

            int result = half - secondRoll;

            int final = 10 - result;


            Console.WriteLine($"{firstRoll}");

            Console.WriteLine($"{secondRoll}");

            Console.WriteLine($"{final}");

        }
    }
}
