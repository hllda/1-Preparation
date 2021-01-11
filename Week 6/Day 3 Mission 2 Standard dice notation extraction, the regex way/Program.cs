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

            string pattern = @"^([1-9]|\d\d)?d(\d+)([+|-]*\d*)$";
            Match matches = Regex.Match(diceNotation,pattern);

            try
            {
                numberRolls = Int32.Parse(matches.Groups[1].ToString());
            }catch{}

            try
            {
                diceSides = Int32.Parse(matches.Groups[2].ToString());
            }catch{}

            try
            {
                fixedBonus = Int32.Parse(matches.Groups[3].ToString());
            }catch{}

            return DiceRoll(numberRolls, diceSides, fixedBonus);
        }

        static bool IsStandardDiceNotation(string diceNotation)
        {
            string pattern = @"^([1-9]|\d\d)?d(\d+)([+|-]*\d*)$";

            if(Regex.IsMatch(diceNotation,pattern))
                return true;

            else
                return false;
        }

        static void Throwing(string diceNotation)
        {

            if(IsStandardDiceNotation(diceNotation) == true)
            {
                DiceRoll(diceNotation);

                Console.WriteLine($"Throwing {diceNotation}:");

                for(int total = 0; total < 10; total++)
                {
                    Console.Write($"{DiceRoll(diceNotation)} ");
                }
            }

            else
            {
                Console.Write($"Can't throw {diceNotation}; as it is not in standard dice notation.");
            }

            Console.WriteLine($"\n");
        }

        static void Main(string[] args)
        {
            Throwing("2d6");
            Throwing("d6");
            Throwing("d6+5");
            Throwing("5d6+5");
            Throwing("2d10-5");
            Throwing("d6+5");

            Throwing("36");
            Throwing("-12");
            Throwing("ad6");
            Throwing("-3d6");
            Throwing("0d6");
            Throwing("d+");
            Throwing("2d-4");
            Throwing("2d2.5");
            Throwing("2d$");
        }
    }
}
