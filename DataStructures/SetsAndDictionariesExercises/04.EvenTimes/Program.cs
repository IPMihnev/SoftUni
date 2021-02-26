using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> evenTimes = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int curr = int.Parse(Console.ReadLine());
                if (!evenTimes.ContainsKey(curr))
                {
                    evenTimes.Add(curr, 0);
                }
                evenTimes[curr]++;
            }
            foreach (var num in evenTimes)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}
