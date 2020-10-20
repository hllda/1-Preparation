using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Day_1_4_Mission_Adventure_Map
{
    class Program
    {

        // BORDER - this is where the border is drawn.
        static void Border(int width, int height)
        {

        }   
        
        static void River(int width, int height)
        {
        
        }

        static void Road(int width, int height)
        {

        }

        static void Bridge(int width, int height)
        {

        }   

        static void Path(int width, int height)
        {

        }   

        static void Forest(int width, int height)
        {

        }   

        static void DrawMap(int width, int height)
        {
            for (int y = 0; y < height+1; y++)
            {
                for (int x = 0; x < width+1; x++)
                {   


                    // DRAW TITLE?
                    string title = "ADVENTURE MAP";
                    if (y == 1 && x == width/2-title.Length/2-1)
                    {
                    Console.Write($"{title}");
                    x += title.Length-1;
                    continue;
                    }

                    // DRAW BORDER?
                    if (y == 0 || x == 0 || y == height || x == width)
                    {
                        if (y == 0 && x == 0 ||y == height && x == 0)
                        {
                        Console.Write("+");
                        continue;
                        }

                        if (y == 0 && x != 0 && x != width || y == height && x != 0 && x != width)
                        {
                        Console.Write("-");
                        continue;
                        }

                        if (y == 0 && x == width || y == height && x == width)
                        {
                        Console.WriteLine("+");
                        continue;
                        }

                        if (x == 0 && y != 0 && y != height)
                        {
                        Console.Write("|");
                        continue;
                        }

                        if (x == width && y != 0 && y != height)
                        {
                        Console.WriteLine("|");
                        continue;
                        }
                    }

                    // DRAW TREE?
                    var random = new Random();
                    var treelist = new List<int>{ };
                    var tree = "A^¤@";
                    if (x < width/4)
                    {
                      
                    }




                }




                    Console.Write(" ");

                 



            }
        }
      
        

    
         static void Matrix(string[] args)
         {
            var random = new Random();
            List<int> treeList = new List<int>{};
            var symbols = "!@#$%^&*()_+-=[];',.\\/~{}:|<>?";

            for (int i = 0; i < 10; i++) 
            {
            treeList.Add(random.Next(0, 80));
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            while (true)
            {
                for (int x = 0; x < 80; x++)
                {
                    Console.Write(treeList.Contains(x) ? symbols[random.Next(symbols.Length)] : ' ');
                }

                Console.WriteLine();
                Thread.Sleep(100);

                if (random.Next(3) == 0) 
                { 
                treeList.RemoveAt(random.Next(treeList.Count-1));
                }
                
                if (random.Next(3) == 0)
                { 
                treeList.Add(random.Next(0, 80));
                }
            }   
         }

        static void Main(string[] args)
        {  
        int width = 60;
        int height = 20;
        DrawMap(width, height);
        }

    }

}

        




