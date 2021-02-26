using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsofElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            HashSet<int> final = new HashSet<int>();
            int[] lenght = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = lenght[0];
            int m = lenght[1];
            for (int i = 0; i < n; i++)
            {
                int curr = int.Parse(Console.ReadLine());
                set1.Add(curr);
            }
            for (int i = 0; i < m; i++)
            {
                int curr = int.Parse(Console.ReadLine());
                set2.Add(curr);
            }
            foreach (var num in set1)
            {
                if (set2.Contains(num))
                {
                    final.Add(num);
                }
            }
            Console.WriteLine(String.Join(" ", final));
        }
    }
}
