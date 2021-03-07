using System;

namespace Mission_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int roll = random.Next(1, 7);
            int sum = 0;
            do
            {
                int dice = random.Next(1, 7);
                Console.WriteLine($"The entity rolls {dice}.");
                
                sum += dice;

                if (dice > 5)
                {
                    Console.WriteLine($" \nTotal score: {sum}");
                    break;
                }
            } while (roll != 0);
        }
    }
}