using System;
using System.IO;

namespace Day_5_Mission_2_Phone_number_search
{
    class Program
    {
        static bool IsPhoneNumber(string word)
        {
            char[] words = word.ToCharArray();

            for(int i = 0; i < 255; i++)
            {
                if(i == 45)
                    i = 46;

                if(i == 48)
                    i = 58;

                if(word.Contains((char)i))
                    return false;
            }

            if(word.Length != 12 || word[3] != '-' || word[7] != '-')
                return false;

            return true;
        }
        static void Main(string[] args)
        {
            string path = @"D:\Projects\TheIndieQuest\Week 5\Day 5 Mission 2 Phone number search\message.txt";
            string[] words = File.ReadAllText(path).Split(' ',',','.');

            Console.WriteLine("The phone numbers present in this file are:");
            foreach(string word in words)
            {
                if(IsPhoneNumber(word) == true)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
