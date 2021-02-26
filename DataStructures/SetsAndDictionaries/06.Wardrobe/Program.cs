using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] currColor = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = currColor[0];
                string[] clothes = currColor[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int g = 0; g < clothes.Length; g++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[g]))
                    {
                        wardrobe[color].Add(clothes[g], 0);
                    }
                    wardrobe[color][clothes[g]]++;
                }
            }
            string[] dress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorDress = dress[0];
            string clothesDress = dress[1];
            foreach (var colorInWardrobe in wardrobe)
            {
                Console.WriteLine($"{colorInWardrobe.Key} clothes:");
                foreach (var cloth in colorInWardrobe.Value)
                {
                    if (colorInWardrobe.Key == colorDress && cloth.Key == clothesDress)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
