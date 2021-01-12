using System;
using System.Collections.Generic;

namespace Day_2_Mission_1_Full_bowling_score_sheet
{
    class Program
    {
        static void FirstRoll(string[,] score, int pinsDown, int rounds, int firstRoll, List<int> standingPins)
        {
            firstRoll = pinsDown;
            if(standingPins.Count == 0)
                score[rounds, 0] = "X";

            else if(standingPins.Count == 10)
                score[rounds, 0] = "-";

            else
                score[rounds, 0] = (10 - standingPins.Count).ToString();




        }

        static void SecondRoll(string[,] score, int pinsDown, int rounds, int firstRoll, int secondRoll, List<int> standingPins, List<int> standingPinsCopy)
        {
            secondRoll = firstRoll - pinsDown;
            if(standingPins.Count == 0)
                score[rounds, 1] = "/";

            else if(standingPins.Count == standingPinsCopy.Count)
                score[rounds, 1] = "-";

            else
                score[rounds, 1] = (secondRoll).ToString();
        }

        static void ScoreSheet(string[,] score)
        {
            Console.WriteLine();
            Console.WriteLine($"┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐");

            Console.WriteLine($"│ │{score[0, 0]}│{score[0, 1]}│ │{score[1, 0]}│{score[1, 1]}│ │{score[2, 0]}│{score[2, 1]}" +
                              $"│ │{score[3, 0]}│{score[3, 1]}│ │{score[4, 0]}│{score[4, 1]}│ │{score[5, 0]}│{score[5, 1]}" +
                              $"│ │{score[6, 0]}│{score[6, 1]}│ │{score[7, 0]}│{score[7, 1]}│ │{score[8, 0]}│{score[8, 1]}" +
                              $"│ │{score[9, 0]}│{score[9, 1]}│{score[9, 2]}│");

            Console.WriteLine("│ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┤ └─┴─┴─┤");
            Console.WriteLine("│     │     │     │     │     │     │     │     │     │       │");
            Console.Write("└─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴───────┘");
        }

        static void KnockPinOnPath(char[] pins, int chosenLane, int pinsDown, List<int> standingPins)
        {
            if(chosenLane == 1)
            {
                pins[1] = ' ';
                standingPins.Remove(1);
            }

            if(chosenLane == 2)
            {
                if(pins[2] == 'O')
                {
                    pins[2] = ' ';
                    standingPins.Remove(2);
                    Path(pins, chosenLane, pinsDown, standingPins);
                }
            }

            if(chosenLane == 3)
            {
                if(pins[3] == 'O')
                {
                    pins[3] = ' ';
                    standingPins.Remove(3);
                    Path(pins, chosenLane, pinsDown, standingPins);
                }

                else if(pins[8] == 'O')
                {
                    pins[8] = ' ';
                    standingPins.Remove(8);
                    Path(pins, chosenLane, pinsDown, standingPins);
                }
            }

            if(chosenLane == 4)
            {
                if(pins[4] == 'O')
                {
                    pins[4] = ' ';
                    standingPins.Remove(4);
                    Path(pins, chosenLane, pinsDown, standingPins);
                }

                else if(pins[9] == 'O')
                {
                    pins[9] = ' ';
                    standingPins.Remove(9);
                    Path(pins, chosenLane, pinsDown, standingPins);
                }
            }

            if(chosenLane == 5)
            {
                if(pins[5] == 'O')
                {
                    pins[5] = ' ';
                    standingPins.Remove(5);
                    Path(pins, chosenLane, pinsDown, standingPins);
                }

                else if(pins[0] == 'O')
                {
                    pins[0] = ' ';
                    standingPins.Remove(0);
                    Path(pins, chosenLane, pinsDown, standingPins);
                }
            }

            if(chosenLane == 6)
            {
                if(pins[6] == 'O')
                {
                    pins[6] = ' ';
                    standingPins.Remove(6);
                    Path(pins, chosenLane, pinsDown, standingPins);
                }
            }

            if(chosenLane == 7)
            {
                pins[7] = ' ';
                standingPins.Remove(7);
            }
        }

        static void Path(char[] pins, int chosenLane, int pinsDown, List<int> standingPins)
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

            KnockPinOnPath(pins, chosenLane, pinsDown, standingPins);
        }

        static int ChosenLane(int chosenLane)
        {
            // CHECK IF THE ENTERED NUMBER IS VALID
            Console.CursorVisible = true;
            try
            {
                chosenLane = Int32.Parse(Console.ReadLine());
            }

            catch
            {
                Console.WriteLine("You have to enter a number.\nPress any key to try again.");
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
            List<int> standingPins = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            char[] pinsNew = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };
            int chosenLane = 666;
            int firstRoll = 0;
            int secondRoll = 0;
            string[,] score = new string[10, 3];
            int pinsDown;
            for(int y = 0; y < 10; y++)
                for(int x = 0; x < 3; x++)
                    score[y, x] = " ";

            int[] totalScore = new int[] { };


            for(int rounds = 0; rounds < 10; rounds++)
            {
                pinsDown = 0;
                if(rounds < 9)
                {

                    int roll = 1;
                    char[] pins = new char[10] { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };

                    retryFirst:
                    Interface(rounds+1, "First", pins, false);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(score);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane(chosenLane);
                    if(chosenLane == 666)
                        goto retryFirst;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins, chosenLane, pinsDown, standingPins);
                        FirstRoll(score, pinsDown, rounds, firstRoll, standingPins);
                    }

                    else
                        goto retryFirst;

                    List<int> standingPinsCopy = new List<int>(standingPins);
                    roll++;
                    retrySecond:
                    Interface(rounds+1, "Second", pins, false);
                    Console.SetCursorPosition(0, 19);
                    ScoreSheet(score);
                    Console.SetCursorPosition(0, 17);
                    chosenLane = ChosenLane(chosenLane);
                    if(chosenLane == 666)
                        goto retrySecond;

                    else if(0 < chosenLane && chosenLane < 8)
                    {
                        Path(pins, chosenLane, pinsDown, standingPins);
                        SecondRoll(score, pinsDown, rounds, firstRoll, secondRoll, standingPins, standingPinsCopy);
                    }

                    else
                        goto retrySecond;

                    Interface(rounds+1, "Second", pins, true);
                    Console.SetCursorPosition(0, 19);

                    ScoreSheet(score);
                    Console.SetCursorPosition(0, 17);


                    {
                        Console.SetCursorPosition(0, 16);
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                    }




                }


                else
                {
                    /*

     if(rounds == 10)
     {
         roll++;
         retryThird:
         Interface(rounds, "Third", pins, false);
         Console.SetCursorPosition(0, 19);
         ScoreSheet(score);
         Console.SetCursorPosition(0, 17);
         chosenLane = ChosenLane(chosenLane);
         if(chosenLane == 666)
             goto retryThird;

         else if(0 < chosenLane && chosenLane < 8)
             Path(pins, chosenLane, pinsLeft);

         else
             goto retryThird;
     }
     */
                    // else



                }

















            }















        }
    }
}


