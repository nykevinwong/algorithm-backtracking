using System;
using System.Collections.Generic;
class Permutate
{
    public static void ListPermutation(char[] str, int start, int end, List<string> l)
    {
        
        if(start==end) { // a list of unique permutation is at the bottom of this n-ary tree call
        //    Console.WriteLine(str);
            l.Add(new string(str));
            return;
        }

        for(int i=start;i< str.Length;i++)
        {
            swap(str, start, i);
            ListPermutation(str, start+1, end, l);
            swap(str, start, i);
       }
    }

    public static void swap(char[] str, int x, int y)
    {
        char temp = str[x];
        str[x]=str[y];
        str[y]=temp;
    }

    static void Main(string[] args)
    {
        char[] str = "ABC".ToCharArray();
        List<string> l = new List<string>();
        ListPermutation(str, 0, str.Length-1, l);

        for(int i=0;i<l.Count;i++)
            Console.WriteLine(l[i]);
    }
}
