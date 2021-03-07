using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_2_Mission_1_Hexadecimal_detector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> hex = new List<string> {"42", "0x42", "0x2A", "0xFFEE", "x2A", "0b2A", "0x2GA", "10x2A"};

            string pattern = "^0[x|X][a-fA-F0-9]{2,4}";

            for(int i = 0; i < hex.Count; i++)
            if(Regex.IsMatch(hex[i], pattern))
            {
                Console.WriteLine(hex[i]);
            }
        }
    }
}
