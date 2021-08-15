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

        static void DrawMap(int width, int height)
        {   
            var random = new Random();
           
            // RIVER CALCULATION
            int xRiver = width/4 * 3;
            List<int> River = GenerateCurve(width, height, xRiver, 4);
 
            // WALL CALCULATION
            int xWall = width/4;
            List<int> Wall = GenerateCurve(width, height, xWall, 21);

            // ROAD CALCULATION
            List<int> Road = new List<int> {};
            int yRoad = height/2;
            for(int x = 0; x < width+height; x++)
            {   
                int direction = random.Next(0,11);
                Road.Add(yRoad);
                
                if(Wall[yRoad] - 1 <= x && x <= Wall[yRoad] + 1)
                {
                continue;
                }
                
                if (River[yRoad] - 3  <= x && x <= River[yRoad] + 4)
                {
                continue;
                }

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
            int twoPillars = 2;
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
                    string title = "ADVENTURE MAP";
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

                    // DRAW BRIDGE?
                    if (((y == Road[x] + 1) || (y == Road[x] - 1)) && (River[y] - 3 < x) && (x < River[y] + 5))
                    {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("=");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                    }
                    
                    // DRAW RIVER?
                    if (x == River[y])
                    {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("~~~");
                    Console.ForegroundColor = ConsoleColor.White;
                    x += 2;
                    continue;
                    }

                    // DRAW PATH?
                    if ((y > Road[x]) && y != height && x == River[y]-5)
                    {
                    Console.Write("#");
                    continue;
                    }
                    
                    // DRAW WALL?
                    if (((((x == Wall[y]) || (x-1==Wall[y])) && y == Road[x] - 1) || (((x == Wall[y]) || (x-1==Wall[y])) && y == Road[x] + 1)) && twoPillars != 0)
                    {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("[]");
                    Console.ForegroundColor = ConsoleColor.White;
                    x += 1;
                    twoPillars--;
                    continue;
                    }

                    if (y != 0 && y != height && x == Wall[y])
                    {

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        if (Wall[y-1] < Wall[y])
                        { 
                        Console.Write(@"\\");
                        }

                        if (Wall[y-1] > Wall[y])
                        { 
                        Console.Write("//");
                        }
                   
                        if (Wall[y-1] == Wall[y])
                        { 
                        Console.Write("||");
                        }

                    Console.ForegroundColor = ConsoleColor.White;
                    x += 1;
                    continue;
                    }

                    // DRAW FOREST?
                    if (x == 1 || x < width/4 && x != 0)
                    {
                    int chanceHundred = random.Next(0, 101);
                        if (100/(x*1) >= chanceHundred || x <= 2)
                        {
                        List<string> treeList = new List<string>{"A", "^", "¤", "Ä", "Å", "Y", "0"};

                        int randomColor = random.Next(0,2);

                        if (randomColor == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                        if (randomColor == 1) Console.ForegroundColor = ConsoleColor.Green; 

                        Console.Write(treeList[random.Next(0, treeList.Count)]);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                        }  
                    }

                    // DRAW LAKE?
                    if (((y > height / 6 - height/15 && y < height / 6 + height/7 && x > width / 9 * 4 - width/16  && x < width / 9 * 4 + width/6) || (y > height / 6 - height/10 && y < height / 6 + height/6 && x > width / 9 * 4 - width/20  && x < width / 9 * 4 + width/8)) && (y < Road[x]))
                    {
                    // DRAW LILYPAD IN LAKE
                    int lilypadSpawn = random.Next(0, 11); 
                    if (lilypadSpawn == 0)
                    {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("O");
                    Console.ForegroundColor = ConsoleColor.White;
                    int lilypadFlowerSpawn = random.Next(0,4);
                    if (lilypadFlowerSpawn == 0)
                    { 
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("*");
                    x++;
                    continue;
                    }

                    else continue;
                    }
                    // DRAW WATER IN LAKE
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("~");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                    }


                    // DRAW PINETREE?
                    int treeSpawn = random.Next(0, 201);
                    if (treeSpawn == 0)
                    {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("A");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                    }

                    // DRAW FLOWER?
                    int flowerSpawn = random.Next(0,4);
                    int flowerColor = random.Next(0,6);
                    if (flowerSpawn == 0 && y > Road[x]+2 && x > River[y]+4)
                    {
                    if (flowerColor == 0) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (flowerColor == 1) Console.ForegroundColor = ConsoleColor.Red;
                    if (flowerColor == 2) Console.ForegroundColor = ConsoleColor.Blue;
                    if (flowerColor == 3) Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (flowerColor == 4) Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("*");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                    }
                    // DRAW SPACE FOR SOCIAL DISTANCING
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