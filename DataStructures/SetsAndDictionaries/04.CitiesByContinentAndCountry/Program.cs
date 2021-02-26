using System;
using System.Collections.Generic;

namespace _04.Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> geo = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!geo.ContainsKey(continent))
                {
                    geo.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!geo[continent].ContainsKey(country))
                {
                    geo[continent].Add(country, new List<string>());
                }
                geo[continent][country].Add(city);
            }
            foreach (var item in geo)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var part in item.Value)
                {
                    Console.WriteLine($"{part.Key} -> {string.Join(", ", part.Value)}");
                }
            }
        }
    }
}
