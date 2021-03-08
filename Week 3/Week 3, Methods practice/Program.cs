using System;
using System.CodeDom.Compiler;
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
        static string CreateRandomIntegers(int minimum, int maximum, int count)
        {
        List<int> randomInts = new List<int> {};
        var random = new Random();
        
        for (int i = 0; i < count; i++)
        {
        int minmax = random.Next(minimum,maximum+1);
        randomInts.Add(minmax);
        }
        return String.Join(", ", randomInts);
        }


        //11
        static string Indent(int indentsam, string words)
        {
        string indents = "";
        for (int i = 0; i < indentsam; i++)
        {
        indents = $"{indents} ";
        }
        string indented = $"{indents}{words}";
        return $"{indented}";
        }

        //12
        static string CreateFullNames(List <string> firstname, List <string> lastname)
        {
        List<string> names = new List<string>{};

        for (int name = 0; name < firstname.Count; name++)
        {
        names.Add(string.Concat(firstname[name], " ", lastname[name]));
        }
        return String.Join(", ", names);
        }


        //13
        static string ZipStrings(List <string> nameones, List <string> nametwos)
        {
        List<string> names = new List<string>{};
        if (nametwos.Count < nameones.Count)
        { 
            for (int name = 0; name < nameones.Count; name++)
            {
            names.Add(nameones[name]);
            if (nametwos.Count > name)
            {
            names.Add(nametwos[name]);
            }
            
            }     
        }

        else if (nameones.Count < nametwos.Count)
        {
            for (int name = 0; name < nametwos.Count; name++)
            {
           

            if (nameones.Count > name)
            {
            names.Add(nameones[name]);
            }
            names.Add(nametwos[name]);
            }
        }

        else
        {
            for (int name = 0; name < nameones.Count; name++)
            {
            names.Add(nameones[name]);
            names.Add(nametwos[name]);
            }
        }

        return String.Join(", ", names);
        }



        //14
        static int CountStrings(List <string> weirdos, string searchValue)
        {
        int searchString = weirdos.Where(x => x.Equals(searchValue)).Count();
                // ($"{searchValue}");
        return searchString;
        }

        // I know I didn't use recursion, but it didn't feel necessary, if it's more efficient in any of the cases please show me :D
        //1
        static int Power(int a, int b)
        {
            int sum = a;
            for (int i = 0; i < b-1; i++)
            {
            sum *= a;
            }

        return sum;
        }
        
        
        //2
        static string Factorial(int n)
        {
        List<int> nomnom = new List<int>{};
        int sum = 1;
        for (int i = 1; i < n+1; i++)
        {
        sum = sum * i;
        nomnom.Add(sum);
        }
        string sums = String.Join(", ", nomnom);
        return sums;
        }
        
        
        //3
        static int Fibonacci(int n)
        {
        int sum = n; 
        for (int i = 1; i < n; i++)
        {
        sum = (Fibonacci(n - 1) + Fibonacci(n - 2));
        }
        return sum;
        }
        
        
        //4
        static string CreateListOfDigits(int digits)
        {
        if (digits == 0)
        {
        return "0";
        }
        List<int> digi = new List<int>{};
        for (int i = 0; i < digits-1; i++)
        {
        int dig = digits % 10;
        digi.Add(dig);
        digits = (digits - dig) / 10; 
        }
        digi.Add(digits);
        digi.Sort();
        return String.Join(", ", digi);
        }


        //5
        static string ConvertToBinary(string deciText)
        {
        int deci = Int32.Parse(deciText);
        string bin = Convert.ToString(deci, 2);
        
        return bin;
        }

        
        //6
        static int SmallestIntegers(List<int> smallest)
        {
        List<int> smallestfirst = new List<int>(smallest);
        int cunt = smallest.Count;
        smallestfirst.RemoveRange(cunt/2, cunt/2);
        smallestfirst.Sort();
        
        List<int> smallestsecond = new List<int>(smallest);
        smallestsecond.RemoveRange(0, cunt/2);
        smallestsecond.Sort();
        
        List<int> smallestVSsmallest = new List<int>{smallestfirst[0], smallestsecond[0]};
        smallestVSsmallest.Sort();

        return smallestVSsmallest[0];
        }


        //7
        static string SelectionSort(List<int> inefficientSort)
        {

        for (int j = 0; j < inefficientSort.Count; j++)
        { 
            for (int i = 0; i < inefficientSort.Count; i++)
            {   
                if (inefficientSort[i] > inefficientSort[j])
                {
                int temporary = inefficientSort[j];
                inefficientSort[j] = inefficientSort[i];
                inefficientSort[i] = temporary;
                }
            }
        }
        return string.Join(", ", inefficientSort);
        }



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
        Console.WriteLine();


        //10
        var random = new Random();
        int cou = random.Next(10,21);
        Console.WriteLine(CreateRandomIntegers(1, 5, cou));
        Console.WriteLine();

            
        //11
        int indentsam = 6;
        string words = $"<- Here are {indentsam} spaces!";
        Console.WriteLine(Indent(indentsam, words));
        Console.WriteLine();

        //12
        List<string> firstname = new List<string> {"Lara", "Duke", "Sonic"};
        List<string> lastname = new List<string> {"Croft", "Nukem", "the Hedgehog"};
        Console.WriteLine(CreateFullNames(firstname, lastname));
        Console.WriteLine();  
        

        //13
        List<string> nameones = new List<string> {"Mario", "Luigi", "Peach", "Bowser", "Yoshi"};
        List<string> nametwos= new List<string> {"Link", "Zelda", "Ganondorf", "Hilda", "Tingle", "Zant", "Midna"};
        Console.WriteLine(ZipStrings(nameones, nametwos));
        Console.WriteLine();  

        //14
        List<string> weirdos = new List<string> {"ADD", "DEL", "INC", "ADD", "JMP", "SUB", "DEC"};
        string searchValue = "ADD";
        Console.WriteLine($"The word {searchValue} occurs in the list {CountStrings(weirdos, searchValue)} times");
        Console.WriteLine("\n");


        //1
        int a = 2;
        int b = 3;
        Console.WriteLine(Power(a, b));
        Console.WriteLine();

        //2
        int n = 5;
        Console.WriteLine(Factorial(n)); 
        Console.WriteLine();

        //3
        Console.WriteLine($"Fibonacci number on place {n} is {Fibonacci(n)}");  
        Console.WriteLine();

        //4
        int digits = 582399;
        Console.WriteLine(CreateListOfDigits(digits));
        Console.WriteLine();

        //5
        string deciText = "255";
        Console.WriteLine($"The decimal number {deciText} is written as {ConvertToBinary(deciText)} in binary.");   
        Console.WriteLine();

        //6
        List<int> smallest = new List<int> {16, 6, 69, 42, 14, 24, 32};
        Console.WriteLine(SmallestIntegers(smallest));
        Console.WriteLine();

        //7
        List<int> inefficientSort = new List<int> {16, 6, 69, 42, 14, 24, 32};
        Console.WriteLine(SelectionSort(inefficientSort));
        }
    }
}
