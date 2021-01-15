using System;
namespace Day_2_Mission_1_Full_bowling_score_sheet
{
    class Program
    {
        static int pinsDown;
        static int firstRoll;
        static int secondRoll;
        static int thirdRoll;
        static int totalScore;
        static string[] pointsDisplay = new string[10];

        static void FirstRoll(string[,] score, int pinsDown, int rounds)
        {
            firstRoll = pinsDown;
            if(firstRoll == 10)
                score[rounds, 0] = "X";

            else if(firstRoll == 0)
                score[rounds, 0] = "-";

            else
                score[rounds, 0] = (firstRoll).ToString();
        }

        static void SecondRoll(string[,] score, int pinsDown, int rounds, int firstRoll)
        {
            secondRoll = pinsDown - firstRoll;

            if(pinsDown == 10)
            {
                if(rounds == 9 && score[9, 0] == "X")
                {
                    score[rounds, 1] = "X";
                }

                else
                {
                    score[rounds, 1] = "/";
                }
            }

            else if(secondRoll == 0)
                score[rounds, 1] = "-";

            else
                score[rounds, 1] = (secondRoll).ToString();
        }

        static void ThirdRoll(string[,] score, int pinsDown, int rounds, int firstRoll, int secondRoll)
        {
            if(score[9, 0] == "X" && score[9, 1] != "X")
                thirdRoll = pinsDown - secondRoll;

            else
            {
                thirdRoll = pinsDown;
            }

            if(pinsDown == 10)
            {
                if(score[9, 1] == "X")
                {
                    score[9, 2] = "X";
                }

                else
                {
                    score[9, 2] = "/";
                }
            }

            else if(thirdRoll == 0)
                score[9, 2] = "-";

            else
                score[9, 2] = (secondRoll).ToString();
        }

        static void ScoreSheet(string[,] score, int[] pointsGained, int[] frameScores, int firstRoll, int secondRoll, int thirdRoll, int rounds)
        {
            for(int i = 0; i < 10; i++)
            {
                if(rounds != 9)
                    if(score[i, 0] == "X" || score[i, 1] == "/")
                        try
                        {
                            if(score[i, 0] == "X")
                            {
                                pointsGained[i] += frameScores[i] + frameScores[i+1] + frameScores[i+2];
                            }

                            else if(score[i, 1] == "/")
                            {
                                pointsGained[i] += frameScores[i] + frameScores[i+1];
                            }

                            else
                            {
                                pointsGained[i] += frameScores[i];
                            }
                        }

                        catch
                        {
                            pointsGained[i] += frameScores[i];
                        }

                    else
                    {
                        pointsGained[i] += frameScores[i];
                    }

                else
                {
                    try
                    {
                        pointsGained[9] += frameScores[9];
                    }

                    catch
                    {
                    }

                }
            }







            const int alignment = 5;
            const int alignmentLast = 7;


            int[,] scoreInt = new int[10, 2];
            scoreInt[rounds, 0] = firstRoll;
            scoreInt[rounds, 1] = secondRoll;


            if(rounds != 9)
                try
                {
                    if(score[rounds, 0] == "X")
                        frameScores[rounds] = 10 + frameScores[rounds+1];

                    else if(score[rounds, 1] == "/")
                        frameScores[rounds] = 10 + scoreInt[rounds+1, 0];

                    else
                        frameScores[rounds] = scoreInt[rounds, 0] + scoreInt[rounds, 1];
                }

                catch
                {

                }

            totalScore += frameScores[rounds];

            if(frameScores[rounds] != 0)
                pointsDisplay[rounds] = totalScore.ToString();

            Console.WriteLine();
            Console.WriteLine($"┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐");

            Console.WriteLine($"│ │{score[0, 0]}│{score[0, 1]}│ │{score[1, 0]}│{score[1, 1]}│ │{score[2, 0]}│{score[2, 1]}" +
                              $"│ │{score[3, 0]}│{score[3, 1]}│ │{score[4, 0]}│{score[4, 1]}│ │{score[5, 0]}│{score[5, 1]}" +
                              $"│ │{score[6, 0]}│{score[6, 1]}│ │{score[7, 0]}│{score[7, 1]}│ │{score[8, 0]}│{score[8, 1]}" +
                              $"│ │{score[9, 0]}│{score[9, 1]}│{score[9, 2]}│");

            Console.WriteLine($"│ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┴─┤");

            Console.WriteLine($"│{pointsDisplay[0],alignment}│{pointsDisplay[1],alignment}│{pointsDisplay[2],alignment}" +
                $"│{pointsDisplay[3],alignment}│{pointsDisplay[4],alignment}│{pointsDisplay[5],alignment}" +
                $"│{pointsDisplay[6],alignment}│{pointsDisplay[7],alignment}│{pointsDisplay[8],alignment}│{pointsDisplay[9],alignmentLast}│");

            Console.Write($"└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴───────┘");
        }

        static void KnockPinOnPath(char[] pins, int chosenLane)
        {
            if(chosenLane == 1)
            {
                if(pins[1] == 'O')
                {
                    pins[1] = ' ';
                    pinsDown += 1;
                }
            }

            else if(chosenLane == 2)
            {
                if(pins[2] == 'O')
                {
                    pins[2] = ' ';
                    pinsDown += 1;
                    Path(pins, chosenLane, pinsDown);
                }
            }

            else if(chosenLane == 3)
            {
                if(pins[3] == 'O')
                {
                    pins[3] = ' ';
                    pinsDown += 1;
                    Path(pins, chosenLane, pinsDown);
                }

                else if(pins[8] == 'O')
                {
                    pins[8] = ' ';
                    pinsDown += 1;
                    Path(pins, chosenLane, pinsDown);
                }
            }

            else if(chosenLane == 4)
            {
                if(pins[4] == 'O')
                {
                    pins[4] = ' ';
                    pinsDown += 1;
                    Path(pins, chosenLane, pinsDown);
                }

                else if(pins[9] == 'O')
                {
                    pins[9] = ' ';
                    pinsDown += 1;
                    Path(pins, chosenLane, pinsDown);
                }
            }

            else if(chosenLane == 5)
            {
                if(pins[5] == 'O')
                {
                    pins[5] = ' ';
                    pinsDown += 1;
                    Path(pins, chosenLane, pinsDown);
                }

                else if(pins[0] == 'O')
                {
                    pins[0] = ' ';
                    pinsDown += 1;
                    Path(pins, chosenLane, pinsDown);
                }
            }

            else if(chosenLane == 6)
            {
                if(pins[6] == 'O')
                {
                    pins[6] = ' ';
                    pinsDown += 1;
                    Path(pins, chosenLane, pinsDown);
                }
            }

            else if(chosenLane == 7)
            {
                if(pins[7] == 'O')
                {
                    pins[7] = ' ';
                    pinsDown += 1;
                }
            }
        }

        static void Path(char[] pins, int chosenLane, int pinsDown)
        {
            var Random = new Random();
            int path = Random.Next(0, 101);
            if(path < 33)
            {
                chosenLane++;
            }

            if(34 < path && path > 66)
            {
                chosenLane--;
            }

            for(int i = 0; i < 8; i++)
                KnockPinOnPath(pins, i);
        }

        static int ChosenLane(int chosenLane)
        {
            // CHECK IF THE ENTERED NUMBER IS VALID
            Console.CursorVisible = true;
            try
            {
                chosenLane = Int32.Parse(Console.ReadLine());

                if(0 < chosenLane && chosenLane < 8)
                {
                }

                else
                {
                    Console.WriteLine("You have to enter a valid number.\nPress any key to try again.");
                    chosenLane = 666;
                    Console.CursorVisible = false;
                    Console.ReadKey();
                }
            }

            catch
            {
                Console.WriteLine("You have to enter a valid number.\nPress any key to try again.");
                chosenLane = 666;
                Console.CursorVisible = false;
                Console.ReadKey();
            }

            return chosenLane;
        }

        static void DrawPins(char[] pins)
        {
            //DRAW THE STANDING PINS
            Console.WriteLine($"{pins[1]}   {pins[8]}   {pins[0]}   {pins[7]}\n");
            Console.WriteLine($"  {pins[2]}   {pins[9]}   {pins[6]}\n");
            Console.WriteLine($"    {pins[3]}   {pins[5]}\n");
            Console.WriteLine($"      {pins[4]}\n");
        }

        static void Interface(int rounds, string roll, char[] pins, bool end)
        {
            // DRAWS THE INTERFACE
            Console.Clear();
            Console.WriteLine($"Round: {rounds}/10");
            Console.WriteLine($"{roll} roll\n");
            Console.WriteLine($"Current Pins:\n");
            DrawPins(pins);
            Console.WriteLine("^ ^ ^ ^ ^ ^ ^");
            Console.Write("1 2 3 4 5 6 7");

            if(end == false)
                Console.WriteLine("\n\nEnter where to roll the ball (1-7)");
        }

        static void Main(string[] args)
        {
            int chosenLane = 666;
            string[,] score = new string[10, 3];

            int[] frameScores = new int[10];
            int[] pointsGained = new int[10];

            for(int y = 0; y < 10; y++)
                for(int x = 0; x < 3; x++)
                    score[y, x] = " ";

            for(int rounds = 0; rounds < 10; rounds++)
            {
                // NORMAL ROUNDS
                if(rounds < 9)
                {
                    char[] pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };
                    pinsDown = 0;

                    // FIRST ROLL
                    retryFirst:
                    Interface(rounds+1, "First", pins, false);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(score, pointsGained, frameScores, firstRoll, secondRoll, thirdRoll, rounds);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane(chosenLane);
                    if(chosenLane == 666)
                        goto retryFirst;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins, chosenLane, pinsDown);
                        FirstRoll(score, pinsDown, rounds);
                    }

                    else
                        goto retryFirst;

                    if(pinsDown == 10)
                    {
                        frameScores[rounds] = pinsDown;
                        goto endRound;
                    }

                    // SECOND ROLL
                    retrySecond:
                    Interface(rounds+1, "Second", pins, false);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(score, pointsGained, frameScores, firstRoll, secondRoll, thirdRoll, rounds);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane(chosenLane);
                    if(chosenLane == 666)
                        goto retrySecond;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins, chosenLane, pinsDown);
                        SecondRoll(score, pinsDown, rounds, firstRoll);
                    }

                    else
                        goto retrySecond;

                    Interface(rounds+1, "Second", pins, true);
                    Console.SetCursorPosition(0, 19);
                    frameScores[rounds] = pinsDown;
                    ScoreSheet(score, pointsGained, frameScores, firstRoll, secondRoll, thirdRoll, rounds);

                    endRound:
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(score, pointsGained, frameScores, firstRoll, secondRoll, thirdRoll, rounds);
                    Console.SetCursorPosition(0, 17);
                    Console.Write("Press any key to continue");
                    Console.ReadKey();

                }

                // SPECIAL ROUND
                else
                {
                    char[] pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };
                    pinsDown = 0;

                    // FIRST ROLL
                    retryFirst:
                    Interface(rounds+1, "First", pins, false);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(score, pointsGained, frameScores, firstRoll, secondRoll, thirdRoll, rounds);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane(chosenLane);
                    if(chosenLane == 666)
                        goto retryFirst;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins, chosenLane, pinsDown);
                        FirstRoll(score, pinsDown, rounds);
                    }

                    else
                        goto retryFirst;

                    if(score[9, 0] == "X")
                    {
                        pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };
                        pinsDown = 0;
                    }

                    // SECOND ROLL
                    retrySecond:
                    Interface(rounds+1, "Second", pins, false);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(score, pointsGained, frameScores, firstRoll, secondRoll, thirdRoll, rounds);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane(chosenLane);
                    if(chosenLane == 666)
                        goto retrySecond;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        frameScores[rounds] += pinsDown;
                        Path(pins, chosenLane, pinsDown);
                        SecondRoll(score, pinsDown, rounds, firstRoll);
                        if(score[9, 1] == "/" || score[9, 1] == "X")
                        {
                        }

                        else
                            goto endLastRound;
                    }

                    else
                        goto retrySecond;


                    if(score[9, 0] == "X" || score[9, 1] == "X" || score[9, 1] == "/")
                    {
                        if(score[9, 1] == "X" || score[9, 1] == "/")
                        {
                            pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };
                            pinsDown = 0;
                        }

                        // THIRD ROLL
                        retryThird:
                        Interface(rounds+1, "Third", pins, false);
                        Console.SetCursorPosition(0, 19);
                        frameScores[rounds] += pinsDown;
                        ScoreSheet(score, pointsGained, frameScores, firstRoll, secondRoll, thirdRoll, rounds);
                        Console.SetCursorPosition(0, 17);
                        chosenLane = ChosenLane(chosenLane);
                        if(chosenLane == 666)
                            goto retryThird;

                        else if(0 < chosenLane && chosenLane < 8)
                        {
                            Path(pins, chosenLane, pinsDown);
                            ThirdRoll(score, pinsDown, rounds, firstRoll, secondRoll);
                        }

                        else
                            goto retryThird;
                    }

                    Interface(rounds+1, "Second", pins, true);
                    Console.SetCursorPosition(0, 19);
                    frameScores[rounds] += pinsDown;
                    ScoreSheet(score, pointsGained, frameScores, firstRoll, secondRoll, thirdRoll, rounds);


                    endLastRound:
                    // DISPLAY FINISHED GAME
                    Interface(rounds+1, "Third", pins, true);
                    frameScores[rounds] += pinsDown;
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(score, pointsGained, frameScores, firstRoll, secondRoll, thirdRoll, rounds);

                    Console.SetCursorPosition(0, 17);
                    Console.WriteLine("Press any key to continue\n");



                    Console.WriteLine($"Final score: {totalScore}");
                    Console.SetCursorPosition(0, 17);
                    Console.CursorVisible = false;
                    Console.WriteLine("Press any key to exit    ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}