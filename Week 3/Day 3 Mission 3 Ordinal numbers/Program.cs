using System;
using System.Transactions;

namespace Day_3_Mission_3_Ordinal_numbers
{
    class Program
    {
        static string OrdinalNumber(int x)
        {   
            int y = x % 10;
            if (x < 10)
            {
                if (y == 1)
                {
                return "st";
                }

                else if (y == 2)
                {
                return "nd";
                }

                else if (y == 3)
                {
                return "rd";
                }
               
                else
                {
                return "th";
                }
            }
            
            else
            { 
                int z = (x / 10) % 10;
                if (z == 1)
                {
                return "th";
                }

                else
                { 
                    if (y == 1)
                    {
                    return "st";
                    }

                    else if (y == 2)
                    {
                    return "nd";
                    }

                    else if (y == 3)
                    {
                    return "rd";
                    }
               
                    else
                    {
                    return "th";
                    }
                }
            }
        }
        static void Main(string[] args)
        {
        Console.Write("Enter number: ");
        string text = Console.ReadLine();
        Console.Clear();
        int x = Int32.Parse(text);
        Console.WriteLine($"{x}{OrdinalNumber(x)}");
        }
    }   
}
