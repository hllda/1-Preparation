using System;
namespace Day_2_Mission_1_Full_bowling_score_sheet
{
    class Program
    {
        static int pinsDown;
        static int chosenLane;

        static void Main(string[] args)
        {
            // SAVING THE ROLLS
            int[,] frameScores = new int[10, 3];

            // DISPLAYING THE ROLLS
            string[,] frameScoresDisplay = new string[10, 3];

            // SAVING THE SCORES
            int[] pointsGained = new int[10];

            // DISPLAY THE SCORES
            string[] totalScoreDisplay = new string[10];
            for(int i = 0; i < 10; i++)
                for(int j = 0; j < 3; j++)
                    frameScoresDisplay[i, j] = " ";

            for(int rounds = 0; rounds < 10; rounds++)
            {
                int firstRoll = 0;
                int secondRoll = 0;
                int thirdRoll = 0;
                int pinsDown = 0;


                // NORMAL ROUNDS
                if(rounds < 9)
                {
                    char[] pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };
                    pinsDown = 0;

                    // FIRST ROLL
                    retryFirst:
                    Interface(rounds+1, "First", false, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane();
                    if(chosenLane == 666)
                        goto retryFirst;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins);
                        FirstRoll(rounds, pinsDown, firstRoll, frameScores);
                    }

                    else
                        goto retryFirst;

                    if(pinsDown == 10)
                    {
                        goto endRound;
                    }

                    // SECOND ROLL
                    retrySecond:
                    Interface(rounds+1, "Second", false, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane();
                    if(chosenLane == 666)
                        goto retrySecond;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins);
                        SecondRoll(rounds, pinsDown, firstRoll, secondRoll, frameScores);
                    }

                    else
                        goto retrySecond;

                    Interface(rounds+1, "Second", true, pins);
                    Console.SetCursorPosition(0, 19);
                    frameScores[rounds, 1] = pinsDown;
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);

                    endRound:
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                    Console.SetCursorPosition(0, 16);
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
                    Interface(rounds+1, "First", false, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane();
                    if(chosenLane == 666)
                        goto retryFirst;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins);
                        FirstRoll(rounds, pinsDown, firstRoll, frameScores);
                    }

                    else
                        goto retryFirst;

                    if(frameScores[9, 0] == 10)
                    {
                        pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };
                        pinsDown = 0;
                    }

                    // SECOND ROLL
                    retrySecond:
                    Interface(rounds+1, "Second", false, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane();

                    if(chosenLane == 666)
                        goto retrySecond;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins);
                        SecondRoll(rounds, pinsDown, firstRoll, secondRoll, frameScores);
                    }

                    else
                        goto retrySecond;

                    if(frameScores[9, 0] + frameScores[9, 1] == 10 || frameScores[9, 0] == 10)
                    {
                        if(frameScores[9, 0] + frameScores[9, 1] == 10 || frameScores[9, 0] == 10)
                        {
                            pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };
                            pinsDown = 0;
                        }

                        // THIRD ROLL
                        retryThird:
                        Interface(rounds+1, "Third", false, pins);
                        Console.SetCursorPosition(0, 19);
                        ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                        Console.SetCursorPosition(0, 17);
                        chosenLane = ChosenLane();
                        if(chosenLane == 666)
                            goto retryThird;

                        else if(0 < chosenLane && chosenLane < 8)
                        {
                            Path(pins);
                            ThirdRoll(rounds, pinsDown, firstRoll, secondRoll, thirdRoll, frameScores);
                        }

                        else
                            goto retryThird;
                    }



                    Interface(rounds+1, "Third", false, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);

                    endLastRound:
                    // DISPLAY FINISHED GAME
                    Interface(rounds+1, "Final", true, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);

                    Console.SetCursorPosition(0, 16);
                    Console.WriteLine("Press any key to continue\n");


                    Console.WriteLine($"Final score: {totalScoreDisplay[9]}");
                    Console.SetCursorPosition(0, 16);
                    Console.CursorVisible = false;
                    Console.WriteLine("Press any key to exit    ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void Interface(int rounds, string roll, bool end, char[] pins)
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

        static void DrawPins(char[] pins)
        {
            //DRAW THE STANDING PINS
            Console.WriteLine($"{pins[1]}   {pins[8]}   {pins[0]}   {pins[7]}\n");
            Console.WriteLine($"  {pins[2]}   {pins[9]}   {pins[6]}\n");
            Console.WriteLine($"    {pins[3]}   {pins[5]}\n");
            Console.WriteLine($"      {pins[4]}\n");
        }

        static int ChosenLane()
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

        static void Path(char[] pins)
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
                KnockPinOnPath(pins);
        }

        static void KnockPinOnPath(char[] pins)
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
                    Path(pins);
                }
            }

            else if(chosenLane == 3)
            {
                if(pins[3] == 'O')
                {
                    pins[3] = ' ';
                    pinsDown += 1;
                    Path(pins);
                }

                else if(pins[8] == 'O')
                {
                    pins[8] = ' ';
                    pinsDown += 1;
                    Path(pins);
                }
            }

            else if(chosenLane == 4)
            {
                if(pins[4] == 'O')
                {
                    pins[4] = ' ';
                    pinsDown += 1;
                    Path(pins);
                }

                else if(pins[9] == 'O')
                {
                    pins[9] = ' ';
                    pinsDown += 1;
                    Path(pins);
                }
            }

            else if(chosenLane == 5)
            {
                if(pins[5] == 'O')
                {
                    pins[5] = ' ';
                    pinsDown += 1;
                    Path(pins);
                }

                else if(pins[0] == 'O')
                {
                    pins[0] = ' ';
                    pinsDown += 1;
                    Path(pins);
                }
            }

            else if(chosenLane == 6)
            {
                if(pins[6] == 'O')
                {
                    pins[6] = ' ';
                    pinsDown += 1;
                    Path(pins);
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

        static void FirstRoll(int rounds, int pinsDown, int firstRoll, int[,] frameScores)
        {
            firstRoll = pinsDown;
            frameScores[rounds, 0] = firstRoll;
        }

        static void SecondRoll(int rounds, int pinsDown, int firstRoll, int secondRoll, int[,] frameScores)
        {
            if(rounds != 9)
            {
                secondRoll = pinsDown - firstRoll;
            }

            else
            {
                if(frameScores[9, 0] == 10)
                {
                    secondRoll = pinsDown;
                }

                else
                {
                    secondRoll = pinsDown - firstRoll;
                }
            }
            frameScores[rounds, 1] = secondRoll;
        }

        static void ThirdRoll(int rounds, int pinsDown, int firstRoll, int secondRoll, int thirdRoll, int[,] frameScores)
        {
            if(frameScores[9, 1] == 10 || frameScores[9, 0] + frameScores[9, 1] == 10)
            {
                thirdRoll = pinsDown;
            }

            else if(frameScores[9, 0] == 10)
            {
                thirdRoll = pinsDown - secondRoll;
            }

            frameScores[rounds, 2] = thirdRoll;
        }

        static void Scoring(int rounds, int[,] frameScores, string[,] frameScoresDisplay, int[] pointsGained, string[] totalScoreDisplay)
        {
            if(rounds != 9)
            {
                if(frameScores[rounds, 0] == 10)
                {
                    frameScoresDisplay[rounds, 0] = "X";
                }

                else if(frameScores[rounds, 0] == 0)
                {
                    frameScoresDisplay[rounds, 0] = "-";
                }

                else
                {
                    frameScoresDisplay[9, 0] = frameScores[9, 0].ToString();
                }


                if(frameScores[9, 0] + frameScores[rounds, 1] == 10)
                {
                    frameScoresDisplay[rounds, 1] = "/";
                }

                else if(frameScores[rounds, 1] == 0)
                {
                    frameScoresDisplay[rounds, 1] = "-";
                }

                else
                {
                    frameScoresDisplay[rounds, 1] = frameScores[rounds, 1].ToString();
                }
            }

            else
            {
                if(frameScores[9, 0] == 10)
                {
                    frameScoresDisplay[9, 0] = "X";
                }

                else if(frameScores[9, 0] == 0)
                {
                    frameScoresDisplay[9, 0] = "-";
                }

                else
                {
                    frameScoresDisplay[9, 0] = frameScores[9, 0].ToString();
                }

                if(frameScores[9, 0] == 10 && frameScores[9, 1] == 10)
                {
                    frameScoresDisplay[9, 1] = "X";
                }

                else if(frameScores[9, 0] + frameScores[9, 1] == 10)
                {
                    frameScoresDisplay[9, 1] = "/";
                }

                else if(frameScores[9, 1] == 0)
                {
                    frameScoresDisplay[9, 1] = "-";
                }

                else
                {
                    frameScoresDisplay[9, 1] = frameScores[9, 1].ToString();
                }

                if(frameScores[9, 0] == 10 && frameScores[9, 1] == 10 && frameScores[9, 2] == 10)
                {
                    frameScoresDisplay[9, 2] = "X";
                }

                else if(frameScores[9, 0] == 10 && frameScores[9, 1] != 10 && frameScores[9, 1] + frameScores[9, 2] == 10)
                {
                    frameScoresDisplay[9, 2] = "/";
                }

                else
                {
                    frameScoresDisplay[9, 2] = frameScores[9, 2].ToString();
                }
            }


            try
            {
                for(int i = 0; i < 10; i++)
                {
                    if(rounds != 9)
                    {
                         if(frameScores[i, 0] == 10 || frameScores[i, 0] + frameScores[i, 1] == 10)
                            try
                            {
                                if(frameScores[i, 0] == 10)
                                {
                                    pointsGained[i] += frameScores[i] + frameScores[i+1] + frameScores[i+2];
                                }

                                else if(frameScores[i, 0] + frameScores[i, 1] == 10)
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
                       
                }












            }


            catch { }
        }

        static void ScoreSheet(int rounds, int[,] frameScores, string[,] frameScoresDisplay, int[] pointsGained, string[] totalScoreDisplay)
        {
            Scoring(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
            const int alignment = 5;
            const int alignmentLast = 7;
            Console.WriteLine($"\n" +
                $"┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐");
            Console.WriteLine(
                $"│ │{frameScoresDisplay[0, 0]}│{frameScoresDisplay[0, 1]}│ │{frameScoresDisplay[1, 0]}│{frameScoresDisplay[1, 1]}│ │{frameScoresDisplay[2, 0]}│{frameScoresDisplay[2, 1]}" +
                $"│ │{frameScoresDisplay[3, 0]}│{frameScoresDisplay[3, 1]}│ │{frameScoresDisplay[4, 0]}│{frameScoresDisplay[4, 1]}│ │{frameScoresDisplay[5, 0]}│{frameScoresDisplay[5, 1]}" +
                $"│ │{frameScoresDisplay[6, 0]}│{frameScoresDisplay[6, 1]}│ │{frameScoresDisplay[7, 0]}│{frameScoresDisplay[7, 1]}│ │{frameScoresDisplay[8, 0]}│{frameScoresDisplay[8, 1]}" +
                $"│ │{frameScoresDisplay[9, 0]}│{frameScoresDisplay[9, 1]}│{frameScoresDisplay[9, 2]}│");
            Console.WriteLine(
                $"│ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┴─┤");
            Console.WriteLine(
                $"│{totalScoreDisplay[0],alignment}│{totalScoreDisplay[1],alignment}│{totalScoreDisplay[2],alignment}" +
                $"│{totalScoreDisplay[3],alignment}│{totalScoreDisplay[4],alignment}│{totalScoreDisplay[5],alignment}" +
                $"│{totalScoreDisplay[6],alignment}│{totalScoreDisplay[7],alignment}│{totalScoreDisplay[8],alignment}" +
                $"│{totalScoreDisplay[9],alignmentLast}│");
            Console.Write(
                $"└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴───────┘");
        }
    }
}
