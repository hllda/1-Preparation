using System;

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

            string A = "X";
            string B = "X";

            string line1 = ($"-----+");
            string line2 = ($"|"); string line2a = ($"|"); string line2b = ($"|");
            string line3 = ($" ----|");
            string line4 = ($"     |");

            if (scoreSheet == 0)
            {
                Console.WriteLine("You decided to not go bowling.");
            }

            for (int index = 0; index < (scoreSheet); index++)
            {
                Console.WriteLine($"+{line1}");
                int firstRoll = random.Next(0, 11);

                if (firstRoll == 0)
                {
                    Console.Write($"| {line2}{miss}{line2a}");
                }

                if (0 < firstRoll && firstRoll < 10)
                {
                    Console.Write($"| {line2}{firstRoll}{line2a}");
                }

                if (firstRoll > 9)
                {
                    Console.WriteLine($"| {line2}{strike}{line2a}{" "}{line2b}");
            //       Console.WriteLine($"Knocked pins: 10\n");
                }

                else

                {
                    int secondRoll = random.Next(0, 11 - firstRoll);
                    int sum = (firstRoll + secondRoll);
                    if (secondRoll == 0)
                    {
                        Console.WriteLine($"{miss}{line2b}");
                    }

                    else
                    {

                        if (sum == 10)
                        {
                            
                            Console.WriteLine($"{spar}{line2b}");
                        }

                        if (0 < sum && sum < 10)
                        {
                            Console.WriteLine($"{secondRoll}{line2b}");
                        }


                    }


           //         Console.WriteLine($"Knocked pins: {sum}\n");
                }
                Console.WriteLine($"|{line3}");
                Console.WriteLine($"|{line4}");
                Console.WriteLine($"+{line1}\n");
                
            }
            Console.ReadKey();
        }
    }
}


