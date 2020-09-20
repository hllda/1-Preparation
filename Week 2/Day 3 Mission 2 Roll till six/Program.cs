using System;

namespace Mission_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int dice = random.Next(1, 7);
            Console.WriteLine($"The entity rolls {dice}.");

            while (dice < 6)
            {
                int roll = random.Next(1, 7);
                Console.WriteLine($"The entity rolls {roll}.");

                if (roll == 6)
                {
                    break;
                }
            }
        }
    }
}