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

        long product = (numbers[0]*numbers[1]*numbers[2]*numbers[3]*numbers[4]*numbers[5]*numbers[6]*numbers[7]*numbers[8]*numbers[9]);
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
        uniqueNumbers.Sort();
        List<int> uniqueNumbersCopy = new List<int>(uniqueNumbers);
        int m = uniqueNumbers.Count();
        int o = n - (numbers.Count - uniqueNumbers.Count);
        List<int> list5 = new List<int>{uniqueNumbers[m-1], uniqueNumbers[m-2], uniqueNumbers[m-3], uniqueNumbers[m-4], uniqueNumbers[m-5], uniqueNumbers[m-6], uniqueNumbers[m-7], uniqueNumbers[m-8], uniqueNumbers[m-9], uniqueNumbers[m-10]};
        list5.Sort();
        string list6 = String.Join(", ", list5);
        Console.Write($"Largest ten unique numbers are: {list6}");  
        Console.WriteLine($"\n\n");

        // 10
        Console.Write($"There are {o} total unique numbers.");  
        Console.WriteLine($"\n\n");

        // 11

        List<int> zeronine = new List<int> {}; 

        for (int i = 0; i < 100; i++)
        {
        zeronine.Add(i);
        }

        List<int> missing = zeronine.Except(uniqueNumbers).ToList();

        string list7 = String.Join(", ", missing);
        Console.Write($"The missing numbers are: {list7}");
        Console.WriteLine($"\n\n");

        // 12


        uniqueNumbers.Sort();
        string lista = String.Join(", ", uniqueNumbers);     
        Console.WriteLine($"\n\n");
        // 2
        Console.WriteLine($"Numbers are: {lista}");
        Console.WriteLine($"\n\n");








        Console.WriteLine("Histogram:");

        Console.Write("  0-9:");
        List<int> zerobase = new List<int> {};
        for (int i = 10; i < 99; i++)
        {
        zerobase.Add(i);
        }

        List<int> zero = uniqueNumbers.Except(zerobase).ToList();
            for (int i = 0; i < zero.Count; i++)
            {
            Console.Write("#");
            }
        Console.WriteLine();


        Console.Write("10-19:");
        List<int> onebase = new List<int> {};
        for (int i = 0; i < 9; i++)
        {
        onebase.Add(i);
        }
        for (int i = 20; i < 99; i++)
        {
        onebase.Add(i);
        }
        List<int> one = uniqueNumbers.Except(onebase).ToList();
        for (int i = 0; i < one.Count; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


        Console.Write("20-29:");
        List<int> twobase = new List<int> {};
        for (int i = 0; i < 19; i++)
        {
        twobase.Add(i);
        }
        for (int i = 30; i < 99; i++)
        {
        twobase.Add(i);
        }
        List<int> two = uniqueNumbers.Except(twobase).ToList();
        for (int i = 0; i < two.Count; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


        Console.Write("30-39:");
        List<int> threebase = new List<int> {};
        List<int> three = new List<int>(uniqueNumbers);
        for (int i = 0; i < three.Count; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("40-49:");
        List<int> fourbase = new List<int> {};
        List<int> four = new List<int>(uniqueNumbers);
        for (int i = 0; i < four.Count; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("50-59:");
        List<int> fivebase = new List<int> {};
        List<int> five = new List<int>(uniqueNumbers);
        for (int i = 0; i < five.Count; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("60-69:");
        List<int> sixbase = new List<int> {};
        List<int> six = new List<int>(uniqueNumbers);
        for (int i = 0; i < six.Count; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("70-79:");
        List<int> sevenbase = new List<int> {};
        List<int> seven = new List<int>(uniqueNumbers);
        for (int i = 0; i < seven.Count; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("80-89:");
            List<int> eightbase = new List<int> {};
        List<int> eight = new List<int>(uniqueNumbers);
        for (int i = 0; i < eight.Count; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();

            Console.Write("90-99:");
            List<int> ninebase = new List<int> {};
        List<int> nine = new List<int>(uniqueNumbers);

        for (int i = 0; i < nine.Count; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


        Console.WriteLine($"\n\n");











        }
    }
}
