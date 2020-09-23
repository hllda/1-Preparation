using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Mission_2
{
    class Program
    {
        static void Main(string[] args)
        {

            var names = new List<string> { "Joa", "Nell", "Luna", "Kanel" };
            string party = String.Join(", ", names);
            var intro = $"A party of warriors ({party}) descends into the dungeon.";


            Console.WriteLine($"{intro}");

            var random = new Random();

            int sum = 0;
            for (int index = 0; index < 8; index++)
            {
                int dice = random.Next(1, 9);
                sum += dice;
            }

            int basilisk = sum + 16;
            Console.WriteLine($"A basilisk with {basilisk} HP appears!");

            int hit = 0;

            for (int index = 0; index < 1; index++)
            {
                foreach (var name in names)
                {
                    for (int inde = 0; inde < 1; inde++)
                    {
                        int dice = random.Next(1, 5);
                        hit += dice;
                    }

                    var attack = ($"{name} hits the basilisk for {hit} damage.");
                    basilisk -= hit;
                    string hpleft = ($"Basilisk has {basilisk} HP left.");
                    hit = 0;


                    if (basilisk < 0)
                    {
                        Console.WriteLine($"{attack} Basilisk has 0 HP left."); ;
                        goto victory;
                    }
                    Console.WriteLine($"{attack} {hpleft}");
                }


            victory:
                Console.WriteLine($"The basilisk collapses and the heroes celebrate their victory!");
                goto ending;

            defeat:
                Console.WriteLine($"The party has perished. They will forever stand as statues in the basilisk's great hall of dining.");
                goto ending;


            ending: Console.WriteLine($"The end!");

                // 2. After each round of heroes' attacks, the basilisk uses petrifying gaze on a random hero. Display who it is.
                // 3. The hero has to pass a DC 12 constitution saving throw to survive.Assume they have constitution 5, add a d20 roll, and check if the total is 12 or higher.Display the roll amount and if they succeed to be saved.
                // 4. If they don't succeed, display that they got turned into stone and remove them from the list of heroes.
                // 5. If all heroes get turned into stone before they defeat the basilisk, the game is over.Display a bad ending narrative.

            }
        }
    }
}
