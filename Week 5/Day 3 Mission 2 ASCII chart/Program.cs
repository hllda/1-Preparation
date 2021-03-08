using System;

namespace Day_3_Mission_2_ASCII_chart
{
    class Program
    {
        static void Main(string[] args)
        {     
            for(int i = 0; i < 256; i++)
            {
               Console.WriteLine($"{i} = {(char)i}"); 
            }   
        }
    }
}
