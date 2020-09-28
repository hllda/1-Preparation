using System;

namespace The_Tank_Stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variabls
            var random = new Random();
            string shot = "none";
            bool tank_alive = true;

            //Ask name
            Console.WriteLine("What is your name commander?");
            string name = Console.ReadLine();

            Console.WriteLine($"Name: {name}");
            Console.Clear();
            //Draw battlefield
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("_/");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("");
            int tank_distance = random.Next(40, 71);

            for (int x = 0; x < 80; x++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                if (x == tank_distance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("T");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("_");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            tank_distance -= random.Next(1, 16);
            Console.WriteLine("");

            //For loop for shooting 5 shots
            while (tank_alive == true && tank_distance > 0)
            {

                //Ask player distance
                Console.WriteLine($"Aim your shot, {name}!");
                Console.Write("Enter your shot: ");
                shot = Console.ReadLine();
                int shot_int = Int32.Parse(shot);
                Console.Clear();

                //Draw battlefield
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("_/");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                for (int x = 0; x < 80 && tank_alive == true; x++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    if (x == shot_int)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    else if (x == tank_distance)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("T");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("_");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("");
                Console.WriteLine("");
                
                //Tell player if it hit
                if (tank_distance == shot_int)
                {
                    Console.Write("Good job! You hit the tank!");
                    tank_alive = false;

                }
                else if (tank_distance > shot_int)
                {
                    Console.Write("Too short.");

                }
                else if (tank_distance < shot_int)
                {
                    Console.Write("Too far.");

                }

                Console.WriteLine("");
                tank_distance -= random.Next(1, 16);

            }
            Console.WriteLine("");
            Console.Clear();
            Console.WriteLine("\nThe Tank has gone too far, GAME OVER!");
            Console.Clear();
        }
    }
}
