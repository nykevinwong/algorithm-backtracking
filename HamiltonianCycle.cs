using System;

class HamiltonianCycle
{
    static bool IsConnected(int[,] graph, int src, int dest)
    {
        return graph[src,dest]==1;
    }

    static bool IsVisited(int[] path, int v)
    {
        for(int i=0;i<path.Length;i++)
        {
            if(path[i]==-1) return false;
            if(path[i]==v) return true;
        }
        return false;
    }

    static bool IsValidHamiltonianCycle(int[,] graph, int[] path, int pos, int N)
    {
        // base condition
        if(pos==N)
        {
            int endVertex = path[pos-1];
            int startVertex = path[0];
            if(graph[endVertex,startVertex]==1) return true;
            return false;
        }

        int curVertex = path[pos-1];
        for(int v=1;v< N;v++)
        {
            if(IsConnected(graph, curVertex, v) && !IsVisited(path, v))
            {
                path[pos] = v;
                if(IsValidHamiltonianCycle(graph, path, pos+1, N)) return true;
                path[pos]=-1;
            }
        }

        return false;
    }

    static bool IsHamiltonianCycle(int[,] graph)
    {
        int N = graph.GetLength(0);
        int[] path = new int[N];
        for(int i=0;i<N;i++) path[i]=-1;

        path[0]=0;

        if(IsValidHamiltonianCycle(graph, path, 1, N))
        {
            Console.WriteLine(string.Join(",", path)+","+path[0]);
            return true;
        }
         Console.WriteLine("No Solution!!");
        return false;
    }

    static void Main(string[] args)
    {
        int[,] graph = new int[,] {
                {0, 1, 0, 1, 0}, 
                {1, 0, 1, 1, 1}, 
                {0, 1, 0, 0, 1}, 
                {1, 1, 0, 0, 1}, 
                {0, 1, 1, 1, 0}, 
        };

        bool[] visited = new bool[graph.GetLength(1)];

        IsHamiltonianCycle(graph);

    }
}
