using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;

namespace Mission_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int sum1 = 0;
            for (int i = 0; i < 3; i++)
            {
            int roll = random.Next(1, 7);
                sum1 += roll;
            }
            int character = sum1;


            int sum2 = 0;
            for (int i = 0; i < 8; i++)
            {
            int roll = random.Next(1, 11);
                sum2 += roll;
            }

            int slime = (sum2 + 40);

            Console.WriteLine($"A character with strength {character} was created.");
            Console.WriteLine($"A gelatinous cube with {slime} HP appears!");


            int sum3 = 0;
            for (int i = 0; i < 800; i++)
            {
                int roll = random.Next(1, 11);
                sum3 += roll;
            }
            int army = sum3 + 4000;

            Console.WriteLine($"Dear gods, an army of 100 cubes descends upon us with a total of {army} HP. We are doomed!");


        }
    }
}
