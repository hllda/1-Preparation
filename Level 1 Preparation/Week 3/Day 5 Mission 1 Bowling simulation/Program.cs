using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace list_tutorial
{
    class Program
    {
        static object First(List<int> standingPinsCopy)
        {   
            if (standingPinsCopy.Count == 0)
            {
            return "X";
            }

            else if (standingPinsCopy.Count == 10)
            {
            return "-";
            }

            else
            {
            return (10-standingPinsCopy.Count);
            }
        }

        static object Second(List<int> standingPins, List<int> standingPinsCopy)
        {
            if (standingPins.Count == 0)
            {
                return "/";
            }

            else if (standingPinsCopy.Count == 10)
            {
            return "-";
            }

            else if (standingPinsCopy.Count == standingPins.Count)
            {
                return "-";
            }

            else
            {
            return standingPinsCopy.Count - standingPins.Count;
            }
        }

        static void Pins(List<int> standingPins)
        { 
            // 7
            if (standingPins.Contains(7))
            {
            Console.Write("O   ");
            }
            else
            {
                Console.Write("    ");
            }

            // 8
            if (standingPins.Contains(8))
            {
                Console.Write("O   ");
            }
            else
            {
                Console.Write("    ");
            }

            // 9
            if (standingPins.Contains(9))
            {
                Console.Write("O   ");
            }
            else
            {
                Console.Write("    ");
            }

            // 10
            if (standingPins.Contains(10))
            {
                Console.WriteLine("O\n");
            }
            else
            {
                Console.WriteLine(" \n");
            }

            // 4
            if (standingPins.Contains(4))
            {
                Console.Write("  O   ");
            }
            else
            {
                Console.Write("      ");
            }

            // 5
            if (standingPins.Contains(5))
            {
                Console.Write("O   ");
            }
            else
            {
                Console.Write("    ");
            }

            // 6
            if (standingPins.Contains(6))
            {
                Console.WriteLine("O\n");
            }
            else
            {
                Console.WriteLine(" \n");
            }

            // 2
            if (standingPins.Contains(2))
            {
                Console.Write("    O   ");
            }
            else
            {
                Console.Write("        ");
            }

            // 3
            if (standingPins.Contains(3))
            {
                Console.WriteLine("O\n");
            }
            else
            {
                Console.WriteLine("\n");
            }

            // 1
            if (standingPins.Contains(1))
            {
                Console.WriteLine("      O\n");
            }
            else
            {
                Console.WriteLine("       \n");
            }
            
        }

        static void Path(List<int> standingPins, int number)
        {
        var rnd = new Random();
        int path = rnd.Next(0, 101);
        
        if (path < 33)
        {
        number += 1;
        }

        if (34 < path && path > 66)
        {
        number -= 1;
        }
        KnockPinOnPath(standingPins, number);
        }

        static void KnockPinOnPath(List<int> standingPins, int number)
        {
            if (number == 1)
            {
                if (standingPins.Contains(7))
                {
                standingPins.Remove(7);
                }
            
                else
                {
                ;
                }
            }

            if (number == 2)
            {
                if (standingPins.Contains(4))
                {
                standingPins.Remove(4);
                Path(standingPins, number);
                }
            
                else
                {
                ;
                }
            }

            if (number == 3)
            {
                if (standingPins.Contains(2))
                {
                standingPins.Remove(2);
                Path(standingPins, number);
                }
            
                else if (standingPins.Contains(8))
                {
                standingPins.Remove(8);
                Path(standingPins, number);
                }

                else
                {
                ;
                }
            }

            if (number == 4)
            {
                if (standingPins.Contains(1))
                {
                standingPins.Remove(1);
                Path(standingPins, number);
                }
            
                else if (standingPins.Contains(5))
                {
                standingPins.Remove(5);
                Path(standingPins, number);
                }

                else
                {
                ;
                }
            }    

            if (number == 5)
            {
                if (standingPins.Contains(3))
                {
                standingPins.Remove(3);
                Path(standingPins, number);
                }
            
                else if (standingPins.Contains(9))
                {
                standingPins.Remove(9);
                Path(standingPins, number);
                }

                else
                {
                ;
                }
            }

            if (number == 6)
            {
                if (standingPins.Contains(6))
                {
                standingPins.Remove(6);
                Path(standingPins, number);
                }
            }

            if (number == 7)
            {
                if (standingPins.Contains(10))
                {
                standingPins.Remove(10);
                }
            }

            else
            {
            ;
            }
        }

        static void Main(string[] args)
        {
            var random = new Random();
            int rounds = random.Next(0, 11);
            int round = rounds - 1;


            for (int x = 1; x < rounds; x++)
            {   
                var standingPins = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

                if (0 < rounds)
                { 
                Console.WriteLine($"Round: {x}/{round}");
                Console.WriteLine("+-----+\n| | | |\n| ----|\n|     |\n+-----+\n");
                Console.WriteLine($"Current Pins:\n");
                Pins(standingPins);
                Console.WriteLine("^ ^ ^ ^ ^ ^ ^");
                Console.WriteLine("1 2 3 4 5 6 7");
                Console.WriteLine("\nEnter where to roll the ball (1-7):");
                string firstText = Console.ReadLine();
                int first = Int32.Parse(firstText);
                Path(standingPins, first);
                Console.Clear();

                var standingPinsCopy = new List<int>(standingPins);
                Console.WriteLine($"Round: {x}/{round}");
                Console.WriteLine($"+-----+\n| |{First(standingPinsCopy)}| |\n| ----|\n|     |\n+-----+\n");
                Console.WriteLine($"Current Pins:\n");
                Pins(standingPins);
                Console.WriteLine("^ ^ ^ ^ ^ ^ ^");
                Console.WriteLine("1 2 3 4 5 6 7");

                if (standingPins.Count == 0)
                {
                goto skip;
                }

                Console.WriteLine("\nEnter where to roll the ball (1-7):");
                string secondText = Console.ReadLine();
                int second = Int32.Parse(secondText);
                Path(standingPins, second);
                Console.Clear();

                Console.WriteLine($"Round: {x}/{round}");
                Console.WriteLine($"+-----+\n| |{First(standingPinsCopy)}|{Second(standingPins, standingPinsCopy)}|\n| ----|\n|     |\n+-----+\n");
                Console.WriteLine($"Current Pins:\n");
                Pins(standingPins);
                Console.WriteLine("^ ^ ^ ^ ^ ^ ^");
                Console.WriteLine("1 2 3 4 5 6 7");

                standingPins.Clear();
                standingPinsCopy.Clear();
                }
                skip: 
                Console.WriteLine("\nPress Enter to continue:");
                Console.ReadKey();
                Console.Clear(); 
            }
             if (round == 0)
             {
             Console.WriteLine("You decided not to go bowling.");
             }
        }
    }
}
