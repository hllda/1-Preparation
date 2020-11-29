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
        string[] monthdays = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};
            Console.Write("Days this month are:");
            
            
        for (int i = 0; i < 30; i++)
        {
        Console.Write(monthdays[i]);
        if (i < monthdays.Length-1) Console.Write(", ");
        }
        Console.WriteLine($"\n\n");
          

        
        // 3
        Console.WriteLine(3);
             Console.Write("x random numbers are:");


        Console.WriteLine();

        // 4
        Console.WriteLine(4);
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
