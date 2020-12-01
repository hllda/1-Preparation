﻿using System;
namespace Arrays_practice
{
    class Program
    {
        static void Main(string[] args)
        {
        var Random = new Random();
        
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
        var today = DateTime.Today;
        var month = new DateTime(today.Year, today.Month, 1);

        int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
        string[] monthdays = new string[daysInMonth];
        
        Console.WriteLine("Days this month are: "); 
        string weekday = month.ToString("dddd");

        for (int i = 0; i < daysInMonth; i++)
            {    
            monthdays[i] = month.ToString("ddd");
            Console.WriteLine($"{i+1}: {monthdays[i]}");
            month = month.AddDays(1);
            }
        Console.WriteLine($"\n\n");
  

        // 3
        Console.WriteLine(3);
        int arrayLength = Random.Next(5,11);
        
        double[] arrayOfDoubles = new double[arrayLength];
        for (int i = 0; i < arrayLength; i++)
            {
            double randomDouble = Random.Next(1,11);
            arrayOfDoubles[i] = randomDouble;
            } 
        Console.WriteLine($"{arrayLength} random numbers are: {string.Join(", ", arrayOfDoubles)}");
        Console.WriteLine($"\n\n");   


        // 4
        Console.WriteLine(4);
        var interpolated = new double[arrayLength * 2 - 1];
        interpolated[0] = arrayOfDoubles[0];
        for (int i = 1; i < arrayLength; i++)
            {
            interpolated[i * 2] = (arrayOfDoubles[i]);
            interpolated[i * 2 - 1] = (arrayOfDoubles[i] + arrayOfDoubles[i-1]) / 2;
            }
        Console.WriteLine($"Interpolated numbers are: {string.Join(", ", interpolated)}");
        Console.WriteLine($"\n\n");



        // PART 2
        Console.WriteLine("PART 2");
        // 1
        Console.WriteLine(1);

        int hor = Random.Next(2,6);
        int ver = Random.Next(2,6);
        int[,] array2D = new int[hor, ver];
        for (int y = 0; y < ver; y++)
        {
            for (int x = 0; x < hor; x++)
            {
            int fil = Random.Next(0,10);
            array2D[x, y] = fil;
            }
        }

        for (int y = 0; y < ver; y++)
        {
            for (int x = 0; x < hor; x++)
            {
            Console.Write(array2D[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\n\n");


        // 2
        int[,] array2Dtransposed = new int[ver, hor];
        Console.WriteLine(2);
        for (int y = 0; y < hor; y++)
        {
            for (int x = 0; x < ver; x++)
            {
            array2Dtransposed[x, y] = array2D[y, x];
            }
        }

        for (int y = 0; y < hor; y++) 
        {
            for (int x = 0; x < ver; x++)   
            {
            Console.Write(array2Dtransposed[x, y]);
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\n\n");

        
        // 3
        Console.WriteLine(3);
        int[,] tenTable = new int[11, 11];
        for (int y = 1; y <= 10; y++)
        {
            for (int x = 1; x <= 10; x++)
            {
            tenTable[x, y] = x * y;
            }
        }

        for (int y = 1; y <= 10; y++) 
        {
            for (int x = 1; x <= 10; x++)   
            {
            Console.Write($"{tenTable[x, y]} ");
            if (x * y < 10) Console.Write(" ");   
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\n\n");

        // 4
        Console.WriteLine(4);
        int[,] chess = new int[8, 8];
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
            chess[x, y] = 0;
            }
        }

        for (int y = 0; y < 8; y++) 
        {
            for (int x = 0; x < 8; x++)   
            {
            Console.Write($"{chess[x, y]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        // 5
        Console.WriteLine(5);
        char[,] tic = new char[3, 3];
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
            tic[x, y] ='#';
            }
        }

        for (int y = 0; y < 3; y++) 
        {
            for (int x = 0; x < 3; x++)   
            {
            Console.Write($"{tic[x, y]} ");
            }
            Console.WriteLine();
        }
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