using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] currElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var curr in currElements)
                {
                    elements.Add(curr);
                }
            }
            Console.WriteLine(String.Join(" ", elements));
        }
    }
}
