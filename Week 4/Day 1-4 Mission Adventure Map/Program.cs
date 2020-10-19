using System;
using System.Runtime.InteropServices;

namespace Day_1_4_Mission_Adventure_Map
{
    class Program
    {

        // BORDER - this is where the border is drawn.
        static void Border(int width, int height)
        {
            Console.WriteLine($"+{"+".PadLeft(width, '-')}");
            string title = "ADVENTURE MAP";
            Console.WriteLine($"|{title.PadLeft(width/2+title.Length/2-1,' ')}{"|".PadLeft(width/2-title.Length/2+1,' ')}");
            for (int i = 0; i < height; i++)
            {
            Console.WriteLine($"|{"|".PadLeft(width, ' ')}");
            }
            Console.WriteLine($"+{"+".PadLeft(width, '-')}");
        }   
        

   
        static void River(int width, int height)
        {
        Console.SetCursorPosition(1, 1);
        
        }

        static void Road(int width, int height)
        {
        Console.SetCursorPosition(1, 1);
        }

        static void Bridge(int width, int height)
        {
        Console.SetCursorPosition(1, 1);
        }   

        static void Path(int width, int height)
        {
        Console.SetCursorPosition(1, 1);
        }   

        static void Forest(int width, int height)
        {
        Console.SetCursorPosition(1, 1);
        }   

        static void DrawMap(int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width+1; x++)
                {
            
                    if (y == 0 && x == 0)
                    {
                    Console.Write("+");
                    }

                    if (y == 0 && x != 0)
                    {
                    Console.Write("-");
                    }

                    if (y == 0 && x == width)
                    {
                    Console.WriteLine("+");
                    }


                    if (y != 0 && x == 0)
                    {
                    Console.Write("|");
                    }

                    if (y != 0 && x != width && y != height)
                    {
                    Console.Write(" ");
                    }

                    if (y != 0 || y != height && x == width)
                    {
                    Console.WriteLine("|");
                    }

                    
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

