using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace Week_3__Methods_practice
{
    class Program
    {
        //1
        public static int Adder(int addthis, int addthat)
        { 
        int result = addthis + addthat;
        return result;
        }

        //2
        private static int SafeDivision(int diviend, int divisor)
        {
        if (divisor == 0)
           {
           return diviend;
           }
        int result = diviend / divisor;
        return result;
        }

        //3
        private static double AreaOfCircle(double radius)
        {
        double area = Math.PI * radius * radius;
        return area;
        }
            

        //4
        private static int MaximumInteger(int first, int second)
        {
        if (first < second)
        {
        return second;
        }

        else
        { 
        return first;
        }
        }


        //5
        static int AddIntegers(List<int> nums)
        { 
        int sum = 0;
        foreach(int num in nums)
        {sum += num;}
        return sum;
        }


        //6
        static int SmallestOfIntegers (List<int> numnums)
        {
        numnums.Sort();

        return numnums[0];
        }

        //7
        static string SortIntegersDecending(List<int> numnums)
        {
        numnums.Sort();
        numnums.Reverse();
        return String.Join(", ", numnums);
        }

        //8
        static string UniqueIntegers(List<int> nomnom)
        {
        List<int> nom = nomnom.Distinct().ToList();
        return String.Join(", ", nom);;
        }


        //9
        static string JoinIntegers(List <int> listone, List<int> listtwo)
        {
        List<int> listonetwo = new List<int>{};
       

        foreach(int nums in listone)
        {
        listonetwo.Add(nums);
        }
               
        foreach(int nums in listtwo)
        {
        listonetwo.Add(nums);
        }
        listonetwo.Sort();
        return String.Join(", ", listonetwo);
        }


        //10



        //11

        //12

        //13

        //14



        //1

        //2

        //3

        //4

        //5

        //6

        //7




        static void Main(string[] args)
        {
        //1
        int addthis = 1;
        int addthat = 4;  
        Console.WriteLine ($"{addthis} + {addthat} = {Adder(addthis, addthat)}");

        Console.WriteLine();

        //2
        int divisor = 10;
        int diviend = 4; 
        SafeDivision(diviend, divisor);
        Console.WriteLine ($"{divisor} / {diviend} = {SafeDivision(divisor, diviend)}");

        Console.WriteLine();

        //3
        int radius = 5;
        Console.WriteLine ($"A circle with the radius {radius} has area {AreaOfCircle(radius)}");
        Console.WriteLine();


        //4
        int first = 10;
        int second = 5;
        Console.WriteLine($"The maximum of {first} and {second} is {MaximumInteger(first, second)}");
        Console.WriteLine();


        //5
        List<int> nums = new List<int> {1, 2, 3, 4, 5}; 

        Console.WriteLine(AddIntegers(nums));
        Console.WriteLine();


        //6
        List<int> numnums = new List<int> {45, 39, 100, 7};
        Console.WriteLine (SmallestOfIntegers(numnums));
        Console.WriteLine();

        //7
        Console.WriteLine(SortIntegersDecending(numnums));
        Console.WriteLine();

        //8
        List<int> nomnom = new List<int> {10, 3, 10, 2, 0, 2, 10 , 1, 10, 5};
        Console.WriteLine(UniqueIntegers(nomnom));
        Console.WriteLine();

        //9
        List<int> listone = new List<int> {6, 4, 3, 8};
        List<int> listtwo = new List<int> {1, 2, 5, 7,};

        Console.WriteLine(JoinIntegers(listone, listtwo));



        //10

        //11

        //12

        //13

        //14



        //1

        //2

        //3

        //4

        //5

        //6

        //7


        }
    }
}
