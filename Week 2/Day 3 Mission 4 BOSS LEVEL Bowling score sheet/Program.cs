using System;
// WORK IN PROGRESS
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
     

            int totalFrames = scoreSheet;
        

            if (scoreSheet == 0)
            {
                Console.Write("You decided to not go bowling.");
            }

            for (int index = 0; index < (scoreSheet); index++)
            {
           
                int firstRoll = random.Next(0, 11);


               
                if (firstRoll == 0)
                {
                Console.Write($"+-----+\n| |{miss}");
                }
 
                if (0 < firstRoll && firstRoll < 10)
                {
                Console.Write($"+-----+\n| |{firstRoll}");
                }
                    

                if (firstRoll > 9)
                {
                    Console.Write($"+-----+\n| |{strike}| |\n| ----|\n|     |\n+-----+\n");
                 //   Console.WriteLine($"Knocked pins: 10");
                }

                else

                {
                    int secondRoll = random.Next(0, 11 - firstRoll);
                    int sum = (firstRoll + secondRoll);
                    if (secondRoll == 0)
                    {
                        Console.Write($"|{miss}|\n| ----|\n|     |\n+-----+\n");
                    }

                    else
                    {
                        
                        if (sum == 10)
                        {
                            Console.Write($"|{spar}|\n| ----|\n|     |\n+-----+\n");
                        }

                        if (0 < sum && sum < 10)
                        {
                            Console.Write($"|{secondRoll}|\n| ----|\n|     |\n+-----+\n");
                        }

                  
                   }
                  //  Console.WriteLine($"Knocked pins: {sum}");






                }
            }
            Console.ReadKey();
        }
    }
}
