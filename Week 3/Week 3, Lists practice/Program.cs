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
        int n = 50;
        
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
        numbers.Sort();
        string lista = String.Join(", ", uniqueNumbers);     
        Console.WriteLine($"\n\n");

        Console.WriteLine($"Numbers are: {lista}");
        Console.WriteLine($"\n\n");

        int zeroToNine = 0;
        int tenToNineteen = 0;
        int twentyToTwentynine = 0;
        int thirtyToThirtynine = 0;
        int fortyToFortynine = 0;
        int fiftyToFiftynine = 0;
        int sixtyToNice = 0;
        int seventyToSeventynine = 0;
        int eightyToEightynine = 0;
        int ninetyToNinetynine = 0;
        foreach (var number in uniqueNumbers) 
        {
            if  (number < 10) 
            {
            zeroToNine++;
            }

            if  (9 < number && number < 20) 
            {
            tenToNineteen++;
            }

            if  (19 < number && number < 30) 
            {
            twentyToTwentynine++;
            }

            if  (29 < number && number < 40) 
            {
            thirtyToThirtynine++;
            }

            if  (39 < number && number < 50) 
            {
            fortyToFortynine++;
            }

            if  (49 < number && number < 60) 
            {
            fiftyToFiftynine++;
            }

            if  (59 < number && number < 70) 
            {
            sixtyToNice++;
            }

            if  (69 < number && number < 80) 
            {
            seventyToSeventynine++;
            }

            if  (79 < number && number < 90) 
            {
            eightyToEightynine++;
            }

            if  (89 < number) 
            {
            ninetyToNinetynine++;
            }
        }

        Console.WriteLine("Histogram:");
        Console.Write("  0-9:");
            for (int i = 0; i < zeroToNine; i++)
            {
            Console.Write("#");
            }
        Console.WriteLine();


        Console.Write("10-19:");
        for (int i = 0; i < tenToNineteen; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


        Console.Write("20-29:");
        List<int> twobase = new List<int> {};


        for (int i = 0; i < twentyToTwentynine; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


        Console.Write("30-39:");

        for (int i = 0; i < thirtyToThirtynine; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("40-49:");

        for (int i = 0; i < fortyToFortynine; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("50-59:");

        for (int i = 0; i < fiftyToFiftynine; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("60-69:");
        for (int i = 0; i < sixtyToNice; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("70-79:");
        for (int i = 0; i < seventyToSeventynine; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


            Console.Write("80-89:");
        for (int i = 0; i < eightyToEightynine; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();

            Console.Write("90-99:");
           
        for (int i = 0; i < ninetyToNinetynine; i++)
            {
        Console.Write("#");
            }
        Console.WriteLine();


        Console.WriteLine($"\n");


    // 1
        List<string> names = new List<string> {"Allie", "Ben", "Claire", "Dan", "Eleanor"}; 
        string people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

    //2
        names[0] = names[0].Replace("Allie", "Duke");
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");
       
    //3
        names[3] = "Lara";
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

    //4
        names[names.Count-1] = "Aaron";
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

    //5     
        names.Sort();
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

    //6
        names.Reverse();
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

    //7
        bool duke = false;
        if (names.Contains("Duke"))
            {
            duke = true;
            }
        Console.WriteLine(duke);
        Console.WriteLine($"\n");

    //8
        var index = names.IndexOf("Aaron");
        Console.WriteLine($"{index}\n\n");

    //9
        names.Insert(0, "Mario");
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");
    //10
        names.Insert(names.Count/2, "Luigi");
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

   //11 
        List<string> namesCopy = new List<string>{};
        for (int i = 0; i < names.Count; i++)
        {
        namesCopy.Add(names[i]);
        namesCopy.Add(names[i]);
        }
        names.Clear();
        names = namesCopy; 
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");
    
    //12
        string hold = names[0];
        names[0] = names[names.Count-1];
        names[names.Count-1] = hold;
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

    //13
        names.Remove(names[4]);
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

    //14     
        names.Remove(names[names.IndexOf("Mario")]);
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

    //15
        Console.Write(names.LastIndexOf("Claire"));
        Console.WriteLine("\n\n");

    //16
        names.RemoveAt(names.LastIndexOf("Aaron"));
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");

    //17
        List<string> uniqueList = names.Distinct().ToList();
        foreach(var name in uniqueList) 
        {
        names.Remove(name);
        }
        names = uniqueList.Except(names).ToList();
        people = String.Join(", ", names);     
        Console.WriteLine($"{people}\n\n");
        
    //18
        names.Clear();
        



















        }
    }
}
