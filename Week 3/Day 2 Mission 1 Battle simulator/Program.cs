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
        static int SimulateBattle(List<string> Heroes, string AAN, string Monster, int MonsterHP, int SavingThrowDC)
        {
            var random = new Random();
            int dice = random.Next(1, 9);

            Console.WriteLine($"\n{AAN} {Monster} with {MonsterHP} HP appears!\n");

            do
            {
                    int HeroAttack = 0;
                foreach (string name in Heroes)
                {
                    
                    for (int i = 0; i < 2; i++)
                    {
                        int hit = random.Next(1, 5);
                        HeroAttack += hit ;
                    }

                    var attack = ($"{name} hits the {Monster} for {HeroAttack} damage.");
                    MonsterHP -= HeroAttack;
                    string hpleft = ($"The {Monster} has {MonsterHP} HP left.");
                    HeroAttack = 0;

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


                    var roll20 = 0;
                    for (int inde = 0; inde < 1; inde++)
                    {
                        int dice20 = random.Next(1, 21);
                        roll20 = dice20;
                    }

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

            int HeroesAlive = Heroes.Count;
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
            SimulateBattle(Heroes, "An", "orc", 15, 12);

            // MAGE
            if (Heroes.Count > 0)
            {
            SimulateBattle(Heroes, "A", "mage", 40, 20);
            }

            // TROLL
            if (Heroes.Count > 0)
            {
            SimulateBattle(Heroes, "A", "troll", 84, 18);
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