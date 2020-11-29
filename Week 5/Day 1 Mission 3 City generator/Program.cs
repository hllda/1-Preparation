using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;

namespace Day_1_4_Mission_Adventure_Map
{
    class Program
    {                  
        static List<int> GenerateCurve(int width, int height, int start, int curveChance)
        {
            // CALCULATE CURVES
            var random = new Random();
            var curveValues = new List<int>();
            int xCurrentCurve = start;
            for(int y = 0; y < height+width; y++)
            {
                int direction = random.Next(0,curveChance);

                if(direction == 0 && xCurrentCurve < width-width/10)
                {
                xCurrentCurve++;
                }

                if(direction == 1 && xCurrentCurve > width/10)
                {
                xCurrentCurve--;
                }
                curveValues.Add(xCurrentCurve);
            }
            return curveValues;
        }

        static void GenerateRoad(bool[,] roads, int startX, int startY, int direction)
        {
        var rnd = new Random();
        int random = rnd.Next(0,4);
       
        
        }



        static void DrawMap(int width, int height)
        {   
            var random = new Random();
            // ROAD CALCULATION
             var roads = new bool[width, height]; 
            
            
            List<int> Road = new List<int> {};
            int yRoad = height/2;
            for(int x = 0; x < width+height; x++)
            {   
                int direction = random.Next(0,11);
                Road.Add(yRoad);
                



                if(direction == 0 && yRoad < height-height/10)
                { 
                yRoad++;
                continue;
                }
                    
                if(direction == 1 && yRoad > height/10)
                { 
                yRoad--;
                continue;
                }  
            }
            // HERE IS WHERE THE DRAWING ITSELF IS DONE
            
            for (int y = 0; y < height+1; y++)
            {
                for (int x = 0; x < width+1; x++)
                {   
                    // DRAW BORDER?
                    if (y == 0 || x == 0 || y == height || x == width)
                    {
                        if (y == 0 && x == 0 || y == height && x == 0)
                        {
                        Console.Write("┼");
                        continue;
                        }

                        if (y == 0 && x == width || y == height && x == width)
                        {
                        Console.WriteLine("┼");
                        continue;
                        }
                        
                        if (y == 0 && x != 0 && x != width || y == height && x != 0 && x != width)
                        {
                        Console.Write("─");
                        continue;
                        }

                        if (x == 0 && y != 0 && y != height)
                        {
                        Console.Write("│");
                        continue;
                        }

                        if (x == width && y != 0 && y != height)
                        {
                        Console.WriteLine("│");
                        continue;
                        }
                    }
                    
                    // DRAW TITLE?
                    string title = "CITY MAP";
                    if (y == 1 && x == width/2-title.Length/2-1)
                    {
                    Console.Write($"{title}");
                    x += title.Length-1;
                    continue;
                    }

                    // DRAW ROAD? 
                    if (y == Road[x])
                    {
                        Console.Write("#");
                        continue;
                    }


                    // NO? THEN DRAW NOTHING
                    Console.Write(" ");

                   
                }  
            }  
        }
        static void Main(string[] args)
        {
            Console.Clear();

            // MAP SIZE
            int width = 50;
            int height = 25;

            // DRAWING OF THE MAP
            DrawMap(width, height);

            Console.ReadKey();
        }  
    } 
} 