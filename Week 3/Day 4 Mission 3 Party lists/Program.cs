using System;
using System.Collections.Generic;

namespace Day_4_Mission_3_Party_lists
{
    class Program
    {      
        static int Factorial(int namesCount)
        {   
            if (namesCount == 0)
            {
            return 1;
            } 
            else
            {
            return namesCount * Factorial(namesCount - 1);
            }
        }

        static void Swap(List<string> names)
        {   var rnd1 = new Random();
            Random rnd2 = new Random();
            int namesCount = names.Count;

            int random1 = rnd1.Next(0, namesCount);
            int random2 = rnd2.Next(0, namesCount);

            string temp = names[random1];
            names[random1] = names[random2];
            names[random2] = temp;
        }

        static List<string> WriteAllPermutations(List<string> names, int factorial)
        {  
            // names will be joined to be added if unique to permutations
            List<string> permutations = new List<string>{};
            string joined = String.Join(", ", names);

            if (names.Count == 0)
            {
            return permutations;
            }

            else
            {
                do
                { 
                    bool alreadyAdded = permutations.Contains(joined);
                    if (alreadyAdded == true)
                    {
                    Swap(names);
                    joined = String.Join(", ", names);
                    }

                    else
                    {
                    permutations.Add(joined); 
                    }
                } while (permutations.Count < factorial);

            return permutations;
            }
            
        }

        static void Main(string[] args)
        {  
            // NAMES (small warning, do not go above 7 names, it works but it took 4 minutes for it to get up to 100k combinations)
            var names = new List<string> {"Hilda", "Luna", "Kanel", "João"};
            names.Sort();
 
            // WRITE OUT JOINED
            string joined = String.Join(", ", names);
            Console.WriteLine($"Signed-up participants: {joined}\n");
            Console.WriteLine("Starting orders:");
            
            // WRITE ALL PERMUTATIONS
            int factorial = Factorial(names.Count);
            List<string> permutations = new List<string>(WriteAllPermutations(names, factorial));
            permutations.Sort();
            for (int i = 0; i < factorial; i++)
            {
                Console.Write($"[{i+1}.");

                if (i < 9 && factorial > 9) Console.Write(" ");
                if (i < 99 && factorial > 99) Console.Write(" ");
                if (i < 999 && factorial > 999) Console.Write(" ");
                if (i < 9999 && factorial > 9999) Console.Write(" ");
                if (i < 99999 && factorial > 99999) Console.Write(" ");
                if (i < 999999 && factorial > 999999) Console.Write(" ");

                Console.Write("] ");
                Console.WriteLine($"{permutations[i]}");
            }
        }
    }
}