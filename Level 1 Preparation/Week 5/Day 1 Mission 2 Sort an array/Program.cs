using System;
namespace Day_1_Mission_2_Sort_an_array
{
    class Program
    {
        static void Main(string[] args)
        {
        var random = new Random();
        
        int[] numbers =
        {
            16, 20, 3, 13, 8, 23, 6, 63, 38, 9, 60, 68, 7, 56, 47, 66, 58, 36, 42, 46, 18, 11, 48, 34, 51, 24, 62, 67, 57, 70, 54, 17, 1, 45, 44, 
            50, 30, 61, 39, 10, 59, 4, 14, 52, 40, 2, 31, 43, 15, 69, 33, 25, 35, 22, 5, 65, 37, 32, 53, 27, 21, 41, 55, 26, 28, 19, 64, 12, 49, 29
        };

        DisplayData(numbers);

        for (int sortingRange = numbers.Length; sortingRange > 0; sortingRange--)
        {
            for (int i = 0; i < sortingRange - 1; i++)
            {
                if (numbers[i + 1] < numbers[i])
                {
                    int temp = numbers[i + 1];
                    numbers[i + 1] = numbers[i];
                    numbers[i] = temp;
                }  
            }    
        }

        DisplayData(numbers);
        }

        static void DisplayData(int[] numbers)
        {
            Console.WriteLine();
            Console.WriteLine(string.Join(" , ", numbers));
        }
    }
}