using System;
namespace Day_4_Mission_4_Standard_dice_notation_detector
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
            // SPLITS THE STRING
            string[] notations = diceNotation.Split('d','+','-');

            // INITIATING STANDARD VALUES
            int numberRolls = 1;
            int diceSides = Int32.Parse(notations[1]);
            int fixedBonus = 0;

            // CHECK IF ONE ROLL
            if(!diceNotation.StartsWith("d"))
                numberRolls = Int32.Parse(notations[0]);

            // CHECK IF STATIC BONUS
            if(diceNotation.Contains("+"))
            {
                fixedBonus = +Int32.Parse(notations[2]);
            }

            else if(diceNotation.Contains("-"))
            {
                fixedBonus = -Int32.Parse(notations[2]);
            }

            return DiceRoll(numberRolls,diceSides,fixedBonus);
        }

        static bool IsStandardDiceNotation(string diceNotation)
        {
            for(int i = 0; i < 255; i++)
            {
                if(i == 43)
                    i = 44;

                if(i == 45)
                    i = 46;

                if(i == 48)
                    i = 58;

                if(i == 100)
                    i = 101;

                if(diceNotation.Contains((char)i))
                    return false;
            }

            if(!diceNotation.Contains("d"))
            {
                return false;
            }

            if(diceNotation.EndsWith("d"))
            {
                return false;
            }

            if(diceNotation.Contains("d+") || diceNotation.Contains("d-"))
            {
                return false;
            }

            return true;
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
