using System;

class RatInMaze
{
    static void PrintMaze(int[,] maze)
    {
        int h = maze.GetLength(0);
        int w = maze.GetLength(1);

        for(int y=0;y<h;y++)
        {
            for(int x=0;x<w;x++)
                Console.Write("|{0,2}", maze[y,x]);

            Console.Write("|");
            Console.WriteLine();
        }
    }

    static bool IsValidMove(int[,] maze, int x, int y)
    {
        int h = maze.GetLength(0);
        int w = maze.GetLength(1);
        return ( x>=0 && x < w && y>=0 && y < h) && maze[y,x]==0; 
    }

    static bool SolveRatMaze(int[,] maze, int x, int y, int dx, int dy, int step)
    {
        int[,] move= new int[4,2] { {0,-1},{0,1},{-1,0},{1,0} };

        if(x==dx && y==dy) return true;

        maze[y,x] = step;
        for(int i=0; i < 4;i++)
        {
            int nextX = x + move[i,0];
            int nextY = y + move[i,1];
            
            if(IsValidMove(maze, nextX, nextY))
            {
                int nextStep = maze[y,x]+1;
                maze[nextY,nextX] = nextStep; 
                if(SolveRatMaze(maze, nextX, nextY, dx, dy, nextStep)) return true; 
                maze[nextY,nextX] = 0; // backtracking
            }            
        }

        return false;
    }

    static void Main(string[] agrv)
    {
        int[,] maze = new int[4,4] {
            {0,-1,-1,-1},
            {0,0,-1,0},
            {-1,0,0,-1},
            {0,0,0,0},
        };

        if(SolveRatMaze(maze, 0,0, 3,3, 1) ) PrintMaze(maze);
        else Console.WriteLine("No Solution!!");
    }
}