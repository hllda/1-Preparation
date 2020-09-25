using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Mission_2
{
    class Program
    {

        // 1. Write the SimulateBattle method by reusing and appropriately adjusting the code from the basilisk battle.
        // 2. Create the list of heroes and call the SimulateBattle method for all three monsters.
        // 3. Make sure you do not simulate further battles if all the heroes die.
        // 4. If they complete all 3 battles, display which heroes survived.

        // Now that you've tested the RPG battle system with the basilisk, let's try it out with 3 new enemies: an orc(15 HP), a mage(40 HP), and a troll(84 HP).

        // We'll keep things simple and just reuse the code from the basilisk battle, 
        //   but use a different difficulty class (DC) for the saving throws the heroes need to perform or else be killed. 
        // Let's use DC values 12 (orc), 20 (mage), and 18 (troll). 
        //   And you can give the heroes their greatswords back(2d6 damage).

        // (List<string> heroes, string monster, int monsterHP, int savingThrowDC);




        static void Main(string[] args)
        {
            // INTRO

            // The Heroes
            var heroes = new List<string> { "Joa", "Nell", "Luna", "Kanel" };
            string party = String.Join(", ", heroes);
            Console.WriteLine($"A party of warriors ({party}) descends into the dungeon.");


            // OUTRO
            //check for heroes

            if (enemy <= 0)
            {
                if (heroes.Count == 4)
                {
                    Console.WriteLine($"\nThe basilisk collapses and the heroes celebrate their victory! This was a battle they would never forget!\n");
                }

                if (heroes.Count == 3)
                {
                    Console.WriteLine($"\nThe basilisk collapses and the party gets together for a group hug!\n");
                }

                if (heroes.Count == 2)
                {
                    Console.WriteLine($"\nFinally, the basilisk collapses. They had finally won the battle, but just barely.\n");
                }

                if (heroes.Count == 1)
                {
                    Console.WriteLine($"\n{heroes[0]} cries out from exhaustion as the basilisk finally collapses from the last blow. This was not a victory, this was only avoiding defeat. This was a battle they wish they could forget...\n");
                }


            }

            else
            {
                Console.WriteLine($"\nThe party has perished.\nAlthough it wasn't a bad day for everyone.\nThe basilisk smirks to itself while bringing the petrified party home to its residence.\nThey will forever stand as statues in the basilisks' great hall.\nThe baselisk will continue to collect statues, as they do look pretty neat.\n");
            }

            //END

            Console.WriteLine($"The end!");



        }

        static void SimulateBattle(List<string> heroes, string monster, int monsterHP, int savingThrowDC)
        {
            var random = new Random();

            int sum = 0;
            for (int index = 0; index < 8; index++)
            {
                int dice = random.Next(1, 9);
                sum += dice;
            }
            int enemy = sum + 16;

            Console.WriteLine($"A basilisk with {enemy} HP appears!");

            int hit = 0;

            do
            {
                foreach (string name in heroes)
                {
                    for (int inde = 0; inde < 2; inde++)
                    {
                        int dice = random.Next(1, 5);
                        hit += dice;
                    }
                    var attack = ($"{name} hits the basilisk for {hit} damage.");
                    enemy -= hit;
                    string hpleft = ($"Basilisk has {enemy} HP left.");
                    hit = 0;



                    if (enemy <= 0)
                    {
                        Console.WriteLine($"{attack} Basilisk has 0 HP left.");
                        break;
                    }
                    Console.WriteLine($"{attack} {hpleft}");
                }

                if (enemy > 0)
                {
                    var randomName = random.Next(0, heroes.Count);
                    string attackedName = heroes[randomName];


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
                        heroes.Remove(attackedName);
                    }

                }

            } while (enemy > 0 && heroes.Count > 0);

        }

    }

}
   



