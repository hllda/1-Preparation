using System;
using System.Text.RegularExpressions;
namespace Day_3_Mission_2_Standard_dice_notation_extraction_the_regex_way
{
    class Program
    {
        static int DiceRoll(int numberRolls,int diceSides,int fixedBonus)
        {
            var random = new Random();
            int roll = 0;
            for(int i = 0; i < numberRolls; i++)
            {
                int rnd = random.Next(1,diceSides + 1);
                roll = roll + rnd;
            }
            int diceRoll = roll + fixedBonus;
            return diceRoll;
        }
        static int DiceRoll(string diceNotation)
        {            
            // INITIATING STANDARD VALUES
            int numberRolls = 1;
            int diceSides = 1;
            int fixedBonus = 0;


            string pattern = "(\\d+)d(\\d+)([+|-]?\\d*)";
            MatchCollection matches = Regex.Matches(diceNotation, pattern);

            Console.WriteLine("Match: {0}, matches.Value");


            return DiceRoll(numberRolls,diceSides,fixedBonus);
        }
        static bool IsStandardDiceNotation(string diceNotation)
        {
            string pattern = "^\\d+d\\d[+|-]*\\d*$";

            if(Regex.IsMatch(diceNotation,pattern))
                return true;

            else
                return false;
        }
        static void Main(string[] args)
        {
            for(int variations = 0; variations < 5; variations++)
            {
                string diceNotation = "";
                if(variations == 0)
                    diceNotation = "2d6";
                if(variations == 1)
                    diceNotation = "d8";
                if(variations == 2)
                    diceNotation = "ad6";
                if(variations == 3)
                    diceNotation = "33d4*2";
                if(variations == 4)
                    diceNotation = "5d6-2";

                // WRITING OUT THE ROLLS
                if(IsStandardDiceNotation(diceNotation) == true)
                {
                    Console.Write($"Throwing {diceNotation}:");

                    for(int total = 0; total < 10; total++)
                    {
                        Console.Write($" {DiceRoll(diceNotation)}");
                    }
                }

                else
                {
                    Console.Write($"Can't throw {diceNotation}, as it is not in standard dice notation.");
                }

                Console.WriteLine($"\n");
            }
        }
    }
}
