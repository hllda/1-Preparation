using System;
namespace list_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // CALCULATING THE ROLLS
            var Random = new Random();
            int[][] pins = new int[10][];
            for(int i = 0;i < 10;i++)
            {
                // THE NINE NORMAL ROUNDS
                if(i < 9)
                {
                    int first = Random.Next(0,11);
                    if(first == 10)
                    {
                        pins[i] = new int[] { first };
                    }

                    else
                    {
                        int second = Random.Next(0,11-first);
                        pins[i] = new int[] { first,second };
                    }

                }
                // THE TENTH SPECIAL ROUND
                else
                {
                    int first = Random.Next(0,11);
                    int second;
                    int third;

                    if(first == 10)
                    {
                        second = Random.Next(0,11);
                    }

                    else
                    {
                        second = Random.Next(0,11-first);
                    }

                    if(first == 10 || second == 10 || first + second == 10)
                    {
                        if(second == 10)
                        {
                            third = Random.Next(0,11);
                        }

                        else
                        {
                            third = Random.Next(0,11-second);
                        }
                        pins[i] = new int[] { first,second,third };
                    }

                    else
                        pins[i] = new int[] { first,second };
                }
            }

            // CALCULATING SCORE BASED ON ROLLS
            int[] pointsGained = new int[10];
            int[] frameScores = new int[10];
            for(int i = 1;i < 11;i++)
            {
                if(i < 9)
                {
                    if(pins[i-1][0] == 10)
                    {
                        if(pins[i].Length == 2)
                            pointsGained[i-1] = pins[i-1][0] + pins[i][0] + pins[i][1];
                        else
                            pointsGained[i-1] = pins[i-1][0] + pins[i][0] + pins[i+1][0];
                    }

                    else if(pins[i-1][0] + pins[i-1][1] == 10)
                    {
                        pointsGained[i-1] = pins[i-1][0] + pins[i-1][1] + pins[i][0];
                    }

                    else
                    {
                        pointsGained[i-1] = pins[i-1][0] + pins[i-1][1];
                    }
                }

                // TENTH
                else
                {
                    if(pins[i-1].Length == 3)
                    {
                        pointsGained[i-1] = pins[i-1][0] + pins[i-1][1] + pins[i-1][2];
                    }

                    else if(pins[i-1].Length == 2)
                    {
                        pointsGained[i-1] = pins[i-1][0] + pins[i-1][1];
                    }

                }


            }

            for(int i = 0;i < 10;i++)
            {
                if(i == 0)
                    frameScores[0] = pointsGained[0];

                else if(i == 9)
                    frameScores[9] = frameScores[8] + pointsGained[9];

                else
                    frameScores[i] = frameScores[i-1] + pointsGained[i];
            }

            // DRAWING THE ROLLS OUT
            for(int i = 0;i < 10;i++)
            {
                Console.WriteLine($"FRAME {i+1}");
                Console.Write($"Roll 1: ");

                if(pins[i][0] == 10)
                {
                    Console.WriteLine("X");
                }

                else if(pins[i][0] == 0)
                {
                    Console.WriteLine("-");
                }

                else
                {
                    Console.WriteLine(pins[i][0]);
                }


                if(pins[i].Length > 1)
                {
                    Console.Write($"Roll 2: ");
                    if(pins[i][1] == 10 && pins[i][0] != 0)
                    {
                        Console.WriteLine("X");
                    }

                    else if(pins[i][0] + pins[i][1] == 10 && pins[i][0] != 10)
                    {
                        Console.WriteLine("/");
                    }

                    else if(pins[i][1] == 0)
                    {
                        Console.WriteLine("-");
                    }

                    else
                    {
                        Console.WriteLine(pins[i][1]);
                    }
                }


                if(pins[i].Length > 2)
                {
                    Console.Write($"Roll 3: ");
                    if(pins[i][2] == 10 && pins[i][1] != 0)
                    {
                        Console.WriteLine("X");
                    }

                    else if(pins[i][1] + pins[i][2] == 10 && pins[i][1] != 10 && pins[i][2] != 0 && pins[i][0] + pins[i][1] != 10)
                    {
                        Console.WriteLine("/");
                    }

                    else if(pins[i][2] == 0)
                    {
                        Console.WriteLine("-");
                    }

                    else
                    {
                        Console.WriteLine(pins[i][2]);
                    }


                }
                Console.Write($"Knocked pins: ");

                if(pins[i].Length == 3)
                    Console.WriteLine(pins[i][0] + pins[i][1] + pins[i][2]);

                else if(pins[i].Length == 2)
                    Console.WriteLine(pins[i][0] + pins[i][1]);

                else
                    Console.WriteLine(pins[i][0]);

                Console.Write("Points gained: ");
                Console.WriteLine(pointsGained[i]);


                Console.Write("Score: ");
                Console.WriteLine(frameScores[i]);


                Console.WriteLine($"\n");

            }

            Console.WriteLine(
                              $"┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐\n"+
                               "│ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │\n"+
                               "│ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┴─┤\n"+
                               "│     │     │     │     │     │     │     │     │     │       │\n"+
                               "└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴───────┘\n");


            for(int frame = 10;frame < 11;frame++)
            {
                Console.Write("\n┌");
                //DRAW FRAME BY FRAME
                for(int i = 0;i < frame;i++)
                {
                    if(i == 9)
                        Console.Write("─┬─┬─┬─┐");

                    else if(i == frame-1)
                        Console.Write("─┬─┬─┐");

                    else
                        Console.Write("─┬─┬─┬");
                }

                Console.Write("\n│");

                for(int i = 0;i < frame;i++)
                {
                    Console.Write(" │");
                    if(pins[i][0] == 10)
                    {
                        if(i == 9)
                            Console.Write("X│");

                        else
                        {
                            Console.Write("X│ │");
                            continue;
                        }

                    }

                    else if(pins[i][0] == 0)
                    {
                        Console.Write("-│");
                    }

                    else
                    {
                        Console.Write($"{pins[i][0]}│");
                    }

                    if(pins[i][1] == 10 && i == 9 && pins[i][0] != 0)
                    {
                        Console.Write($"X│");
                    }

                    else if(pins[i][0] + pins[i][1] == 10)
                    {
                        Console.Write($"/│");
                    }

                    else if(pins[i][1] == 0)
                    {
                        Console.Write($"-│");
                    }

                    else
                    {
                        Console.Write($"{pins[i][1]}│");
                    }

                    if(i == 9 && (pins[i][0] + pins[i][1] == 10 || pins[i][0] == 10 || pins[i][1] == 10))
                    {
                        if(pins[i][2] == 10)
                        {
                            Console.Write("X│");
                        }

                        else if(pins[i][1] + pins[i][2] == 10 && pins[i][0] + pins[i][1] != 10)
                        {
                            Console.Write($"/│");
                        }

                        else if(pins[i][2] == 0)
                        {
                            Console.Write($"-│");
                        }

                        else
                        {
                            Console.Write($"{pins[i][2]}│");
                        }


                    }

                    else if(i == 9)
                    {
                        Console.Write(" │");
                    }
                }

                Console.Write("\n│");

                for(int i = 0;i < frame;i++)
                {
                    if(i == 9)
                        Console.Write(" └─┴─┴─┤");
                    else
                        Console.Write(" └─┴─┤");
                }

                /*
const int NameAlignment = -10;
const int ValueAlignment = 6;

double a = 3;
double b = 4;
Console.WriteLine($"Three classical Pythagorean means of {a} and {b}:");
Console.WriteLine($"|{"Arithmetic",NameAlignment}|{0.5 * (a + b),ValueAlignment:F3}|");
Console.WriteLine($"|{"Geometric",NameAlignment}|{Math.Sqrt(a * b),ValueAlignment:F3}|");
Console.WriteLine($"|{"Harmonic",NameAlignment}|{2 / (1 / a + 1 / b),ValueAlignment:F3}|");
*/



                Console.Write("\n│");

                for(int i = 0;i < frame;i++)
                {

                    if(i == 9)
                        Console.Write("     0 │");

                    else
                        Console.Write("   0 │");

                }


                Console.Write("\n└");

                for(int i = 0;i < frame;i++)
                {
                    if(i == 9)
                        Console.Write("───────┘");

                    else if(i == frame-1)
                        Console.Write("─────┘");

                    else
                        Console.Write("─────┴");
                }


                Console.ReadKey();
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
