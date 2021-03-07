using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Threading;
namespace Day_3_Mission_2_A_better_Join
{
    class Program
    {
        static string JoinWithAnd(List<string> names, bool useSerialComma)
        {
            int count = names.Count;
            if (count == 0)
            {
            return "";
            }
            else if (count == 1)
            {
            return$"{names[0]}.";
            }

            else if (count == 2)
            {
            return$"{names[0]} and {names[1]}."; 
            }
            else
            {
            var namesCopy = new List<string>(names);
            namesCopy.RemoveAt(namesCopy.Count-1);
            string joined = String.Join(", ", namesCopy);
                if (useSerialComma == true)
                {
                return $"{joined}, and {names[names.Count-1]}";
                }
                else
                {
                return $"{joined} and {names[names.Count-1]}";
                }
            } 
        }
        static void Main(string[] args)
        {
            List<string> names = new List<string> {"Hilda", "Luna", "Kanel", "João", "Nellie"};        
            while (0 < names.Count)
            {
            Console.WriteLine($"The heroes in the party are: {JoinWithAnd(names, true)}");
            names.RemoveAt(0);
            }
        }
    }
}
