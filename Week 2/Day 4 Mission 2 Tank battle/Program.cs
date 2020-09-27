using System;

namespace Day_4_Mission_2_Tank_battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WARNING, A TANK IS GETTING TOO CLOSE, STOP IT!\n\n");
            var random = new Random();
            int distance = random.Next(40, 70);
            
            Console.WriteLine("MAP:\n");
            Console.Write("_/");

            for (int i = 0; i < distance; i++)
            {
            Console.Write("_");
            }
            
            Console.Write("T");
    
            










        }
    }
}
