using System;
using System.Collections.Generic;

namespace Day_5_Mission_2_Insertion_sort
{
    class Program
    {
        
        /* TEST CHART
        
        Description
        Data 
        Type 
        Expected 
        Actual

        TEST 1
        List is empty
        None
        Normal
        Write out that there are no numbers.
        Wrote out that there are no numbers.

        TEST 2
        Random List 1
        9, 0, 0, 6, 8, 0, 6, 4, 8, 7, 3, 2
        Normal
        0, 0, 0, 2, 3, 4, 6, 6, 7, 8, 8, 9
        0, 0, 0, 2, 3, 4, 6, 6, 7, 8, 8, 9

        TEST 3
        Random List 2
        0, 9, 4, 4, 7, 9, 0, 0, 4, 6, 2, 4, 9, 4, 3, 1, 3, 4, 5, 5, 0, 2, 8
        Normal
        0, 0, 0, 0, 1, 2, 2, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 6, 7, 8, 9, 9, 9
        0, 0, 0, 0, 1, 2, 2, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 6, 7, 8, 9, 9, 9

        TEST 4
        Only 5
        5, 5, 5, 5, 5, 5, 5
        Normal
        5, 5, 5, 5, 5, 5, 5
        5, 5, 5, 5, 5, 5, 5

        TEST 5
        Negatives
        -6, -1, -35, -0, -23, -1, -3, -8, -6, -2
        Normal
        -35, -23, -8, -6, -6, -3, -2, -1, -1, 0
        -35, -23, -8, -6, -6, -3, -2, -1, -1, 0

        TEST 6
        Letters
        Errenous
        "A", "C", "B", "c", "b", "a"
        Won't run

        */
        
        static void Main(string[] args)
        {
            var data = new List<int>() {"A", "C", "B", "c", "b", "a"};

            // Insertion sort

            // Split the list between sorted numbers on the left and unsorted on the right.
            // At the start, only the first number is sorted, the rest are unsorted.
            // Then take the first unsorted number and move it to the left until it is in the correct place in the sorted list.
            // Repeat this with all unsorted numbers until all the numbers are in the sorted list.
            int sortedCount = 1;

 
            do
            {
                if (data.Count == 0) break;
                // Find the first unsorted number.
                int indexOfFirstUnsortedNumber = sortedCount;
                int firstUnsortedNumber = data[indexOfFirstUnsortedNumber];

                // Test the sorted number to the left of it and see if it is bigger.
                int testIndex = indexOfFirstUnsortedNumber - 1;
                while (data[testIndex] > firstUnsortedNumber)
                {
                
                // The sorted number is bigger!
                // Move the sorted number to the right since it is bigger than the unsorted number.
                // (Bigger numbers must be on the right of the smaller ones.)
                data[testIndex + 1] = data[testIndex];

                // Continue testing the next number on the left.
                testIndex--;

                // Display data for diagnostic purposes.
                DisplayData(data);
                if (testIndex < 0) break;
                }

                // The unsorted number should now be placed into the spot where the last tested number was shifted away from.
                int insertionIndex = testIndex + 1;
                data[insertionIndex] = firstUnsortedNumber;

                // We've successfully sorted a new number.
                sortedCount++;

                // Display data for diagnostic purposes.
                DisplayData(data);

            } while (sortedCount < data.Count);

            if (data.Count == 0) 
            { 
            Console.WriteLine("There are no numbers to sort.");
            }

            else
            {
            Console.WriteLine($"The sorted numbers are: {string.Join(", ", data)}"); 
            }
            
        }

        static void DisplayData(List<int> data)
        {
        Console.WriteLine(String.Join(", ", data));
        }  

    }
}
