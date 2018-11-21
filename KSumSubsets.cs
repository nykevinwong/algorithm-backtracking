using System;
using System.Collections.Generic;

class KSumSubsets
{
    static void SolveKSumSubsets(int[] w, int start, int end, Stack<int> s, int k, int sum)
    {
        if(s.Count > 0)
        {
            foreach (int x in s.ToArray())
            {
                Console.Write("|{0,2}",x);
            }

            if(k==sum)
              Console.WriteLine("| => this equals to "+ k);            
            else Console.WriteLine("|");
        }

        for(int i=start;i<=end;i++)
        {
            s.Push(w[i]);
            SolveKSumSubsets(w, i+1, end, s, k, sum+w[i]);
            s.Pop();
        }
    }
    static void Main(string[] args)
    {
        int[] w = new int[]{1,2,3,4};
        SolveKSumSubsets(w, 0, w.GetLength(0)-1, new Stack<int>(), 4,0);

    }

}