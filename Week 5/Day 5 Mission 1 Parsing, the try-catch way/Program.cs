using System;
namespace Day_5_Mission_1_Parsing__the_try_catch_way
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
            //INITIALIZING VALUES
            int fixedBonus = 0;
            int numberOfRolls = 0;
            int diceSides = 0;

            // SPLIT THE STRING
            string[] notations = diceNotation.Split('d');
            //CHECK CRITERIAS
            if(!diceNotation.Contains("d"))
            {
                throw new ArgumentException("Roll description is not in standard dice notation.");
            }

            if(diceNotation.Contains("d-") || diceNotation.Contains("d+"))
            {
                throw new ArgumentException("Number of dice sides () is not an integer.");
            }

            if(diceNotation.Contains("+d") || diceNotation.Contains("-d"))
            {
                throw new ArgumentException("Number of rolls () is not an integer.");
            }

            try
            {
                numberOfRolls = Int32.Parse(notations[0]);
            }

            catch
            {
                try
                {
                    notations = diceNotation.Split('d','+','-');
                    diceSides = Int32.Parse(notations[0]);
                }
                catch
                {
                    throw new ArgumentException($"Number of rolls ({notations[0]}) is not an integer.");
                }
            }

            try
            {
                diceSides = Int32.Parse(notations[1]);
            }

            catch
            {
                try
                {
                    notations = diceNotation.Split('d','+','-');
                    diceSides = Int32.Parse(notations[1]);
                }
                catch
                {
                    throw new ArgumentException($"Number of dice sides ({notations[1]}) is not an integer.");
                }

            }

            notations = diceNotation.Split('d');
            if(diceSides <= 0)
            {
                throw new ArgumentException($"Number of dice sides ({notations[1]}) has to be positive.");
            }

            if(numberOfRolls <= 0)
            {
                throw new ArgumentException($"Number of rolls ({notations[0]}) has to be positive.");
            }

            notations = diceNotation.Split('d','+','-');

            // CHECK IF STATIC BONUS
            if(diceNotation.Contains("+"))
            {
                fixedBonus = +Int32.Parse(notations[2]);
            }

            else if(diceNotation.Contains("-"))
            {
                fixedBonus = -Int32.Parse(notations[2]);
            }

            return DiceRoll(numberOfRolls,diceSides,fixedBonus);
        }
        static void Throwing(string diceNotation)
        {
            try
            {
                DiceRoll(diceNotation);

                Console.Write($"Throwing {diceNotation}:");

                for(int total = 0; total < 10; total++)
                {
                    Console.Write($" {DiceRoll(diceNotation)}");
                }

            }

            catch(Exception e)
            {
                Console.Write($"Can't throw {diceNotation}; {e.Message}");
            }

            finally
            {
                Console.WriteLine($"\n");
            }

        }
        static void Main()
        {
            Throwing("2d6");
            Throwing("36");
            Throwing("-12");
            Throwing("ad6");
            Throwing("-3d6");
            Throwing("0d6");
            Throwing("d+");
            Throwing("2d-4");
            Throwing("2d2.5");
            Throwing("2d$");
            Throwing("5d6+5");
            Throwing("2d10-5");
            Console.WriteLine();
        }
    }
}
