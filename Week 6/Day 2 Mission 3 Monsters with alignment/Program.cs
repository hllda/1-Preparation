using System;
using System.IO;
using System.Text.RegularExpressions;
namespace Day_2_Mission_3_Monsters_With_Alignments
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Projects\TheIndieQuest\Week 6\Day 1 Mission 4 Slow flyers\MonsterManual.txt";
            string manual = File.ReadAllText(path);

            String[] monster = manual.Split("\n\n");

            Console.WriteLine($"Monsters with a specific alignment: ");
            for(int i = 0; i < monster.Length; i++)
            {
                String[] info = monster[i].Split("\n");

                string pattern = "(, (lawful|neutral|chaotic) (good|neutral|evil))";
                if(Regex.IsMatch(info[1],pattern))
                {
                    string[] alignment = info[1].Split(", ");
                    Console.WriteLine($"{info[0]} ({alignment[1]})");
                }
            }
        }
    }
}