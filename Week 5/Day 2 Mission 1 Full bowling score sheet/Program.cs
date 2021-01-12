using System;
using System.Collections.Generic;

namespace list_tutorial
{
    class Program
    {
        static void Holder()
        {
            int[][] pins = new int[10][];
            // DRAWING THE ROLLS OUT
            for(int i = 0; i < 10; i++)
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
                // Console.WriteLine(pointsGained[i]);


                Console.Write("Score: ");
                // Console.WriteLine(frameScores[i]);


                Console.WriteLine($"\n");

            }
        }

        static void ScoreSheet()
        {
            int[][] pins = new int[10][];
            Console.ReadKey();
            Console.Clear();

            for(int frame = 1; frame < 11; frame++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(
                   $"┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐\n"+
                    "│ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │\n"+
                    "│ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┴─┤\n"+
                    "│     │     │     │     │     │     │     │     │     │       │\n"+
                    "└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴───────┘");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
                Console.Write("┌");

                //DRAW FRAME BY FRAME
                for(int i = 0; i < frame; i++)
                {
                    if(i == 9)
                        Console.Write("─┬─┬─┬─┐");

                    else if(i == frame-1)
                        Console.Write("─┬─┬─┐");

                    else
                        Console.Write("─┬─┬─┬");
                }

                Console.Write("\n│");

                for(int i = 0; i < frame; i++)
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

                for(int i = 0; i < frame; i++)
                {
                    if(i == 9)
                        Console.Write(" └─┴─┴─┤");
                    else
                        Console.Write(" └─┴─┤");
                }


                Console.Write("\n│");
                const int Alignment = 4;



                for(int i = 0; i < frame; i++)
                {
                    if(pins[frame-1][0] == 10 && i != 9)
                    {
                        Console.Write($"     │");
                    }

                    else if(pins[frame-1][0] + pins[frame-1][1] == 10 && i != 9)
                    {
                        Console.Write($"     │");
                    }

                    else
                    {
                        if(i == 9)
                        {
                            const int AlignmentLast = 5;
                            // Console.Write($"{frameScores[i],AlignmentLast}  │");
                        }


                        //   else
                        // Console.Write($"{frameScores[i],Alignment} │");
                    }

                }

                Console.Write("\n└");

                for(int i = 0; i < frame; i++)
                {
                    if(i == 9)
                        Console.Write("───────┘");

                    else if(i == frame-1)
                        Console.Write("─────┘");

                    else
                        Console.Write("─────┴");
                }

                Console.WriteLine("\n");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine();
            Console.ReadKey();
        }

        static void Scores()
        {
            // CALCULATING THE ROLLS
            var Random = new Random();
            int[][] pins = new int[10][];
            for(int i = 0; i < 10; i++)
            {
                // THE NINE NORMAL ROUNDS
                if(i < 9)
                {
                    int first = Random.Next(0, 11);
                    if(first == 10)
                    {
                        pins[i] = new int[] { first };
                    }

                    else
                    {
                        int second = Random.Next(0, 11-first);
                        pins[i] = new int[] { first, second };
                    }

                }
                // THE TENTH SPECIAL ROUND
                else
                {
                    int first = Random.Next(0, 11);
                    int second;
                    int third;

                    if(first == 10)
                    {
                        second = Random.Next(0, 11);
                    }

                    else
                    {
                        second = Random.Next(0, 11-first);
                    }

                    if(first == 10 || second == 10 || first + second == 10)
                    {
                        if(second == 10)
                        {
                            third = Random.Next(0, 11);
                        }

                        else
                        {
                            third = Random.Next(0, 11-second);
                        }
                        pins[i] = new int[] { first, second, third };
                    }

                    else
                        pins[i] = new int[] { first, second };
                }
            }

            // CALCULATING SCORE BASED ON ROLLS
            int[] pointsGained = new int[10];
            int[] frameScores = new int[10];
            for(int i = 1; i < 11; i++)
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

            for(int i = 0; i < 10; i++)
            {
                if(i == 0)
                    frameScores[0] = pointsGained[0];

                else if(i == 9)
                    frameScores[9] = frameScores[8] + pointsGained[9];

                else
                    frameScores[i] = frameScores[i-1] + pointsGained[i];
            }

        }
        }

    }
}
