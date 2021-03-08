using System;
using System.Collections.Generic;
namespace Mission_1
{
    class Program
    {

        static void Main(string[] args)
        {

            var scores = new List<int> { };
            for (int index = 0; index < (6); index++)
            {
                var random = new Random();
                var rolls = new List<int> { };
                int sum = 0;

                for (int inde = 0; inde < (4); inde++)
                {
                    var roll = random.Next(1, 7);
                    rolls.Add(roll);
                    sum += roll;
                }

                string list = String.Join(", ", rolls);
                rolls.Sort();

                int final = sum - rolls[0];

                scores.Add(sum);

                Console.WriteLine($"You roll {list}, The ability score is {final}.");
            }

            scores.Sort();
            string score = String.Join(", ", scores);
            Console.WriteLine($"Your available ability scores are {score}.");
        }
    }
}
