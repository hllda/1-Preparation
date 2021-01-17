using System;
using System.Text.RegularExpressions;
namespace Day_2_Mission_1_Dice_simulator_tool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string options = "";
            string diceNotation = "";

            do
            {
                retry:
                Console.WriteLine("DICE SIMULATOR\n");

                Console.WriteLine("Enter dice roll in standard dice notation:");
                if(options != "r")
                    diceNotation = Console.ReadLine();
                Console.WriteLine();

                if(IsStandardDiceNotation(diceNotation) == true)
                {
                    Console.WriteLine($"Simulating...\n");
                    Console.Write($"\nYou rolled: {DiceRoll(diceNotation)}");
                }

                else
                {
                    Console.WriteLine($"{diceNotation} is not in standard dice notation.");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    goto retry;
                }

                Console.WriteLine($"\n");
                Console.WriteLine("Do you want to (r)epeat, enter a (n)ew roll, or (q)uit?");
                options = Console.ReadLine().ToLower();

                if(options != "r" && options != "n")
                {
                    break;
                }
                Console.Clear();
            } while(options != "q"); 
        }

        static bool IsStandardDiceNotation(string diceNotation)
        {
            string pattern = @"^([1-9]|\d\d)?d(\d+)([+|-]*\d*)$";

            if(Regex.IsMatch(diceNotation, pattern))
                return true;

            else
                return false;
        }

        static int DiceRoll(string diceNotation)
        {
            // INITIATING STANDARD VALUES
            int numberRolls = 1;
            int diceSides = 1;
            int fixedBonus = 0;

            string pattern = @"^([1-9]|\d\d)?d(\d+)([+|-]*\d*)$";
            Match matches = Regex.Match(diceNotation, pattern);

            try
            {
                numberRolls = Int32.Parse(matches.Groups[1].ToString());
            }
            catch { }

            try
            {
                diceSides = Int32.Parse(matches.Groups[2].ToString());
            }
            catch { }

            try
            {
                fixedBonus = Int32.Parse(matches.Groups[3].ToString());
            }
            catch { }

            return DiceRoll(numberRolls, diceSides, fixedBonus);
        }

        static int DiceRoll(int numberRolls, int diceSides, int fixedBonus)
        {
            var random = new Random();
            int roll = 0;
            for(int i = 0; i < numberRolls; i++)
            {
                int rnd = random.Next(1, diceSides + 1);
                roll += rnd;
                Console.WriteLine(Art(numberRolls, diceSides, fixedBonus, rnd, i));
            }
            Console.ForegroundColor = ConsoleColor.White;
            int diceRoll = roll + fixedBonus;
            return diceRoll;
        }

        static string OrdinalNumber(int x)
        {
            int y = x % 10;
            if(x < 10)
            {
                if(y == 1)
                {
                    return "st";
                }

                else if(y == 2)
                {
                    return "nd";
                }

                else if(y == 3)
                {
                    return "rd";
                }

                else
                {
                    return "th";
                }
            }

            else
            {
                int z = (x / 10) % 10;
                if(z == 1)
                {
                    return "th";
                }

                else
                {
                    if(y == 1)
                    {
                        return "st";
                    }

                    else if(y == 2)
                    {
                        return "nd";
                    }

                    else if(y == 3)
                    {
                        return "rd";
                    }

                    else
                    {
                        return "th";
                    }
                }
            }
        }

        static string Art(int numberRolls, int diceSides, int fixedBonus, int rnd, int i)
        {
            {
                // TWO SIDED DICE, AKA COIN TOSS
                if(diceSides == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    const int align2 = 3;
                    return
                        $"\n  ___" +
                        $"\n /   \\" +
                        $"\n|{rnd,align2}  |" +
                        $"\n \\___/";
                }

                // FOUR SIDED DICE
                else if(diceSides == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    const int align4 = -2;
                    return
                           $"\n  /\\." +
                           $"\n /{rnd,align4}\\'." +
                           $"\n/____\\/ \n";
                }

                // SIX SIDED STANDARD DICE
                else if(diceSides == 6)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if(rnd == 1)
                        return
                            $"\n┌───────┐" +
                            $"\n│       │" +
                            $"\n│   O   │" +
                            $"\n│       │" +
                            $"\n└───────┘";

                    if(rnd == 2)
                        return
                            $"\n┌───────┐" +
                            $"\n│ O     │" +
                            $"\n│       │" +
                            $"\n│     O │" +
                            $"\n└───────┘";

                    if(rnd == 3)
                        return
                            $"\n┌───────┐" +
                            $"\n│ O     │" +
                            $"\n│   O   │" +
                            $"\n│     O │" +
                            $"\n└───────┘";

                    if(rnd == 4)
                        return
                            $"\n┌───────┐" +
                            $"\n│ O   O │" +
                            $"\n│       │" +
                            $"\n│ O   O │" +
                            $"\n└───────┘";

                    if(rnd == 5)
                        return
                            $"\n┌───────┐" +
                            $"\n│ O   O │" +
                            $"\n│   O   │" +
                            $"\n│ O   O │" +
                            $"\n└───────┘";

                    else
                        return
                            $"\n┌───────┐" +
                            $"\n│ O   O │" +
                            $"\n│ O   O │" +
                            $"\n│ O   O │" +
                            $"\n└───────┘";
                }

                // EIGHT SIDED DICE
                else if(diceSides == 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    const int align8 = -2;
                    return
                    $"\n   /\\." +
                    $"\n  /  \\'." +
                    $"\n / {rnd,align8} \\ '." +
                    $"\n/______\\'/" +
                    $"\n'.     // " +
                    $"\n  '.  /'" +
                    $"\n    '/";
                }

                // TEN SIDED DICE
                else if(diceSides == 10)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    const int align10 = 3;
                    return
                    $"\n      ." +
                    $"\n     / \\  " +
                    $"\n   ./   \\. " +
                    $"\n  // {rnd,align10} \\\\" +
                    $"\n /.^.___.^.\\" +
                    $"\n '.   |   .'" +
                    $"\n   '. | .'      "+
                    $"\n     '.'        ";
                }

                // TWELVE SIDED DICE
                else if(diceSides == 12)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    const int align12 = 2;
                    return
                    $"\n     ____" +
                    $"\n   .'  | '." +
                    $"\n  /'. _| .'\\" +
                    $"\n  |  /{rnd,align12}\\  |" +
                    $"\n  \\ /\\__/\\ /" +
                    $"\n   '.____.'";
                }

                // TWENTY SIDED DICE
                else if(diceSides == 20)
                {                  
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    const int align20 = 2;
                    return
                    $"\n     _____    " +
                    $"\n   .'  |  '." +
                    $"\n  /__ /\\ ___\\     " +
                    $"\n |   /{rnd,align20}\\    | " +
                    $"\n |'./____\\ .'| " +
                    $"\n  \\/ \\  / \\ /       " +
                    $"\n   '._\\/__.'          ";
                }

                // THE DICE NOTATIONS THAT DO NOT HAVE ART MADE
                else
                {
                    return $"{i+1}{OrdinalNumber(i+1)} roll: {rnd}";
                }
            }
        }
    }
}
