using System;
using System.IO;
namespace Day_1_Mission_1_Monster_names
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Projects\TheIndieQuest\Week 6\Day 1 Mission 1 Monster names\MonsterManual.txt";
            string manual = File.ReadAllText(path);

            String[] monster = manual.Split("\n\n");

            for(int i = 0; i < monster.Length; i++)
            {
                String[] info = monster[i].Split("\n");
                Console.WriteLine(info[0]);
            }
        }
    }
}

