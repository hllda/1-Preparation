using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Pipes;
namespace Mission_2
{
    class Program
    {
        static int XdY(int numberRolls, int diceSides, int fixedBonus = 0)
        {
            var random = new Random();
            int roll = 0;
            for (int i = 0; i < numberRolls; i++)
            {
               int rnd = random.Next(1, diceSides + 1);
               roll =+ roll + rnd;      
            }
            int diceRoll = roll + fixedBonus;
            return diceRoll;
        }
        static int SimulateBattle(List<string> Heroes, string AAN, string Monster, int MonsterHP, int SavingThrowDC)
        {
            var random = new Random();
            Console.WriteLine($"\n{AAN} {Monster} with {MonsterHP} HP appears!\n");

            do
            {

                foreach (string name in Heroes)
                {
                    int hit = XdY(2, 6);

                    var attack = ($"{name} hits the {Monster} for {hit} damage.");
                    MonsterHP -= hit;
                    string hpleft = ($"The {Monster} has {MonsterHP} HP left.");
                    hit = 0;

                    if (MonsterHP <= 0)
                    {
                        Console.WriteLine($"{attack}The {Monster} has 0 HP left.");
                        break;
                    }
                    Console.WriteLine($"{attack} {hpleft}");
                }

                if (MonsterHP > 0)
                {
                    var randomName = random.Next(0, Heroes.Count);
                    string attackedName = Heroes[randomName];


                    Console.WriteLine($"\nThe {Monster} attacks {attackedName}!");
                    
                    int roll20 = XdY(1, 20);

                    if (SavingThrowDC <= roll20)
                    {
                        Console.WriteLine($"{attackedName} rolls a {roll20} and is saved from the attack.\n");
                    }

                    else
                    {
                        Console.WriteLine($"{attackedName} rolls a {roll20} and fails to be saved. {attackedName} has fallen.\n");
                        Heroes.Remove(attackedName);
                    }
                }

            } while (MonsterHP > 0 && Heroes.Count > 0);

            return MonsterHP;

        }
        static void Main(string[] args)
        {
            // INTRO
            // The Heroes
            var Heroes = new List<string> { "Joa", "Nell", "Luna", "Kanel" };
            string Party = String.Join(", ", Heroes);
            Console.WriteLine($"A party of warriors ({Party}) descends into the dungeon.");


            // ORC
            SimulateBattle(Heroes, "An", "orc", XdY(2, 8, 6), 12);

            // MAGE
            if (Heroes.Count > 0)
            {
                SimulateBattle(Heroes, "A", "mage", XdY(9, 8), 20);
            }

            // TROLL
            if (Heroes.Count > 0)
            {
                SimulateBattle(Heroes, "A", "troll",XdY(8, 10, 40), 18);
            }

            if (Heroes.Count > 0)
            {
                if (Heroes.Count == 4)
                {
                    Console.WriteLine($"\n After 3 rough battles, the heroes celebrate their victory! \n");
                }

                if (Heroes.Count == 3)
                {
                    Console.WriteLine($"\n{Heroes[0]}, {Heroes[1]} and {Heroes[2]} exit the dungeon. They mourn their fallen friend while sharing a group hug and remembering the good times.\n");
                }

                if (Heroes.Count == 2)
                {
                    Console.WriteLine($"\n{Heroes[0]} and {Heroes[1]} exit the dungeon together. They are mourning their fallen friends. This is not how things were supposed to end, but at least they have each other.\n");
                }

                if (Heroes.Count == 1)
                {
                    Console.WriteLine($"\n{Heroes[0]} exit the cave alone. Everything is worse now.\n");
                }
            }

            else
            {
                Console.WriteLine($"\nThe party has perished.\n");
            }

            //END
            Console.WriteLine($"The end!");
        }
    }
}