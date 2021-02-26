using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] info = input.Split(", ");
                string name = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);

                if (!shops.ContainsKey(name))
                {
                    shops.Add(name, new Dictionary<string, double>());
                }

                if (!shops[name].ContainsKey(product))
                {
                    shops[name].Add(product, price);
                }
            }

            shops = shops.OrderBy(x => x.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
