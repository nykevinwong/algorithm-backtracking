
using System;
using System.Collections.Generic;

class FindOneSubsetSum
{

    public static bool FindSubsetEqualToK(int[] w, int targetSum, int curItemIndex)
    {
        
        if(targetSum==0) return true;
        if(curItemIndex >= w.GetLength(0)) return false; 
        int curItemValue = w[curItemIndex];

        // include this current item
        if(FindSubsetEqualToK(w, targetSum - curItemValue, curItemIndex+1)) 
        {
            Console.Write("w[{0}]={1},", curItemIndex, curItemValue);
            return true;
        }

        // exclude this current item
        if(FindSubsetEqualToK(w, targetSum, curItemIndex+1)) 
        {           
            return true;
        }

        return false;
    }

    public static bool GetSubsetEqualToK(int[] w, int targetSum, int curItemIndex, List<int> l)
    {
        
        if(targetSum==0) return true;
        if(curItemIndex >= w.GetLength(0)) return false; 
        int curItemValue = w[curItemIndex];

        // include this current item
        if(GetSubsetEqualToK(w, targetSum - curItemValue, curItemIndex+1,l)) 
        {
            l.Add(curItemValue);
            return true;
        }

        // exclude this current item
        if(GetSubsetEqualToK(w, targetSum, curItemIndex+1,l)) 
        {           
            return true;
        }

        return false;
    }

    static void Main(string[] argv)
    {
        int[] w = new int[] {1,2,3,4,5,6,7,8,9,10};
        int target = 22;
        Console.WriteLine("targetSum = {0}", target);
        FindSubsetEqualToK(w, target, 0);
        List<int> l = new List<int>();
        GetSubsetEqualToK(w, target, 0, l);

        Console.WriteLine("\n\nthe subset equal to targetSum:");
        int sum = 0;
        foreach(int x in l.ToArray())
        {
            Console.Write(x +",");
            sum+=x;
        }

        Console.Write("=>  Sum = " + sum);
    }
}
