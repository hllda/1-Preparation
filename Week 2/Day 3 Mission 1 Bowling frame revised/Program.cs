using System;
using System.Diagnostics.CodeAnalysis;

namespace Mission_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string miss = "-";
            string spar = "/";
            string strike = "X";
            var random = new Random();
            int scoreSheet = random.Next(0, 11);
            
            
            
            if (scoreSheet == 0)
            {
                Console.WriteLine("You decided to not go bowling.");
            }

            for (int index = 0; index < (scoreSheet); index++)
            {
           
                int firstRoll = random.Next(0, 11);


               
                if (firstRoll == 0)
                {
                Console.WriteLine($"First roll: {miss}");
                }
 
                if (0 < firstRoll && firstRoll < 10)
                {
                Console.WriteLine($"First roll: {firstRoll}");
                }
                    

                if (firstRoll > 9)
                {
                    Console.WriteLine($"First roll: {strike}");
                    Console.WriteLine($"Knocked pins: 10\n");
                }

                else

                {
                    int secondRoll = random.Next(0, 11 - firstRoll);
                    int sum = (firstRoll + secondRoll);
                    if (secondRoll == 0)
                    {
                        Console.WriteLine($"Second roll: {miss}");
                    }

                    else
                    {
                        
                        if (sum == 10)
                        {
                            Console.WriteLine($"Second roll: {spar}");
                        }

                        if (0 < sum && sum < 10)
                        {
                            Console.WriteLine($"Second roll: {secondRoll}");
                        }

                  
                   }
                    Console.WriteLine($"Knocked pins: {sum}\n");

                }
            }
            Console.ReadKey();
        }
    }
}
