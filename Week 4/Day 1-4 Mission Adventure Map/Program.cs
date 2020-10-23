using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;

   /*
1. Prepare all the data
   1.1 Place the Road
   1.2 Place the River
   1.3 Place the Bridge where the Bridge and River cross paths
   1.4 Place Path along the River going down from the Road

2. Draw the map
   2.1 Draw the border going around the map
   2.2 Draw Title on centered on top
   2.3 Draw the Road going from left in the middle to right
   2.4 Draw the Forest on the left quarter of the map
   2.5 Draw the Bridge 
   2.6 Draw the River
   2.7 Draw Path along the River going down from the Road
   */

namespace Day_1_4_Mission_Adventure_Map
{
    class Program
    {
        static void Roads(List<int> Road, int width, int height)
        {
            var random = new Random();
            int xRoad = height/2;
            Road.Add(xRoad);
            for(int i = 0; i < width; i++)
            {   
                int chance = random.Next(0,4);
                if((width/4 * 3) - 4 < i && i < (width/4 * 3) + 4)
                {  
                Road.Add(xRoad);
                continue;
                }

                if(chance < 2)
                {
                Road.Add(xRoad);
                continue;
                }

                if(chance == 2)
                {
                    if(xRoad < height/7)
                    {
                    xRoad++;
                    }
                xRoad--;
                Road.Add(xRoad);
                continue;
                }
                
                if(chance == 3)
                {
                    if(xRoad > height/7 * 6)
                    {
                    xRoad--;
                    }
                xRoad++;
                Road.Add(xRoad);
                continue;
                }   
            }
        }

        static void Rivers(List<int> River, int width, int height)
        {
            var random = new Random();
            int xRiver = width/4 * 3;
            River.Add(xRiver);
            for(int i = 0; i < height; i++)
            {   
                int chance = random.Next(0,4);
                if(chance < 2)
                {
                River.Add(xRiver);
                continue;
                }

                if(chance == 2)
                {
                xRiver--;
                River.Add(xRiver);
                continue;
                }
                
                if(chance == 3)
                {
                xRiver++;
                River.Add(xRiver);
                continue;
                }
            }
        }

        static void Paths(int width, int height)
        {

        }   

        static void Walls(int width, int height)
        {

        }

        static void DrawMap(int width, int height)
        {  
            var random = new Random();
            List<int> Road = new List<int> {};
            Roads(Road, width, height);
            
            List<int> River = new List<int> {};
            Rivers(River, width, height);

            List<int> Path = new List<int> {};
            Paths(width, height);
            
            List<int> Wall = new List<int> {};
            Walls(width, height);

            for (int y = 0; y < height+1; y++)
            {
                for (int x = 0; x < width+1; x++)
                {   
                     
        

                    // DRAW BORDER?
                    if (y == 0 || x == 0 || y == height || x == width)
                    {
                        if (y == 0 && x == 0 || y == height && x == 0)
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


                    // DRAW FOREST?
                    if (x == 1 || x < width/4 && x != 0)
                    {
                    int chanceHundred = random.Next(0, 101);
                        if (100/(x*1) >= chanceHundred|| x <= 2)
                        {
                        List<string> treeList = new List<string>{"A", "^", "¤", "Ä", "Å", "Y", "0"};
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(treeList[random.Next(0, treeList.Count)]);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                        }  
                    }

                    // DRAW BRIDGE?
                    if ((y == height/2+1 || y == height/2-1) && (x > (width/4 * 3) - 3 && x < (width/4 * 3) + 5))
                    {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("=");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                    }

                    // DRAW RIVER?
                    if (y != 0 && y != height && x == River[y])
                    {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("~~~");
                    Console.ForegroundColor = ConsoleColor.White;
                    x += 2;
                    continue;
                    }

               

                    // DRAW PATH?
                    if (y > 0 && y > height/2 && x == (width/4 * 3) - 5)
                    {
                    Console.Write("#");
                    continue;
                    }
                
                    // DRAW WALL?
                    
                    if (x == width / 4 && (y == height/2 + 1 || y == height/2 - 1))
                    {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("[]");
                    x += 1;
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                    }

                    if (x == width / 4)
                    {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("||");
                    x += 1;
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                    }

                 
                


                    // DRAW SPACE TO SOCIAL DISTANCING
                     Console.Write(" ");

                }  
            }
           
        }

        static void Main(string[] args)
        {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        int width = 60;
        int height = 20;
        DrawMap(width, height);  
        }
    }
}



        




