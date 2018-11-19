using System;

public class NQueen
{

    public static void initBoard(char[,] board)
    {
        int height = board.GetLength(0);
        int width = board.GetLength(1);

        for(int i=0;i<height;i++)
            for(int j=0;j<width;j++)
                board[i,j] = '.';

    }

    public static void printBoard(char[,] board)
    {
        int height = board.GetLength(0);
        int width = board.GetLength(1);

        for(int i=0;i<height;i++)
        {
            if(i==0)
            {
                for(int j=0;j<width;j++)
                    Console.Write(j);
                    Console.WriteLine();
            }

        for(int j=0;j<width;j++)
            Console.Write(board[i,j]);
            Console.WriteLine();
        }

    }

    public static bool isAttacked(char[,] board, int x, int y)
    {
        // assume height = width
        int N = board.GetLength(0);

        // check row
        for(int j=0;j<N;j++)
            if(board[y,j]=='Q') return true;

        // check column
        for(int j=0;j<N;j++)
            if(board[j,x]=='Q') return true;

        // upper-left to lower-right diagonal
        for(int j=0;j<N;j++)
            if(board[j,j]=='Q') return true;

        // upper-right to lower-left diagonal
        for(int j=0;j<N;j++)
            if(board[N-j-1,j]=='Q') return true;

            return false;
    }

    public static bool solveNQueen(char[,] board, int n)
    {
        int height = board.GetLength(0);
        int width = board.GetLength(1);
        // base case/terminating case
        if(n==0) return true; // solve all solution already

        for(int i=0;i<height;i++)
            for(int j=0;j<width;j++)
            {
                Console.WriteLine("step {0} is checking attackable at ({1},{2}).", n, j, i);
                if(isAttacked(board, j,i)) continue;
                Console.WriteLine("step {0} => NOT attackable ({1},{2}).", n, j, i);
                // now it is a unattackable cell
                board[i,j] = 'Q'; // place a queen
                if(solveNQueen(board, n-1)) // place next n Q
                    return true;
                board[i,j] = '.'; // backtracking/restoring this step and try next step.
            }

            return false;
    }

    static void Main(string[] args)
    {
        int N = 4;
        char[,] board = new char[N,N];
        initBoard(board);
        printBoard(board);

        if(solveNQueen(board,N))
        {
            Console.WriteLine("found one solution:");
            printBoard(board);
        }
        else
        {
            Console.WriteLine("found no solution:");
        }
    }
}
