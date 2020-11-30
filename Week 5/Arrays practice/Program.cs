using System;

namespace Arrays_practice
{
    class Program
    {
        static void Main(string[] args)
        {
        // PART 1
        Console.WriteLine("PART 1");
        // 1
        Console.WriteLine(1);
        string[] weekdays = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};
        Console.Write("Days of the week are: ");
        for (int i = 0; i < weekdays.Length; i++)
            {
            Console.Write(weekdays[i]);
            if (i < weekdays.Length-1) Console.Write(", ");
            }
        Console.WriteLine($"\n\n");


        // 2
        Console.WriteLine(2);
        string[] monthdays = new string[31];
 
        Console.Write("Days this month are: ");
        int cycle = 1;    
        for (int i = 0; i < 31; i++)
            {
            if (cycle > 6) cycle = 0;
            monthdays[i] = weekdays[cycle];
            cycle++;
            }

        for (int i = 1; i < 31+1; i++)
            {
            Console.Write($"{i}: {monthdays[i-1]}");
            if (i < 31) Console.Write(", ");
            }
        Console.WriteLine($"\n\n");
          

        
        // 3
        Console.WriteLine(3);
        var Random = new Random();
        int arrayLength = Random.Next(5,11);
        
        double[] arrayOfDoubles = new double[arrayLength];
        for (int i = 0; i < arrayLength; i++)
            {
            double randomDouble = Random.Next(1,11);
            arrayOfDoubles[i] = randomDouble;
            }
            Console.Write($"{arrayLength} random numbers are: ");
            
        for (int i = 0; i < arrayLength; i++)
            {
            Console.Write($"{arrayOfDoubles[i]}");
            if (i < arrayLength-1) Console.Write(", ");
            } 
        Console.WriteLine($"\n\n");   


        // 4
        Console.WriteLine(4);
        double[] interpolated = new double[arrayLength];





        Console.WriteLine();

        Console.WriteLine($"\n\n");

        // PART 2
        Console.WriteLine("PART 2");
        // 1
        Console.WriteLine(1);
        string[] b = {};
        Console.WriteLine();

        // 2
        Console.WriteLine(2);
        Console.WriteLine();
        
        // 3
        Console.WriteLine(3);
        Console.WriteLine();

        // 4
        Console.WriteLine(4);
        Console.WriteLine();

        // 5
        Console.WriteLine(5);
        Console.WriteLine();

        Console.WriteLine($"\n\n");

        // PART 3
        Console.WriteLine("PART 3");
        // 1
        Console.WriteLine(1);
        string[] a = {};
        Console.WriteLine();
        
        // 2
        Console.WriteLine(2);
        Console.WriteLine();
        
        // 3
        Console.WriteLine(3);
        Console.WriteLine();

        // 4
        Console.WriteLine(4);
        Console.WriteLine();

        // 5
        Console.WriteLine(5);
        Console.WriteLine();





















        }
    }
}
