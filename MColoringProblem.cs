using System;

public class MColoringProblem
{

    static void PrintMatrix(int[,] graph)
    {
        int h = graph.GetLength(0);
        int w = graph.GetLength(1);

        // header 
        for(int x=0;x<w;x++)
                Console.Write("#{0,2}", x+1);
            Console.WriteLine("#\n");

        for(int y=0;y<h;y++)
        {
            for(int x=0;x<w;x++)
                Console.Write("|{0,2}", graph[y,x]);

            Console.WriteLine("|");
        }
    }

    static bool IsValidColor(int[,] graph, int[] ColorOnVertex, int targetVertex, int targetColor)
    {
        for(int x=0;x<graph.GetLength(0);x++)
        {
            if(graph[targetVertex, x]==1 && ColorOnVertex[x]== targetColor ) // check color of adjacent vertex
                return false;
        }

        return true;
    }

    static bool ColorVertex(int[,] graph, int[] ColorOnVertex, int mColor, int targetVertex)
    {
        if(targetVertex==graph.GetLength(0)) return true;

        for(int c=1;c<=mColor;c++) // zero meand no color filled yet
        {
            ColorOnVertex[targetVertex] = c; // use this color
            if(IsValidColor(graph,ColorOnVertex, targetVertex, c))
            {
                if(ColorVertex(graph, ColorOnVertex, mColor, targetVertex+1))
                    return true;
            }

            ColorOnVertex[targetVertex] = 0;/// backtracking. back to no color fill
        }

        return false;
    }

    static bool FindMColorGraph(int[,] graph, int mColor)
    {
        int nVertex = graph.GetLength(0);
        int[] ColorOnVertex = new int[nVertex];

        if(ColorVertex(graph, ColorOnVertex, mColor, 0))
        {
            Console.WriteLine("\nColors are :");
            for(int i=0;i<nVertex;i++)
            Console.Write("|{0,2}", ColorOnVertex[i]);
            Console.WriteLine("|");
            return true;
        }
        return false;
    }

    static void Main(string[] args)
    {
   /* (3)---(2) 
       |   / | 
       |  /  | 
       | /   | 
      (0)---(1) 
    */
        int[,] graph = new int[4,4]{ 
            {0,1,1,1},
            {1,0,1,0},
            {1,1,0,1},
            {1,0,1,0}
            };

        PrintMatrix(graph);
        if(FindMColorGraph(graph,3))
        Console.WriteLine("exist a solution");
        else 
        Console.WriteLine("no solution");
    }
}
