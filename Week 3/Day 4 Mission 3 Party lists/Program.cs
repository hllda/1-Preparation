using System;
using System.Collections.Generic;
using System.Globalization;
namespace Day_4_Mission_3_Party_lists
{
    class Program
    {      
        static int Factorial(int n)
        {   
            if (n == 0)
            {
            return 1;
            } 
            else
            {
            return n * Factorial(n - 1);
            }
        } 
        
        
        
        static string WriteAllPermutations(List<string> names)
        {
            var Random = new Random();
            for (int i = 0; names.Count-1 > i; i++)
            {
                int j = Random.Next(0, names.Count);
                string hold = names[i];
                names[i] = names[j];
                names[j] = hold;
            }
            
            
            int timesPerName = Factorial(names.Count)/names.Count;
            return "";
        }



        static void Main(string[] args)
        {
            var names = new List<string> {"Hilda", "Anni", "David", "Matej"};
            names.Sort();
            string joined = String.Join(", ", names);
            Console.WriteLine($"Signed-up participants: {joined}\n");
            Console.WriteLine("Starting orders:");


            for (int num = 1; num < Factorial(names.Count)+1; num++)
            {
            Console.Write($"{num}. ");
            joined = string.Join(", ", names);
            WriteAllPermutations(names);
            Console.WriteLine($"{joined}");
            }
            var Random = new Random();
            int n = Random.Next(0, 11);
        }
    }
}


