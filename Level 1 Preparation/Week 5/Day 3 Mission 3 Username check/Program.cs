using System;

namespace Day_3_Mission_3_Username_check
{
    class Program
    {
        static bool IsValidUsername(string username)
        {
            for(int i = 0;i < 255;i++)
            {
                if(i == 48)
                    i = 58;

                if(i == 97)
                    i = 123;

                if(username.Contains((char)i) == true)
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            Console.WriteLine($"{username} = {IsValidUsername(username)}");
        }
    }
}