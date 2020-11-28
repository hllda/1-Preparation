using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        static void Swap(List<string> names, int l, int r)
        {    
            string temp = names[l];
            names[l] = names[r];
            names[r] = temp;
            return;
        }

        static void WriteAllPermutations(List<string> names, int l, int r)
        {  
            if (names.Count == 0)
            {
            return;
            }

            if (names.Count == 1)
            {
            return;
            }

            if (names.Count == 2)
            {
            Swap(names, l, r);
            return;
            }

            else
            {
                if (l == r) return;

                else
                {
                    for (int i = l; i <= r; i++)
                    {
                        Swap(names, l, i);
                        WriteAllPermutations(names, l+1, r);
                        Swap(names, r, i);
                    }
                    return;
                }
            } 
        }

        static void Main(string[] args)
        {  
            // NAMES
            var names = new List<string> {"Hilda", "Luna", "Kanel"};
            names.Sort();
            int n = names.Count;
            
            // WRITE OUT JOINED
            string joined = String.Join(", ", names);
            Console.WriteLine($"Signed-up participants: {joined}\n");
            Console.WriteLine("Starting orders:");
            
            // WRITE ALL PERMUTATIONS
            

            for (int i = 1; i < Factorial(names.Count) + 1; i++)
            {
                Console.Write($"[{i}.");

                if (i < 10 && Factorial(names.Count) > 10) Console.Write(" ");
            
                Console.Write("] ");
               
                joined = string.Join(", ", names);
                WriteAllPermutations(names, 0, n-1);
                Console.WriteLine($"{joined}");
            }
        }
    }
}