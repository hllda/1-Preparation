using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace list_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int rounds = random.Next(0, 10);
            if (0 < rounds)
            {
                Console.Write("\n+");

            for (int i = 0; i < rounds; i++)
            {
            Console.Write("-----+");
            }
            
            Console.Write("\n|");;

            for (int j = 0; j < rounds; j++)

                {
                int roll = random.Next(0, 11);

            int first = roll;
            int second = random.Next(0, first);
            int sum = first + second;

                 if (first == 10)
                 {
                 Console.Write(" |X| |");
                 }
                     
                    else 
                    {
                       if (sum >= 10)
                       { 
                       Console.Write($" |{first}|/|");
                       }

                         else
                         {
                             if (first == 0 && second == 0)
                             { 
                              Console.Write($" |-|-|");
                             }
                         
                             else
                             { 

                                if (second == 0)
                                { 
                                Console.Write($" |{first}|-|");
                                }
                         
                                else
                                {   
                                     if (first == 0)
                                     { 
                                     Console.Write($" |-|{second}|");
                                     }      
                         
                                    else
                                    { 
                                      Console.Write($" |{first}|{second}|");
                                    }
                                } 
                             }
                         }
                 
                    }
            }

            Console.Write("\n|");

              for (int k = 0; k < rounds; k++)
            {
            Console.Write(" ----|");
            }
            
            Console.Write("\n|");

              for (int l = 0; l < rounds; l++)
            {
            Console.Write("     |");

            }
            
            Console.Write("\n+");
              for (int m = 0; m < rounds; m++)
            {
            Console.Write("-----+");
            }
            
            }
            
            else
            {
                  Console.WriteLine("You decided not to go bowling.");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
