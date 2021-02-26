using System;
using System.Collections.Generic;
using System.Globalization;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> info = new SortedDictionary<char, int>();

            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];
                if (!info.ContainsKey(curr))
                {
                    info.Add(curr, 0);
                }
                info[curr]++;
            }
            foreach (var item in info)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
