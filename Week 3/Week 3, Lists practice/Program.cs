using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Week_3__Lists_practice
{
    class Program
    {
        static void Main(string[] args)
        {
        var random = new Random();
        
        // 1
        Console.WriteLine("Write a number: ");
        string numberText = Console.ReadLine();
        int n = Int32.Parse(numberText);
        
        List<int> numbers = new List<int>{};
        for (int i = 0; i < n; i++)
        {
        int rnd = random.Next(0, 100);
        numbers.Add(rnd);
        }
        int sum = numbers.Sum();

        string list = String.Join(", ", numbers);     
        Console.WriteLine($"\n\n");
        // 2
        Console.WriteLine($"Numbers are: {list}");
        Console.WriteLine($"\n\n");
        // 3
        Console.WriteLine($"The sum of the numbers is: {sum}");
        Console.WriteLine($"\n\n");
        // 4
        decimal average = sum / n;
        Console.WriteLine($"The average of the numbers is: {average}");

        int product = (numbers[0]*numbers[1]*numbers[2]*numbers[3]*numbers[4]*numbers[5]*numbers[6]*numbers[7]*numbers[8]*numbers[9]);
        Console.WriteLine($"\n\n");
        // 5
        Console.WriteLine($"The product of the first 10 numbers is: {product}");
        Console.WriteLine($"\n\n");

        //6
        numbers.Sort();
        string list2 = String.Join(", ", numbers);   
        
        Console.WriteLine($"Sorted numbers are: {list2}");

        Console.WriteLine($"\n\n");


        //7
        List<int> numbersCopy = new List<int>(numbers);
        numbersCopy.RemoveAll(i => i % 2 != 0);
        string list3 = String.Join(", ", numbersCopy);  
        Console.WriteLine($"Even numbers are: {list3}");
        Console.WriteLine($"\n\n");

        //8
        List<int> numbersCopy2 = new List<int>(){numbers[n-1], numbers[n-2], numbers[n-3], numbers[n-4], numbers[n-5], numbers[n-6], numbers[n-7], numbers[n-8], numbers[n-9], numbers[n-10]};
        string list4 = String.Join(", ", numbersCopy2);
        Console.WriteLine($"The largest 10 numbers are: {list4}");
        
        Console.WriteLine($"\n\n");

        // 9
        

        List<int> uniqueNumbers = numbers.Distinct().ToList();
        for (int i = 0; i < 10; i++)
        uniqueNumbers.ForEach(i => Console.WriteLine($"{i}"));
        List<int> numbersCopy4 = new List<int>(){uniqueNumbers[n-1], uniqueNumbers[n-2], uniqueNumbers[n-3], uniqueNumbers[n-4], uniqueNumbers[n-5], uniqueNumbers[n-6], uniqueNumbers[n-7], uniqueNumbers[n-8], uniqueNumbers[n-9], uniqueNumbers[n-10]};
        string list5 = String.Join(", ", numbersCopy4);
        Console.Write($"Largest ten unique numbers are: {list5}");  
      
        Console.WriteLine($"\n\n");

        // 10

        





        }
    }
}
