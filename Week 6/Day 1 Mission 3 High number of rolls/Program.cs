using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day_1_Mission_1_Monster_names
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Projects\TheIndieQuest\Week 6\Day 1 Mission 3 High number of rolls\MonsterManual.txt";
            string manual = File.ReadAllText(path);

            String[] monster = manual.Split("\n\n");

            for(int i = 0; i < monster.Length; i++)
            {
                String[] info = monster[i].Split("\n");

                Console.Write($"{info[0]} - 10+ dice rolls: ");
                
                string pattern = "((\\d\\d)d\\d+.\\d*)";
                if(Regex.IsMatch(info[2], pattern))
                {
                    Console.Write("True");
                }

                else
                {
                    Console.Write("False");
                }

                Console.WriteLine();
            }
        }
    }
}

