using System;

namespace Arrays_practice
{
    class Program
    {
    static int tac(char[,] tic,  int empty)
    {
        var Random = new Random();    
        int win = 69;
        int randomC = Random.Next(0,2);
        char current = 'N';    
        if (randomC == 0) current = 'O';
        if (randomC == 1) current = 'X';

        bool one = false;
        bool two = false;
        bool three = false;
        bool four = false;
        bool five = false;
        bool six = false;
        bool seven = false;
        bool eight = false;
        bool nine = false;
    
        tryagain:
        for (int i = 0; i < 99; i++)
        { 
            int randomX = Random.Next(0,3);
            int randomY = Random.Next(0,3);
  
            if((randomX == 0 && randomY == 0) && one == false)
            {
                tic[0,0] = current;
                one = true;
                empty--;
            }

            else if((randomX == 0 && randomY == 1) && two == false)
            {
                tic[0,1] = current;
                two = true;
                empty--;
            }

            else if((randomX == 0 && randomY == 2) && three == false)
            {
                tic[0,2] = current;
                three = true;
                empty--;
            }

            else if((randomX == 1 && randomY == 0) && four == false)
            {
                tic[1,0] = current;
                four = true;
                empty--;
            }

            else if((randomX == 1 && randomY == 1) && five == false)
            {
                tic[1,1] = current;
                five = true;
                empty--;
            }
           
            else if((randomX == 1 && randomY == 2) && six == false)
            {
                tic[1,2] = current;
                six = true;
                empty--;
            }

            else if((randomX == 2 && randomY == 0) && seven == false)
            {
                tic[2,0] = current;
                seven = true;
                empty--;
            }

            else if((randomX == 2 && randomY == 1) && eight == false)
            {
                tic[2,1] = current;
                eight = true;
                empty--;
            }

            else if((randomX == 2 && randomY == 2) && nine == false)
            {
                tic[2,2] = current;
                nine = true;
                empty--;
            }
      
            else
            {
            goto tryagain;
            }
            // VERTICAL
            if
            ((tic[0,0] == 'O' && tic[1,0] == 'O' && tic[2,0] == 'O') || (tic[0,1] == 'O' && tic[1,1] == 'O' && tic[2,1] == 'O') || (tic[0,2] == 'O' && tic[1,2] == 'O' && tic[2,2] == 'O'))
            {
            return
            win = 1;
            }

            // DIAGONAL
            if ((tic[0,0] == 'O' && tic[1,1] == 'O' && tic[2,2] == 'O') || (tic[0,2] == 'O' && tic[1,1] == 'O' && tic[2,0] == 'O'))
            {
            return 
            win = 11;
            }

            // HORIZONTAL
            if ((tic[0,0] == 'O' && tic[0,1] == 'O' && tic[0,2] == 'O') || (tic[1,0] == 'O' && tic[1,1] == 'O' && tic[1,2] == 'O') || (tic[2,0] == 'O' && tic[2,1] == 'O' && tic[2,2] == 'O'))
            {
            return 
            win = 21;
            }

            // VERTICAL
            if ((tic[0,0] == 'X' && tic[1,0] == 'X' && tic[2,0] == 'X') || (tic[0,1] == 'X' && tic[1,1] == 'X' && tic[2,1] == 'X') || (tic[0,2] == 'X' && tic[1,2] == 'X' && tic[2,2] == 'X'))
            {
            return
            win = 2;
            }

            // DIAGONAL
            if ((tic[0,0] == 'X' && tic[1,1] == 'X' && tic[2,2] == 'X') || (tic[0,2] == 'X' && tic[1,1] == 'X' && tic[2,0] == 'X'))
            {
            return
            win = 12;
            }

            // HORIZONTAL
            if ((tic[0,0] == 'X' && tic[0,1] == 'X' && tic[0,2] == 'X') || (tic[1,0] == 'X' && tic[1,1] == 'X' && tic[1,2] == 'X') || (tic[2,0] == 'X' && tic[2,1] == 'X' && tic[2,2] == 'X'))
            {
            return win = 22;
            }


            if ((one == true) && (two == true) && (three == true) && (four == true) && (five == true) && (six == true) && (seven == true) && (eight == true) && (nine == true) && (empty == 0))
            {
            return win = 0;
            }
                
            if(current == 'O')
            {
            current = 'X';
            }

            else if(current == 'X')
            {
            current = 'O';
            }
                

        }
    return win = 0;
    }
        

    static void Recursion(int[,] chess, int chessX, int chessY, int moves)
    {
        if (chessX < 0 || chessX > 7 || chessY < 0 || chessY > 7) 
        {
        return;
        }

        if (chess[chessX, chessY] < moves)
        {
        return;
        }

        chess[chessX, chessY] = moves;

        if (moves > 10) return;
        Recursion(chess, chessX + 1, chessY + 2, moves + 1);
        Recursion(chess, chessX + 1, chessY - 2, moves + 1);
        Recursion(chess, chessX - 1, chessY - 2, moves + 1);
        Recursion(chess, chessX - 1, chessY + 2, moves + 1);

        Recursion(chess, chessX + 2, chessY + 1, moves + 1);
        Recursion(chess, chessX + 2, chessY - 1, moves + 1);
        Recursion(chess, chessX - 2, chessY - 1, moves + 1);
        Recursion(chess, chessX - 2, chessY + 1, moves + 1);
    }
        
    static void Main(string[] args)
    {
        var Random = new Random();
        
        // PART 1
        Console.WriteLine("PART 1");
        // 1
        Console.WriteLine(1);
        string[] weekdays = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};
        Console.Write("Days of the week are: ");
        for (int i = 0; i < weekdays.Length; i++)
            {
            Console.Write(weekdays[i]);
            if (i < weekdays.Length-1) Console.Write(", ");
            }
        Console.WriteLine($"\n\n");


        // 2
        Console.WriteLine(2);
        var today = DateTime.Today;
        var month = new DateTime(today.Year, today.Month, 1);

        int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
        string[] monthdays = new string[daysInMonth];
        
        Console.WriteLine("Days this month are: "); 
        string weekday = month.ToString("dddd");

        for (int i = 0; i < daysInMonth; i++)
            {    
            monthdays[i] = month.ToString("ddd");
            Console.WriteLine($"{i+1}: {monthdays[i]}");
            month = month.AddDays(1);
            }
        Console.WriteLine($"\n\n");
  

        // 3
        Console.WriteLine(3);
        int arrayLength = Random.Next(5,11);
        
        double[] arrayOfDoubles = new double[arrayLength];
        for (int i = 0; i < arrayLength; i++)
            {
            double randomDouble = Random.Next(1,11);
            arrayOfDoubles[i] = randomDouble;
            } 
        Console.WriteLine($"{arrayLength} random numbers are: {string.Join(", ", arrayOfDoubles)}");
        Console.WriteLine($"\n\n");   


        // 4
        Console.WriteLine(4);
        var interpolated = new double[arrayLength * 2 - 1];
        interpolated[0] = arrayOfDoubles[0];
        for (int i = 1; i < arrayLength; i++)
            {
            interpolated[i * 2] = (arrayOfDoubles[i]);
            interpolated[i * 2 - 1] = (arrayOfDoubles[i] + arrayOfDoubles[i-1]) / 2;
            }
        Console.WriteLine($"Interpolated numbers are: {string.Join(", ", interpolated)}");
        Console.WriteLine($"\n\n");



        // PART 2
        Console.WriteLine("PART 2");
        // 1
        Console.WriteLine(1);

        int hor = Random.Next(2,6);
        int ver = Random.Next(2,6);
        int[,] array2D = new int[hor, ver];
        for (int y = 0; y < ver; y++)
        {
            for (int x = 0; x < hor; x++)
            {
            int fil = Random.Next(0,10);
            array2D[x, y] = fil;
            }
        }

        for (int y = 0; y < ver; y++)
        {
            for (int x = 0; x < hor; x++)
            {
            Console.Write(array2D[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\n\n");


        // 2
        int[,] array2Dtransposed = new int[ver, hor];
        Console.WriteLine(2);
        for (int y = 0; y < hor; y++)
        {
            for (int x = 0; x < ver; x++)
            {
            array2Dtransposed[x, y] = array2D[y, x];
            }
        }

        for (int y = 0; y < hor; y++) 
        {
            for (int x = 0; x < ver; x++)   
            {
            Console.Write(array2Dtransposed[x, y]);
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\n\n");

        
        // 3
        Console.WriteLine(3);
        int[,] tenTable = new int[11, 11];
        for (int y = 1; y <= 10; y++)
        {
            for (int x = 1; x <= 10; x++)
            {
            tenTable[x, y] = x * y;
            }
        }

        for (int y = 1; y <= 10; y++) 
        {
            for (int x = 1; x <= 10; x++)   
            {
            Console.Write($"{tenTable[x, y]} ");
            if (x * y < 10) Console.Write(" ");   
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\n\n");

        // 4
        Console.WriteLine(4);
        int[,] chess = new int[8, 8];
        int chessY = Random.Next(0,8); 
        int chessX = Random.Next(0,8);
        int moves = 0;
        
        for (int x = 0; x < 8; x++) 
        {
            for (int y = 0; y < 8; y++)   
            {
            chess[x, y] = int.MaxValue;
            }
        }

        chess[chessX, chessY] = moves;
        Recursion(chess, chessX, chessY, moves);

        for (int y = 0; y < 8; y++) 
        {
            for (int x = 0; x < 8; x++)   
            {
            Console.Write($"{chess[x, y]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\n\n");


        // 5
        Console.WriteLine(5);

        int empty = 9;

        char[,] tic = new char[3, 3];

        for (int y = 0; y < 3; y++)
        {   
            char current = ' ';
            for (int x = 0; x < 3; x++)
            {
            tic[x, y] ='*';
            }
        }
           
        int win = tac(tic, empty);  

        string direction = "error";
        if (win == 1 || win == 2) direction = "vertically";
        if (win == 11 || win == 12) direction = "diagonally";
        if (win == 21 || win == 22) direction = "horizontally";

        char winner = 'n';
        if (win == 1 || win == 11 || win == 21) winner = 'O';
        if (win == 2 || win == 12 || win == 22) winner = 'X';
            

        for (int x = 0; x < 3; x++) 
        {
            for (int y = 0; y < 3; y++)   
            {
                Console.Write($"{tic[x, y]} ");
            }
            Console.WriteLine();
        }

        if (win == 0) Console.WriteLine($"It's a TIE!");
        else Console.WriteLine($"{winner} won {direction}!");

        Console.WriteLine($"\n\n");



        // PART 3
        Console.WriteLine("PART 3");
        // 1
        Console.WriteLine(1);
        int february = DateTime.DaysInMonth(today.Year, 2);
        string[][] year = new string[12][];
        year[0] = new string[31];
        year[1] = new string[february];
        year[2] = new string[31];
        year[3] = new string[30];
        year[4] = new string[31];
        year[5] = new string[30];
        year[6] = new string[31];
        year[7] = new string[31];
        year[8] = new string[30];
        year[9] = new string[31];
        year[10] = new string[30];
        year[11] = new string[31];

        Console.Write("Weekdays this year: ");
            
        var thisToday = DateTime.Today.Month;
        string[] everyDay = new string[daysInMonth];
        
        weekday = month.ToString("ddd");

        string[] weekd = {"M", "T", "W", "T", "F", "S", "S"};
        int cycle = 2;

        for (int i = 0; i < 12; i++)
        {
            int thisMonth = DateTime.DaysInMonth(today.Year, i+1);

            for (int j = 0; j < thisMonth; j++)
            {
            year[i][j] = weekd[cycle];
            cycle++;
            if (cycle == 7) cycle = 0;
            }
        }

        Console.WriteLine();

        int monthLength = 0;
        for (int i = 0; i < 12; i++)
        {
            if (i == 0 || i == 2 || i == 4 || i == 6 || i == 7 || i == 9 || i == 11) monthLength = 31;
            if (i == 3 || i == 5 || i == 8 || i == 10) monthLength = 30;
            if (i == 1) monthLength = february;

            for (int j = 0; j < monthLength; j++)
            {
            Console.Write($"{year[i][j]}");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\n\n");
        

        // 2
        Console.WriteLine(2);

        int people = Random.Next(15, 25);
        string[] players = new string[people];
            
        for(int i = 0; i < people; i++)
        {

        }


        int teams = Random.Next(3, 8);
        string[][] team = new string[teams][];

        for(int i =  1; i < teams+1; i++)
        {
        Console.WriteLine($"Team {i}:");
        }

        double meth = people/teams;
        double methUp = Math.Floor(meth);
        double methDown = Math.Ceiling(meth);
        
        
        for(int i =  1; i < teams+1; i++)
        {
            for(int j =  1; j < teams+1; j++)
            {
            team[i][j] = players[j];
            }
        }

        for(int i =  1; i < teams+1; i++)
        {
            for(int j =  1; j < teams+1; j++)
            {
            Console.WriteLine(team[i][j]);
            }
        }



        /*
        
        Create an array of people, 
        between 15–25 of them.

        Assign a letter of the alphabet to each one (starting at A onwards). 
        Now create between 3–7 teams and distribute the people into the teams as evenly as possible. 
        The result is a jagged array with a list of people for each team.
        Team 1: A, B, C, D, E, F
        Team 2: G, H, I, J, K, L
        Team 3: M, N, O, P, Q
        Team 4: R, S, T, U, V

        */

        Console.WriteLine($"\n\n");
        
        // 3
        Console.WriteLine(3);
        Console.WriteLine($"\n\n");

        // 4
        Console.WriteLine(4);
        Console.WriteLine($"\n\n");

        // 5
        Console.WriteLine(5);
        Console.WriteLine($"\n\n");


        
        
        }
    }
}


/*


Pick a random person from each team to participate in a race.
Contestants: C, L, N, T



Create a football field of random width and height between 3–5. Create a jagged array where each team has a 2D array of characters indicating where in the field a person in the team stands (char[][,]). For each team, place people randomly on the field.
Team 1:
BD.C.
F..E.
...A.

Team 2:
..IG.
....H
.KLJ.

Team 3:
Q....
PNO..
..M..

Team 4:
U....
.T.S.
.V..R



Create a 2D array of booleans indicating if there was any person from any team standing on that place of the field.
####.
#####
.####

 */