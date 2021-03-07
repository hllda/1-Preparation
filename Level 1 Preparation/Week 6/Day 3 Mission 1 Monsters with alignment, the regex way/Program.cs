using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace Day_3_Mission_1_Monsters_with_alignment__the_regex_way
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Projects\TheIndieQuest\Week 6\Day 3 Mission 1 Monsters with alignment, the regex way\MonsterManual.txt";
            string manual = File.ReadAllText(path);

            String[] monster = manual.Split("\n\n");

            var namesByAlignment = new List<string>[3,3];

            var namesOfUnaligned = new List<string>();
            var namesOfAnyAlignment = new List<string>();
            var namesOfSpecialCases = new List<string>();

            for(int y = 0; y < 3; y++)
                for(int x = 0; x < 3; x++)
                    namesByAlignment[y,x] = new List<string>();

            var xLabel = new[] { "lawful","neutral","chaotic" };
            var yLabel = new[] { "good","neutral","evil" };
            

            for(int i = 0; i < monster.Length; i++)
            {
                String[] info = monster[i].Split("\n");

                if(Regex.IsMatch(info[1],"(, ?(lawful|neutral|chaotic)? (good|neutral|evil))$"))
                {

                    for(int y = 0; y < 3; y++)
                    {
                        for(int x = 0; x < 3; x++)
                        {
                            string pattern = $"(, ?({xLabel[x]})? ({yLabel[y]}))";

                            if(Regex.IsMatch(info[1],pattern))
                            {
                                namesByAlignment[y,x].Add(info[0]);
                            }
                        }
                    }
                }

                else
                {
                    if(Regex.IsMatch(info[1],"(, unaligned)"))
                    {
                        namesOfUnaligned.Add(info[0]);
                        continue;
                    }

                    else if(Regex.IsMatch(info[1],"(, any alignment)"))
                    {
                        namesOfAnyAlignment.Add(info[0]);
                        continue;
                    }

                    else
                    {
                        string[] special = info[1].Split(", ");


                        namesOfSpecialCases.Add($"{info[0]} ({special[1]})");
                        continue;
                    }
                }
            }

            for(int y = 0; y < 3; y++)
            {
                for(int x = 0; x < 3; x++)
                {   
                    if(x == 1 && y == 1) Console.WriteLine($"Monsters with alignment true {yLabel[y]} are:");
                    else Console.WriteLine($"Monsters with alignment {xLabel[x]} {yLabel[y]} are:");
                    foreach(string thing in namesByAlignment[y,x])
                    {
                        Console.WriteLine(thing);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Unaligned monsters are: ");
            foreach(string thing in namesOfUnaligned)
            {
                Console.WriteLine(thing);
            }

            Console.WriteLine();

            Console.WriteLine("Monsters which can be of any alignment are: ");
            foreach(string thing in namesOfAnyAlignment)
            {
                Console.WriteLine(thing);
            }

            Console.WriteLine();

            Console.WriteLine("Monsters with special cases are: ");
            foreach(string thing in namesOfSpecialCases)
            {
                Console.WriteLine(thing);
            }
        }
    }
}