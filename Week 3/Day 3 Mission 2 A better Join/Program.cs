using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Threading;

namespace Day_3_Mission_2_A_better_Join
{
    class Program
    {
        static string JoinWithAnd(List<string> names, bool useSerialComma = true)
        {
            int count = names.Count;
            if (count == 0)
            {
            return ("");
            }

            else if (count == 1)
            {
            return ($"{names[0]}.");
            }

            else if (count == 2)
            {
            return ($"{names[0]} and {names[1]}."); 
            }

            else
            {
                for (int i = 0; i > names.Count; i--)
                {
                Console.WriteLine();
                }
                return ($"");
            }  
        }
        static void Main(string[] args)
        {
            
            List<string> names = new List<string> {"Jazlyn", "Theron", "Dayana", "Rolando", "Hilda", "Joao", "Matej", "Anni"};
            
            var namesCopy = new List<string>(names);

            while (names.Count > 0)
            {
            if (names.Count == )
                namesCopy.RemoveAt(namesCopy.Count - 1);
            }
            
   
            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(names, true)}");
         
           
            

            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(names, true)}");

            namesCopy.RemoveAt(namesCopy.Count - 1);

            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(names, true)}");

            namesCopy.RemoveAt(namesCopy.Count - 1);

            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(names, false)}");



        }
    }
}
