using System;
using System.IO;
using System.Text.RegularExpressions;
namespace Day_1_Mission_4_Slow_Flyers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Projects\TheIndieQuest\Week 6\Day 1 Mission 4 Slow flyers\MonsterManual.txt";
            string manual = File.ReadAllText(path);

            String[] monster = manual.Split("\n\n");

            Console.WriteLine($"Monsters that can fly 10-40 feet per turn: ");
            for(int i = 0; i < monster.Length; i++)
            {
                String[] info = monster[i].Split("\n");

                string pattern = "(fly ([1-3]?\\d|40) ft)";
                if(Regex.IsMatch(info[4], pattern))
                {
                    Console.WriteLine(info[0]);
                }
            }
        }
    }
}

