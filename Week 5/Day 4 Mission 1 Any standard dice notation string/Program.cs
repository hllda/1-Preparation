using System;

namespace Day_3_Mission_4_Standard_dice_notation
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
        static void Main(string[] args)
        {
            // GENERATING A DICE STRING WITH RANDOM VALUES AND 50/50 OF ADDING A FIXED BONUS SO I DONT HAVE TO COME UP WITH THEM
            for(int variations = 0; variations < 1; variations++)
            {
                var Random = new Random();
                int diceSides = Random.Next(1,20);
                int numberOfRolls = Random.Next(1,20);
                int bonusOdds = Random.Next(0,3);
                string diceNotation;

                if(numberOfRolls == 1)
                {
                    diceNotation = $"d{diceSides}";
                }

                else
                {
                    diceNotation = $"{numberOfRolls}d{diceSides}";
                }

                if(bonusOdds == 0)
                {
                    int fixedBonus = Random.Next(1,10);
                    diceNotation = $"{diceNotation}+{fixedBonus}";
                }

                else if(bonusOdds == 1)
                {
                    int fixedBonus = Random.Next(1,10);
                    diceNotation = $"{diceNotation}-{fixedBonus}";
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
