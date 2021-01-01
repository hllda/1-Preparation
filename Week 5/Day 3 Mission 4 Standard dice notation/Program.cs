using System;

namespace Day_3_Mission_4_Standard_dice_notation
{
    class Program
    {
        static int DiceRoll(int numberRolls,int diceSides,int fixedBonus = 0)
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
            int numberRolls;
            int diceSides;
            int fixedBonus = 0;

            if(diceNotation.Contains("+"))
            {
                numberRolls = Int32.Parse($"{diceNotation[0]}");
                diceSides = Int32.Parse($"{diceNotation[2]}");
                fixedBonus = Int32.Parse($"{diceNotation[4]}");
            }

            else
            {
                numberRolls = Int32.Parse($"{diceNotation[0]}");
                diceSides = Int32.Parse($"{diceNotation[2]}");
            }

            return DiceRoll(numberRolls,diceSides,fixedBonus);
        }
        static void Main(string[] args)
        {
            // GENERATING A DICE STRING WITH RANDOM VALUES AND 50/50 OF ADDING A FIXED BONUS
            for(int variations = 0; variations < 5; variations++)
            {
                var Random = new Random();
                int diceSides = Random.Next(1,10);
                int numberOfRolls = Random.Next(1,10);
                int bonusOdds = Random.Next(0,2);
                string diceNotation;

                if(bonusOdds != 0)
                {
                    diceNotation = $"{numberOfRolls}d{diceSides}";
                }

                else
                {
                    int fixedBonus = Random.Next(1,10);
                    diceNotation = $"{numberOfRolls}d{diceSides}+{fixedBonus}";
                }

                // WRITING OUT THE ROLLS
                Console.WriteLine($"Throwing {diceNotation}:");
                for(int total = 0; total < 10; total++)
                {
                    Console.Write($"{DiceRoll(diceNotation)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
