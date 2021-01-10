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
                roll += rnd;
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

            return numberRolls;
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
                return false;

            if(diceNotation.EndsWith("d"))
                return false;

            if(diceNotation.Contains("d+") || diceNotation.Contains("d-"))
                return false;

            return true;
        }
        static void Main(string[] args)
        {
            string diceNotation =
                "To use the magic potion of dragon breath, first roll d8. If you roll 2 or higher, you manage to open the potion. Now roll 5d4+5 to see how many seconds the spell will last. Finally, the damage of the flames will be 2d6 per second.";

            int diceNotations = 0;
            int totalRolls = 0;

            string[] words = diceNotation.Split(' ',',','.');

            for(int word = 0; word < words.Length; word++)
            {
                string diceNotationWord = words[word];

                if(IsStandardDiceNotation(diceNotationWord) == true)
                {
                    diceNotations++;
                    totalRolls += DiceRoll(diceNotationWord);
                }
            }

            Console.WriteLine($"{diceNotations} standard dice notations present.");
            Console.WriteLine($"The player will have to perform {totalRolls} rolls.");

            Console.WriteLine($"\n");
        }
    }
}

