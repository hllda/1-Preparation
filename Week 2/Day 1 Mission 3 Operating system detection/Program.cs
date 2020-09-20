using System;

namespace Mission_3
{
    class Program
    {
        static void Main(string[] args)
        {

            string checkSystem = System.Environment.OSVersion.VersionString;
            Console.WriteLine($"You are running the game on Windows: {checkSystem.Contains("Windows")}");

        }
    }
}
