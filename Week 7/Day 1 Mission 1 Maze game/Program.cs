using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Day_1_Mission_1_Maze_game
{
    class Program
    {
        static int width;
        static int height;
        static char[,] map;

        static int playerX;
        static int playerY;

        static int minotaurX;
        static int minotaurY;

        static string levelName;

        static void DrawTitle()
        {
            Console.WriteLine($"Welcome {Environment.UserName}!");
            Console.WriteLine($"Get ready for: {levelName}");
            Console.Write("\nPress any key to start");
            Console.ReadKey();
            Console.CursorVisible = false;
        }

        static void DrawMap()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0,0);

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if(x == playerX && y == playerY)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('☻');
                        continue;
                    }
                    else if(x == minotaurX && y == minotaurY)
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
            string mapPath = @"D:\Projects\TheIndieQuest\Week 7\Day 1 Mission 1 Maze game\MazeLevel.txt";
            string mapText = File.ReadAllText(mapPath);

            // DIVIDE FILE INTO SEPARATE LINES
            string[] mapLines = mapText.Split('\n');
            // GET LEVEL NAME FROM FIRST LINE
            levelName = mapLines[0];

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

                    if(map[x,y] == 'M')
                    {
                        minotaurX = x;
                        minotaurY = y;
                    }
                }
            }

            // ASSIGN SYMBOLS TO ARRAYS
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    // MINOTAUR?
                    if(map[x,y] == 'M')
                    {
                        map[x,y] = '♦';
                    }

                    // CAN WE DRAW A TREE?
                    else if(y < 3 && (x != playerX || y != playerY))
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
            DrawTitle();
            DrawMap();
            ConsoleKey move;
            bool win = false;
            do
            {
                move = Console.ReadKey().Key;
                try
                {
                    if(move == ConsoleKey.UpArrow && (map[playerX,playerY-1] == ' ' || map[playerX,playerY-1] == '♦'))
                    {

                        playerY--;
                    }

                    else if(move == ConsoleKey.DownArrow && (map[playerX,playerY+1] == ' ' || map[playerX,playerY+1] == '♦'))
                    {
                        playerY++;
                    }

                    else if(move == ConsoleKey.LeftArrow && (map[playerX-1,playerY] == ' ' || map[playerX-1,playerY] == '♦'))
                    {
                        playerX--;
                    }

                    else if(move == ConsoleKey.RightArrow && (map[playerX+1,playerY] == ' ' || map[playerX+1,playerY] == '♦'))
                    {
                        playerX++;
                    }

                    DrawMap();

                    if(minotaurX == playerX && minotaurY == playerY)
                    {
                        win = true;
                    }
                }

                catch
                {
                
                }


            } while(move != ConsoleKey.Escape && (win != true));

            if(win == true)
                Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n You reached the minotaur! You won!");
            Thread.Sleep(1000);
            Console.WriteLine("\n\n Press any key to exit.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
    }
}