using System;

class KnightsTour
{

    static void SolveKTMain(int[,] boards)
    {
        int h= boards.GetLength(0);
        int w= boards.GetLength(1);
        int n = h; // assume w=h always
        int solutionCount = 0;

        for(int y=0;y<h;y++)
        {
            for(int x=0;x<w;x++)        
            {
                boards[y,x] = 1;
                if(SolveKT(boards, x,y))
                {
                    Console.WriteLine("solution found for starting point({0},{1})", x, y);
                    PrintBoard(boards);
                    solutionCount++;
                    ResetBoard(boards); // reset the board
                    continue; // check next solution
                } 
                else
                {
                      Console.WriteLine("NO SOLUTION for starting point({0},{1})", x, y);
                }
                // backtracking
                // reset the whole board
                ResetBoard(boards);  // implicitly reset boards[my,mx] = 0;

            }
        }

        Console.WriteLine("Total Soulution Found: {0}, No-Solution Count: {1}", solutionCount, n*n-solutionCount);
    }

    static bool SolveKT(int[,] boards, int x, int y)
    {
        int[,] knightMoves = new int[8,2] {
            {1,-2}, {2,-1}, // Quadrant I
            {-1,-2}, {-2,-1}, // Quadrant II
            {1, 2}, {2, 1},// Quadrant IV
            {-1,2}, {-2,1}, // Quadrant III
        };
        int h= boards.GetLength(0);
        int w= boards.GetLength(1);
        int n = w; // assume w=h
        
        // if the current position has the step count that is equal to the n*n, this is the solution
        if(boards[y,x]==n*n) return true;

        for(int i=0;i< knightMoves.GetLength(0);i++)
        {
            int mx = x + knightMoves[i,0];
            int my = y + knightMoves[i,1];
            if(isValidMove(boards, mx,my)) 
            {
                int step = boards[y,x]+1;
                boards[my,mx] = step;
                if(SolveKT(boards, mx, my)) return true;
                boards[my,mx]  = 0; // backtracking
            }
        }

        return false; // no solution found
    }

    static void PrintBoard(int [,] boards)
    {
        int h= boards.GetLength(0);
        int w= boards.GetLength(1);
        Console.WriteLine("board size: {0}x{1}", w,h);
        for(int y=0;y<h;y++)
        {
            for(int x=0;x<w;x++)
            Console.Write("|{0,2:0}", boards[y,x]);
            Console.Write("|");
            Console.WriteLine();
        }
    }

    static void ResetBoard(int [,] boards)
    {
        int h= boards.GetLength(0);
        int w= boards.GetLength(1);
        for(int y=0;y<h;y++)
            for(int x=0;x<w;x++)
            boards[y,x] = 0;
    }

    static bool isValidMove(int [,] boards, int x, int y)
    {
        int h= boards.GetLength(0);
        int w= boards.GetLength(1);
        // boundary check and valid cell check
        return (x >=0 && x < w && y >=0 && y < h) && boards[y,x]==0; // 0 means no move occured on this cell yet.
    }

    static void Main(string[] argv)
    {
        int N = 5;
        int[,] boards = new int[N,N];

        Console.WriteLine("Original Board:");
        PrintBoard(boards);

        SolveKTMain(boards);
    }
}
