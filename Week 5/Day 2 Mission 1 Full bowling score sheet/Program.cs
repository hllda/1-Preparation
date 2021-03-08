using System;
namespace Day_2_Mission_1_Full_bowling_score_sheet
{
    class Program
    {
        static int pinsDown;
        static int chosenLane;
        static int firstRoll;
        static int secondRoll;
        static int thirdRoll;
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

            // THE ROUNDS
            for(int rounds = 0; rounds < 10; rounds++)
            {
                // RESET ROLLS AND PINS TO ZERO
                firstRoll = 0;
                secondRoll = 0;
                thirdRoll = 0;
                pinsDown = 0;

                // NORMAL ROUNDS
                if(rounds != 9)
                {
                    char[] pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };

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
                        for(int i = 0; i < 1000000; i++)
                            KnockPinOnPath(pins, chosenLane);
                        FirstRoll(rounds, frameScores, frameScoresDisplay);
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
                        for(int i = 0; i < 1000000; i++)
                            KnockPinOnPath(pins, chosenLane);
                        SecondRoll(rounds, frameScores, frameScoresDisplay);
                    }

                    else
                        goto retrySecond;

                    Interface(rounds+1, "Second", true, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                    // DISPLAY SCORES
                    endRound:
                    Console.SetCursorPosition(0, 19);
                    Scoring(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                    ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                    Console.SetCursorPosition(0, 16);
                    Console.Write("                                                ");
                    Console.SetCursorPosition(0, 16);
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                }

                // SPECIAL ROUND
                else
                {
                    char[] pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };

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
                        for(int i = 0; i < 1000000; i++)
                            KnockPinOnPath(pins, chosenLane);
                        FirstRoll(rounds, frameScores, frameScoresDisplay);
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
                        for(int i = 0; i < 1000000; i++)
                            KnockPinOnPath(pins, chosenLane);
                        SecondRoll(rounds, frameScores, frameScoresDisplay);
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
                            for(int i = 0; i < 1000000; i++)
                                KnockPinOnPath(pins, chosenLane);
                            ThirdRoll(rounds, frameScores, frameScoresDisplay);
                        }

                        else
                            goto retryThird;


                        Interface(rounds+1, "Third", false, pins);
                        Console.SetCursorPosition(0, 19);
                        Scoring(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                        ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);

                    }

                    else
                    {
                        Interface(rounds+1, "Second", true, pins);
                        Console.SetCursorPosition(0, 19);
                        Scoring(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                        ScoreSheet(rounds, frameScores, frameScoresDisplay, pointsGained, totalScoreDisplay);
                    }

                    Console.SetCursorPosition(0, 16);
                    Console.Write("                                                ");
                    Console.SetCursorPosition(0, 16);
                    Console.Write("Press any key to continue");
                    Console.WriteLine($"Final score: {totalScoreDisplay[9]}");
                    Console.SetCursorPosition(0, 16);
                    Console.CursorVisible = false;
                                        Console.SetCursorPosition(0, 16);
                    Console.Write("                                                ");
                    Console.SetCursorPosition(0, 16);
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // THE INTERFACE FOR THE GAME
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

        // DRAWING THE PINS THAT ARE STILL STANDING
        static void DrawPins(char[] pins)
        {
            //DRAW THE STANDING PINS
            Console.WriteLine($"{pins[1]}   {pins[8]}   {pins[0]}   {pins[7]}\n");
            Console.WriteLine($"  {pins[2]}   {pins[9]}   {pins[6]}\n");
            Console.WriteLine($"    {pins[3]}   {pins[5]}\n");
            Console.WriteLine($"      {pins[4]}\n");
        }

        // THE PLAYER CHOSE THEIR LANE TO ROLL THE BALL
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

        // THE BALL ROLLS WITH A 33% CHANCE OF CHANGING DIRECTION TO LEFT OR RIGHT
        static void KnockPinOnPath(char[] pins, int chosenLane)
        {
            var Random = new Random();
            int path = Random.Next(0, 3);

            if(path == 0)
            {
                chosenLane++;
            }

            if(path == 1)
            {
                chosenLane--;
            }


            if(chosenLane == 1)
            {
                if(pins[1] == 'O')
                {
                    pins[1] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }
            }

            else if(chosenLane == 2)
            {
                if(pins[2] == 'O')
                {
                    pins[2] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }
            }

            else if(chosenLane == 3)
            {
                if(pins[3] == 'O')
                {
                    pins[3] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }

                else if(pins[8] == 'O')
                {
                    pins[8] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }
            }

            else if(chosenLane == 4)
            {
                if(pins[4] == 'O')
                {
                    pins[4] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }

                else if(pins[9] == 'O')
                {
                    pins[9] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }
            }

            else if(chosenLane == 5)
            {
                if(pins[5] == 'O')
                {
                    pins[5] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }

                else if(pins[0] == 'O')
                {
                    pins[0] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }
            }

            else if(chosenLane == 6)
            {
                if(pins[6] == 'O')
                {
                    pins[6] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }
            }

            else if(chosenLane == 7)
            {
                if(pins[7] == 'O')
                {
                    pins[7] = ' ';
                    pinsDown += 1;
                    KnockPinOnPath(pins, chosenLane);
                }
            }
        }

        // THE FIRST ROLL OF THE ROUND AND DECIDING WHAT CHARACTHER SHOULD BE DRAWN
        static void FirstRoll(int rounds, int[,] frameScores, string[,] frameScoresDisplay)
        {
            firstRoll = pinsDown;
            frameScores[rounds, 0] = firstRoll;

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
                    frameScoresDisplay[rounds, 0] = frameScores[rounds, 0].ToString();
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
            }
        }

        // THE POSSIBLE SECOND ROLL OF THE ROUND AND DECIDING WHAT CHARACTHER SHOULD BE DRAWN
        static void SecondRoll(int rounds, int[,] frameScores, string[,] frameScoresDisplay)
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

            if(rounds != 9)
            {
                if(frameScores[rounds, 0] + frameScores[rounds, 1] == 10)
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
            }
        }

        // THE LAST ROUNDS POSSIBLE THIRD ROLL AND DECIDING WHAT CHARACTHER SHOULD BE DRAWN
        static void ThirdRoll(int rounds, int[,] frameScores, string[,] frameScoresDisplay)
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

        // DRAWING THE SCORESHEET
        static void ScoreSheet(int rounds, int[,] frameScores, string[,] frameScoresDisplay, int[] pointsGained, string[] totalScoreDisplay)
        {
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

        // CALCULATING THE ADDED SCORE OF THE ROLLS EACH ROUND
        static void Scoring(int rounds, int[,] frameScores, string[,] frameScoresDisplay, int[] pointsGained, string[] totalScoreDisplay)
        {
            for(int i = 0; i < rounds+1; i++)
            {
                if(i != 9)
                {
                    if(frameScores[i, 0] == 10)
                        try
                        {
                            if(frameScores[i, 0] == 10 && frameScores[i+1, 0] == 10)
                                pointsGained[i] = frameScores[i, 0] + pointsGained[i+1] + frameScores[i+2, 0];

                            else
                                pointsGained[i] = frameScores[i, 0] + pointsGained[i+1];
                        }
                        catch { }

                    else if(frameScores[i, 0] + frameScores[i, 1] == 10)
                        try
                        {
                            pointsGained[i] = frameScores[i, 0] + frameScores[i, 1] + frameScores[i+1, 0];
                        }
                        catch { }

                    else
                    {
                        pointsGained[i] = frameScores[i, 0] + frameScores[i, 1];
                    }
                }

                else
                {
                    pointsGained[9] = frameScores[9, 0] + frameScores[9, 1] + frameScores[9, 2];
                }


            }

            try
            {
                if(frameScores[rounds, 0] != 10 && frameScores[rounds, 0] + frameScores[rounds, 1] != 10 && pointsGained[rounds] != 0)
                {
                    totalScoreDisplay[rounds] = (pointsGained[0] + pointsGained[1] + pointsGained[2] + pointsGained[3] + pointsGained[4] + pointsGained[5] + pointsGained[6] + pointsGained[7] + pointsGained[8] + pointsGained[9]).ToString();
                }

                else if(frameScores[rounds-1, 0] == 10 || frameScores[rounds-1, 0] + frameScores[rounds-1, 1] == 10)
                {
                    totalScoreDisplay[rounds-1] = (pointsGained[0] + pointsGained[1] + pointsGained[2] + pointsGained[3] + pointsGained[4] + pointsGained[5] + pointsGained[6] + pointsGained[7] + pointsGained[8] + pointsGained[9] - pointsGained[rounds]).ToString();
                }
            }
            catch
            {
            }
        }
    }
}
