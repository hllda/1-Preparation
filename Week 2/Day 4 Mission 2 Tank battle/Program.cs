using System;

namespace Day_4_Mission_2_Tank_battle
{
    class Program
    {
        static void Main(string[] args)
        {   
            bool tankAlive = true;
            var random = new Random();
            int distance = random.Next(40, 71);
            
            Console.WriteLine("WARNING, A TANK IS GETTING TOO CLOSE, STOP IT!\n");
            Console.WriteLine("\nWhat is your name, commander?");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Clear();

            while (tankAlive && distance > 0)
            {
                int move = random.Next(1, 16);

                Console.WriteLine("MAP:\n");
                   Console.Write("_/");
                for (int j = 0; j < 80; j++)
                {   
                    
                    if (j == distance)
                    {
                        Console.Write("T");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }

                Console.WriteLine($"\n\nAim your shot, {name}!");
                Console.Write($"\nEnter distance: ");
                string number = Console.ReadLine();
                int shot = Int32.Parse(number);

                Console.Clear();

                Console.WriteLine("MAP:\n");
                Console.Write("_/");

                for (int j = 0; j < 76; j++)
                {
                    if (j == shot)
                    {
                        Console.Write("*");

                    }

                    else if (j == distance)
                    {
                        Console.Write("T");
                    }

                    else
                    {
                        Console.Write("_");
                    }
                }

                Console.WriteLine();
                if (shot == distance)
                {
                    Console.WriteLine("\nYou hit the target!");
                    tankAlive = false;
                }

                if (shot < distance)
                {
                    Console.WriteLine("\nOh no, it was too short!");
                }

                if (shot > distance)
                {
                    Console.WriteLine("\nOh no, it went too far!");
                }

                Console.WriteLine($"Press any key to continue!");
                Console.ReadKey();
                Console.Clear();
                distance -= move;
            }

            if (tankAlive == true)
            {
                Console.WriteLine("\nTHE TANK WON, GAME OVER");
            }
            
            if (tankAlive == false)
            {
            Console.WriteLine("\nTANK YOU FOR DEFEATING THE TANK!");
            }
        }
    }
}