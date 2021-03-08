using System;

namespace Day_1_Mission_1_Seasons
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
            
        string[] Seasons = {"Spring", "Summer", "Autumn", "Winter"};
        var Random = new Random();
        int day = Random.Next(1,31);
        int season = Random.Next(0,4);
        int year = Random.Next(0, 3000);

        Console.WriteLine($"{day}{OrdinalNumber(day)} day of {Seasons[season]} in the year {year}");
        }
    }
}