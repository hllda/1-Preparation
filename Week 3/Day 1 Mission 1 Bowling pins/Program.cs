using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace list_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int rounds = random.Next(6, 11);
            int round = rounds - 1;

                for (int x = 1; x < rounds; x++)
                {   
                    var standingPins = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

                    if (0 < rounds)
                    { 
                    Console.WriteLine($"Round: {x}/{round}");
                    Console.WriteLine("+-----+\n| | | |\n| ----|\n|     |\n+-----+\n");
                    Console.WriteLine("Current Pins:\nO   O   O   O\n\n  O   O   O\n\n    O   O\n\n      O\n");
                    Console.WriteLine("Press Enter to roll:");
                    Console.ReadKey();
                    Console.Clear();

                    int roll = random.Next(0, 11);
                    int first = roll;
                    Console.WriteLine($"Round: {x}/{round}");
                    Console.Write("+-----+\n|");
                        if (first == 10)
                        {
                        Console.Write(" |X| |");
                        }

                        else
                        {
                        if (first == 0)
                        {
                            Console.Write($" |-| |");
                        }

                        else
                        {
                            if (first < 10 && first > 0)
                            {
                                Console.Write($" |{first}| |");
                            }
                        }
                        }

                        Console.Write("\n| ----|\n|     |\n+-----+");

                    
                        for (int m = 0; m < first; m++)
                        {
                        int rnd1 = random.Next(standingPins.Count);
                        standingPins.RemoveAt(rnd1);
                        }

                    string stan = String.Join(", ", standingPins);
                           Console.WriteLine($"{stan}");

                    //////////////////// CHECKING PINS /////////////////////////
                    Console.WriteLine("\n");
                        Console.WriteLine($"Current Pins:");

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

                    //////////////////// CHECKING PINS /////////////////////////

                    Console.WriteLine($"Press Enter to roll:");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine($"Round: {x}/{round}");
                    Console.Write("+-----+");

                    Console.Write("\n|"); ;
                    int second = random.Next(first);
                    int sum = first + second;


                    if (first == 10)
                    {
                        Console.Write(" |X| |");
                    }

                    else
                    {
                        if (sum >= 10)
                        {
                            Console.Write($" |{first}|/|");
                        }

                        else
                        {
                            if (first == 0 && second == 0)
                            {
                                Console.Write($" |-|-|");
                            }

                            else
                            {

                                if (second == 0)
                                {
                                    Console.Write($" |{first}|-|");
                                }

                                else
                                {
                                    if (first == 0)
                                    {
                                        Console.Write($" |-|{second}|");
                                    }

                                    else
                                    {
                                        Console.Write($" |{first}|{second}|");
                                    }
                                }
                            }
                        }
                    }
                    Console.Write("\n|");
                    Console.Write(" ----|");
                    Console.Write("\n|");
                    Console.Write("     |");
                    Console.Write("\n+");
                    Console.Write("-----+");
                    Console.WriteLine("\n");


                    for (int n = 0; n < second; n++)
                    {
                    int rnd2 = random.Next(standingPins.Count);
                    if  (rnd2 > 0)  
                    {   
                    standingPins.RemoveAt(rnd2);
                    }
                    }

                    if (sum > 10 || first == 10 || second == 10)
                    {
                    standingPins.Clear();
                    }

                    string stann = String.Join(", ", standingPins);
                    Console.WriteLine($"{stann}");


                    // CHECKING PINS
                    Console.WriteLine($"Current Pins:");
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


                    //////////////////// CHECKING PINS /////////////////////////
                }

                else
                {
                Console.WriteLine("You decided not to go bowling.");
                }
                    Console.WriteLine($"Press Enter to proceed:");
                    Console.ReadKey();
                    Console.Clear();

                
                }
        }
    }
}

