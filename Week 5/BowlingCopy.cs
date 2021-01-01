using System;
using System.Collections.Generic;

namespace list_tutorial
{
    class Program
    {
        static void ScoreSheet()
        {
            Console.CursorVisible = false;
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

            Console.ReadKey();
            Console.Clear();

            for(int frame = 1;frame < 11;frame++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(
                   $"┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐\n"+
                    "│ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │\n"+
                    "│ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┴─┤\n"+
                    "│     │     │     │     │     │     │     │     │     │       │\n"+
                    "└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴───────┘");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0,0);
                Console.Write("┌");
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


                Console.Write("\n│");
                const int Alignment = 4;



                for(int i = 0;i < frame;i++)
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
                            Console.Write($"{frameScores[i],AlignmentLast}  │");
                        }


                        else
                            Console.Write($"{frameScores[i],Alignment} │");
                    }


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

                Console.WriteLine("\n");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine();
            Console.ReadKey();
        }


        static object First(List<int> standingPinsCopy)
        {
            if(standingPinsCopy.Count == 0)
            {
                return "X";
            }

            else if(standingPinsCopy.Count == 10)
            {
                return "-";
            }

            else
            {
                return (10-standingPinsCopy.Count);
            }
        }

        static object Second(List<int> standingPins,List<int> standingPinsCopy)
        {
            if(standingPins.Count == 0)
            {
                return "/";
            }

            else if(standingPinsCopy.Count == 10)
            {
                return "-";
            }

            else if(standingPinsCopy.Count == standingPins.Count)
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
            if(standingPins.Contains(7))
            {
                Console.Write("O   ");
            }
            else
            {
                Console.Write("    ");
            }

            // 8
            if(standingPins.Contains(8))
            {
                Console.Write("O   ");
            }
            else
            {
                Console.Write("    ");
            }

            // 9
            if(standingPins.Contains(9))
            {
                Console.Write("O   ");
            }
            else
            {
                Console.Write("    ");
            }

            // 10
            if(standingPins.Contains(10))
            {
                Console.WriteLine("O\n");
            }
            else
            {
                Console.WriteLine(" \n");
            }

            // 4
            if(standingPins.Contains(4))
            {
                Console.Write("  O   ");
            }
            else
            {
                Console.Write("      ");
            }

            // 5
            if(standingPins.Contains(5))
            {
                Console.Write("O   ");
            }
            else
            {
                Console.Write("    ");
            }

            // 6
            if(standingPins.Contains(6))
            {
                Console.WriteLine("O\n");
            }
            else
            {
                Console.WriteLine(" \n");
            }

            // 2
            if(standingPins.Contains(2))
            {
                Console.Write("    O   ");
            }
            else
            {
                Console.Write("        ");
            }

            // 3
            if(standingPins.Contains(3))
            {
                Console.WriteLine("O\n");
            }
            else
            {
                Console.WriteLine("\n");
            }

            // 1
            if(standingPins.Contains(1))
            {
                Console.WriteLine("      O\n");
            }
            else
            {
                Console.WriteLine("       \n");
            }

        }

        static void Path(List<int> standingPins,int number)
        {
            var rnd = new Random();
            int path = rnd.Next(0,101);

            if(path < 33)
            {
                number += 1;
            }

            if(34 < path && path > 66)
            {
                number -= 1;
            }
            KnockPinOnPath(standingPins,number);
        }

        static void KnockPinOnPath(List<int> standingPins,int number)
        {
            if(number == 1)
            {
                if(standingPins.Contains(7))
                {
                    standingPins.Remove(7);
                }

                else
                {
                    ;
                }
            }

            if(number == 2)
            {
                if(standingPins.Contains(4))
                {
                    standingPins.Remove(4);
                    Path(standingPins,number);
                }

                else
                {
                    ;
                }
            }

            if(number == 3)
            {
                if(standingPins.Contains(2))
                {
                    standingPins.Remove(2);
                    Path(standingPins,number);
                }

                else if(standingPins.Contains(8))
                {
                    standingPins.Remove(8);
                    Path(standingPins,number);
                }

                else
                {
                    ;
                }
            }

            if(number == 4)
            {
                if(standingPins.Contains(1))
                {
                    standingPins.Remove(1);
                    Path(standingPins,number);
                }

                else if(standingPins.Contains(5))
                {
                    standingPins.Remove(5);
                    Path(standingPins,number);
                }

                else
                {
                    ;
                }
            }

            if(number == 5)
            {
                if(standingPins.Contains(3))
                {
                    standingPins.Remove(3);
                    Path(standingPins,number);
                }

                else if(standingPins.Contains(9))
                {
                    standingPins.Remove(9);
                    Path(standingPins,number);
                }

                else
                {
                    ;
                }
            }

            if(number == 6)
            {
                if(standingPins.Contains(6))
                {
                    standingPins.Remove(6);
                    Path(standingPins,number);
                }
            }

            if(number == 7)
            {
                if(standingPins.Contains(10))
                {
                    standingPins.Remove(10);
                }
            }

            else
            {
                ;
            }
        }

        static void Holder()
        {

            var random = new Random();
            int rounds = 10;
            int round = rounds - 1;


            for(int x = 1;x < rounds;x++)
            {
                

                ScoreSheet();
                Console.WriteLine($"Round: {x}/{round}");
                Console.WriteLine("+-----+\n| | | |\n| ----|\n|     |\n+-----+\n");
                Console.WriteLine($"Current Pins:\n");
                Pins(standingPins);
                Console.WriteLine("^ ^ ^ ^ ^ ^ ^");
                Console.WriteLine("1 2 3 4 5 6 7");
                Console.WriteLine("\nEnter where to roll the ball (1-7):");
                string firstText = Console.ReadLine();
                int first = Int32.Parse(firstText);
                Path(standingPins,first);
                Console.Clear();

                var standingPinsCopy = new List<int>(standingPins);
                Console.WriteLine($"Round: {x}/{round}");
                Console.WriteLine($"+-----+\n| |{First(standingPinsCopy)}| |\n| ----|\n|     |\n+-----+\n");
                Console.WriteLine($"Current Pins:\n");
                Pins(standingPins);
                Console.WriteLine("^ ^ ^ ^ ^ ^ ^");
                Console.WriteLine("1 2 3 4 5 6 7");

                if(standingPins.Count == 0)
                {
                    goto skip;
                }

                Console.WriteLine("\nEnter where to roll the ball (1-7):");
                string secondText = Console.ReadLine();
                int second = Int32.Parse(secondText);
                Path(standingPins,second);
                Console.Clear();

                Console.WriteLine($"Round: {x}/{round}");
                Console.WriteLine($"+-----+\n| |{First(standingPinsCopy)}|{Second(standingPins,standingPinsCopy)}|\n| ----|\n|     |\n+-----+\n");
                Console.WriteLine($"Current Pins:\n");
                Pins(standingPins);
                Console.WriteLine("^ ^ ^ ^ ^ ^ ^");
                Console.WriteLine("1 2 3 4 5 6 7");

                standingPins.Clear();
                standingPinsCopy.Clear();

                skip:
                Console.WriteLine("\nPress Enter to continue:");
                Console.ReadKey();
                Console.Clear();

            }


        }

        static void Main(string[] args)
        {
            for(int rounds = 1; rounds < 11; rounds++)
            {
                Console.WriteLine($"Round: {rounds}/10");

                Console.WriteLine("ScoreSheet");

                Console.WriteLine($"Current Pins:\n");
                
                var standingPins = new List<int> { 1,2,3,4,5,6,7,8,9,10 };
                Pins(standingPins);

                Console.WriteLine("^ ^ ^ ^ ^ ^ ^");

                Console.WriteLine("1 2 3 4 5 6 7");

                Console.WriteLine("Enter where to roll the ball (1-7)");

                Console.ReadKey();

            }




        }




    }
}
