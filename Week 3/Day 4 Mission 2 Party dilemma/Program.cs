using System;

namespace Day_4_Mission_2_Party_dilemma
{
    class Program
    {

        static int Factorial(int n)
        {
     
            if (n == 0)
            {
            return 1;
            }  

            else
            {
            return n * Factorial(n - 1);
            }
        }
        static void Main(string[] args)
        {
            var Random = new Random();
            int n = Random.Next(0, 11);
            Console.Write($"{n}! = "); 
            Console.WriteLine(Factorial(n));
        }
    }
}
