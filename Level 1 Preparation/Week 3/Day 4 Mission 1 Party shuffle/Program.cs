using System;
using System.Collections.Generic;
using System.Globalization;
namespace Day_4_Mission_1_Party_shuffle
{
    class Program
    {
        static void Shuffle(List<string> ShuffleList)
        {   
            var Random = new Random();
            var n = 0;
            for (int i = 0; ShuffleList.Count-1 > i; i++)
            {
                int j = Random.Next(0, ShuffleList.Count);
                string hold = ShuffleList[i];
                ShuffleList[i] = ShuffleList[j];
                ShuffleList[j] = hold;
            }
            return;
        }
        static void Main(string[] args)
        {
            var ShuffleList = new List<string> {"Hilda", "Anni", "David", "Matej", "Johanna", "Johannes"};

            string Unshuffled = String.Join(", ", ShuffleList);
            Console.WriteLine($"{Unshuffled}\n");

            Console.WriteLine("Generating starting order ...");

            Shuffle(ShuffleList);
            Console.WriteLine("");

            string Shuffled = String.Join(", ", ShuffleList);
            Console.WriteLine($"{Shuffled}\n");
        }
    }
}
