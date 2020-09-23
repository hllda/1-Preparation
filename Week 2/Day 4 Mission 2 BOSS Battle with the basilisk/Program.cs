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
            string intro = $"A party of warriors ({party}) descends into the dungeon.";

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

            do
            {
                foreach (string name in names)
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

                    

                    if (basilisk <= 0)
                    {
                        Console.WriteLine($"{attack} Basilisk has 0 HP left.");
                        break;
                    }
                    Console.WriteLine($"{attack} {hpleft}");
                }

                if (basilisk > 0)
                {
                    var randomName = random.Next(0, names.Count);
                    string attackedName = names[randomName];


                    Console.WriteLine($"The basilisk uses petrifying gaze on {attackedName}!");


                    var roll20 = 0;
                    for (int inde = 0; inde < 1; inde++)
                    {
                        int dice20 = random.Next(1, 16);
                        roll20 = dice20 + 5;
                    }

                    if (12 <= roll20)
                    {
                    Console.WriteLine($"{attackedName} rolls a {roll20} and is saved from the attack.");
                    }
                   
                    else
                    {
                        Console.WriteLine($"{attackedName} roll a {roll20} and fails to be saved. {attackedName} is turned into stone.");
                        names.Remove(attackedName);
                    }
                          
                }

                

            } while (basilisk > 0 && names.Count > 0);

            if (basilisk <= 0)
            {
                if (names.Count == 4){ 
                        Console.WriteLine($"\nThe basilisk collapses and the heroes celebrate their victory! This was a battle they would never forget!\n"); 
                        }

                if (names.Count == 3){ 
                        Console.WriteLine($"\nThe basilisk collapses and the party gets together for a group hug!\n"); 
                        }

                if (names.Count == 2){ 
                        Console.WriteLine($"\nFinally, the basilisk collapses. They had finally won the battle, but just barely.\n"); 
                        }

                if (names.Count == 1){ 
                        Console.WriteLine($"\n{names[0]} cries out from exhaustion when the basilisk finally collapses from the last blow. This was not a victory, this was only avoiding defeat. This was a battle they wish they could forget...\n"); 
                        }
            }
            
            else
            {
            Console.WriteLine($"\nThe party has perished.\nAlthough it wasn't a bad day for everyone.\nThe basilisk smirks to itself while bringing the petrified party home to its residence.\nThey will forever stand as statues in the basilisks' great hall.\nThe baselisk will continue to collect statues, as they do look pretty neat.\n");
            }

            Console.WriteLine($"The end!");




        }
    }
}