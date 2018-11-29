using System;

public class SpeedSudoku
{
    static bool isValidValue(int[,] matrix, int x, int y, int value)
    {
        for(int i=0;i<9;i++)
            if(matrix[y,i]==value) return false;

        for(int i=0;i<9;i++)
            if(matrix[i,x]==value) return false;

        return true;
    }

    static bool solveSudoku(int[,] matrix, int[,] zeroCellPositions, int pos, int zeroCount)
    {
        int h = matrix.GetLength(0);
        int w = matrix.GetLength(1);

        if(zeroCount==0) return true; // all cells containing zero are filled.
        

        int y = zeroCellPositions[pos,0];
        int x = zeroCellPositions[pos,1];
        

        for(int i=1;i<=9;i++)
        {
            if(isValidValue(matrix,x,y, i))
            {
                matrix[y,x]=i;
                zeroCount--;
                if(solveSudoku(matrix, zeroCellPositions, pos+1, zeroCount))
                    return true;
                matrix[y,x]=0;
                zeroCount++;
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

    static int getCount(int[,] matrix, int target)
    {
        int h = matrix.GetLength(0);
        int w = matrix.GetLength(1);
        int count = 0;

        for(int y=0;y < h;y++)
            for(int x=0;x < w;x++)
                if(matrix[y,x]==target) count++;

                return count;
    }

    static int[,] getUnsolvedPositions(int[,] matrix,  int zeroCount)
    {
        int h = matrix.GetLength(0);
        int w = matrix.GetLength(1);
        int[,] zeroCellPositions = new int [zeroCount,2];
        int c= 0;

        for(int y=0;y < h;y++)
            for(int x=0;x < w;x++)
                if(matrix[y,x]==0) 
                {
                    zeroCellPositions[c,0] = y;
                    zeroCellPositions[c,1] = x;
                    c++;
                }

        return zeroCellPositions;
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
                      {0, 0, 5, 2, 0, 6, 3, 0, 7}};  // the last cell is 7, which takes a lot longer to resolve
        int zeroCount = getCount(matrix,0); // get all zero count. this is to improve performance
        int[,] zeroCellPositions = getUnsolvedPositions(matrix, zeroCount);
        if(solveSudoku(matrix, zeroCellPositions, 0,  zeroCount))
        {
            Print(matrix);
        }
        else
        {
            Console.WriteLine("No solution is found");
        }
    }
}
