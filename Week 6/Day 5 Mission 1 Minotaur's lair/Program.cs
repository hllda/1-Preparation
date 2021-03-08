using System;
using System.IO;
using System.Text.RegularExpressions;
namespace Day_1_Mission_1_Maze_game
{
    class Program
    {
        static int width;
        static int height;
        static char[,] map;

        static int playerX;
        static int playerY;

        static void DrawMap()
        {
            Console.SetCursorPosition(0,0);

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if(x == playerX && y == playerY)
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    else if(map[x,y] == '♦')
                        Console.ForegroundColor = ConsoleColor.Red;

                    else if(map[x,y] == '♣')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    else if(map[x,y] == '♠')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    else
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    Console.Write(map[x,y]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // READ THE FILE
            string mapPath = @"D:\Projects\TheIndieQuest\Week 6\Day 5 Mission 1 Minotaur's lair\MazeLevel.txt";
            string mapText = File.ReadAllText(mapPath);

            // DIVIDE FILE INTO SEPARATE LINES
            string[] mapLines = mapText.Split('\n');

            // GET LEVEL NAME FROM FIRST LINE
            string levelName = mapLines[0];

            // GET THE MAP SIZE FROM THE SECOND LINE
            string patternSize = @"(\d+)x(\d+)";
            Match Size = Regex.Match(mapLines[1],patternSize);
            width = Int32.Parse(Size.Groups[1].ToString());
            height = Int32.Parse(Size.Groups[2].ToString());

            // TURN THE LINES WITH THE MAP INTO SEPARATE CHARS
            map = new char[width,height];

            // ASSIGNS THE CHARACTHERS TO A 2D ARRAY AND SKIPS THE FIRST TWO LINES
            for(int y = 0; y < height; y++)
            {
                char[] mapChara = mapLines[y+2].ToCharArray();

                for(int x = 0; x < width; x++)
                {
                    map[x,y] = mapChara[x];

                    if(map[x,y] == 'S')
                    {
                        playerX = x;
                        playerY = y;

                        map[x,y] = ' ';
                    }
                }
            }

            // ASSIGN SPECIAL SYMBOLS TO ARRAYS
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    // PLAYER?
                    if(x == playerX && y == playerY)
                    {
                        map[x,y] = '☻';
                    }

                    // MINOTAUR?
                    else if(map[x,y] == 'M')
                    {
                        map[x,y] = '♦';
                    }

                    // CAN WE DRAW A TREE?
                    else if(y < 3)
                    {
                        var Random = new Random();
                        int random = Random.Next(0,10);

                        // WILL WE DRAW A TREE?
                        if(random < 2 -(y^y))
                        {
                            // WHAT KIND OF TREE?
                            int type = Random.Next(0,2);
                            if(type == 0)
                                map[x,y] = '♣';

                            else
                                map[x,y] = '♠';
                        }
                    }
                }
            }

            // DRAW THE MAP
            DrawMap();
        }
    }
}