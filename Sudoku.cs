using System;

public class Sudoku
{
    static bool isValidValue(int[,] matrix, int x, int y, int value)
    {
        for(int i=0;i<9;i++)
            if(matrix[y,i]==value) return false;

        for(int i=0;i<9;i++)
            if(matrix[i,x]==value) return false;

        return true;
    }

    static bool solveSudoku(int[,] matrix)
    {
        int h = matrix.GetLength(0);
        int w = matrix.GetLength(1);

        if(matrix[h-1,w-1]!=0) return true; // if the last element is corretly filled/solved!!
        
        

        for(int y=0;y < h;y++)
            for(int x=0;x < w;x++)
            {
                if(matrix[y,x]==0)
                {
                    for(int i=1;i<=9;i++)
                    {
                        if(i==1) Console.WriteLine("Currently solving ({0},{1}) => assign value {2}... ", y,x, i);
                        if(isValidValue(matrix,x,y, i))
                        {
                            matrix[y,x]=i;
                            if(solveSudoku(matrix))
                                return true;
                            matrix[y,x]=0;
                        }
                    }
                    
                    return false; // try all 1-9 number and it's not working
                }
            }

            return false;
    }

    static void Print(int[,] matrix)
    {
        int h = matrix.GetLength(0);
        int w = matrix.GetLength(1);

        for(int y=0;y < h;y++)
        {
            for(int x=0;x < w;x++)
                Console.Write("|{0,2}", matrix[y,x]);
            Console.WriteLine("|");
        }
    }

    static void Main(string[] args)
    {
        int[,] matrix = new int[9,9]{
                      {3, 0, 6, 5, 0, 8, 4, 0, 0}, 
                      {5, 2, 0, 0, 0, 0, 0, 0, 0}, 
                      {0, 8, 7, 0, 0, 0, 0, 3, 1}, 
                      {0, 0, 3, 0, 1, 0, 0, 8, 0}, 
                      {9, 0, 0, 8, 6, 3, 0, 0, 5}, 
                      {0, 5, 0, 0, 9, 0, 6, 0, 0}, 
                      {1, 3, 0, 0, 0, 0, 2, 5, 0}, 
                      {0, 0, 0, 0, 0, 0, 0, 7, 4}, 
                      {0, 0, 5, 2, 0, 6, 3, 0, 0}}; 

        if(solveSudoku(matrix))
        {
            Print(matrix);
        }
        else
        {
            Console.WriteLine("No solution is found");
        }
    }
}
