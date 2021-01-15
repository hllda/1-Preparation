using System;
namespace Day_2_Mission_1_Full_bowling_score_sheet
{
    class Program
    {
        // ROUNDS
        static int rounds;

        // PINS
        static int chosenLane;
        static int pinsDown;

        // ROLLS
        static int firstRoll;
        static int secondRoll;
        static int thirdRoll;

        // SAVING THE ROLLS
        static int[,] frameScores = new int[10, 3];

        // DISPLAYING THE ROLLS
        static string[,] frameScoresDisplay = new string[10, 3];

        // TOTAL SCORES
        static int[] pointsGained = new int[10];
        static string[] totalScore = new string[10];


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
                    Interface(rounds, "ROLL", false, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet();
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane();
                    if(chosenLane == 666)
                        goto retryFirst;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins);
                        FirstRoll();
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
                    Interface(rounds, "ROLL", false, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet();
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane();
                    if(chosenLane == 666)
                        goto retrySecond;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins);
                        SecondRoll();
                    }

                    else
                        goto retrySecond;

                    Interface(rounds, "ROLL", true, pins);
                    Console.SetCursorPosition(0, 19);
                    frameScores[rounds] = pinsDown;
                    ScoreSheet();

                    endRound:
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet();
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
                    Interface(rounds, "ROLL", false, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet();
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane();
                    if(chosenLane == 666)
                        goto retryFirst;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins);
                        FirstRoll();
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
                    Interface(rounds, "ROLL", false, pins);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet();
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane();
                    if(chosenLane == 666)
                        goto retrySecond;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        frameScores[rounds] += pinsDown;
                        Path(pins);
                        SecondRoll();
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
                        Interface(rounds, "ROLL", false, pins);
                        Console.SetCursorPosition(0, 19);
                        frameScores[rounds] += pinsDown;
                        ScoreSheet();
                        Console.SetCursorPosition(0, 17);
                        chosenLane = ChosenLane();
                        if(chosenLane == 666)
                            goto retryThird;

                        else if(0 < chosenLane && chosenLane < 8)
                        {
                            Path(pins);
                            ThirdRoll();
                        }

                        else
                            goto retryThird;
                    }

                    Interface(rounds, "ROLL", false, pins);
                    Console.SetCursorPosition(0, 19);
                    frameScores[rounds] += pinsDown;
                    ScoreSheet();


                    endLastRound:
                    // DISPLAY FINISHED GAME
                    Interface(rounds, "ROLL", true, pins);
                    frameScores[rounds] += pinsDown;
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet();

                    Console.SetCursorPosition(0, 17);
                    Console.WriteLine("Press any key to continue\n");



                    Console.WriteLine($"Final score: {totalScore}");
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

        //___________//

        static void FirstRoll()
        {

        }

        static void SecondRoll()
        {

        }

        static void ThirdRoll()
        {

        }

        static void Scoring()
        {

        }

        static void ScoreSheet()
        {
            Scoring();
            const int alignment = 5;
            const int alignmentLast = 7;
            Console.WriteLine($"\n" +
                $"┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐");
            Console.WriteLine(
                $"│ │{frameScores[0, 0]}│{frameScores[0, 1]}│ │{frameScores[1, 0]}│{frameScores[1, 1]}│ │{frameScores[2, 0]}│{frameScores[2, 1]}" +
                $"│ │{frameScores[3, 0]}│{frameScores[3, 1]}│ │{frameScores[4, 0]}│{frameScores[4, 1]}│ │{frameScores[5, 0]}│{frameScores[5, 1]}" +
                $"│ │{frameScores[6, 0]}│{frameScores[6, 1]}│ │{frameScores[7, 0]}│{frameScores[7, 1]}│ │{frameScores[8, 0]}│{frameScores[8, 1]}" +
                $"│ │{frameScores[9, 0]}│{frameScores[9, 1]}│{frameScores[9, 2]}│");
            Console.WriteLine(
                $"│ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┴─┤");
            Console.WriteLine(
                $"│{totalScore[0],alignment}│{totalScore[1],alignment}│{totalScore[2],alignment}" +
                $"│{totalScore[3],alignment}│{totalScore[4],alignment}│{totalScore[5],alignment}" +
                $"│{totalScore[6],alignment}│{totalScore[7],alignment}│{totalScore[8],alignment}" +
                $"│{totalScore[9],alignmentLast}│");
            Console.Write(
                $"└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴───────┘");
        }
    }
}
