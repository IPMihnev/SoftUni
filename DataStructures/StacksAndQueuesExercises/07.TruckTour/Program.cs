using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> circle = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}";
                circle.Enqueue(input);
            }
            int totalF = 0;
            for (int i = 0; i < n; i++)
            {
                string current = circle.Dequeue();
                var info = current.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var fuel = info[0];
                var dist = info[1];
                totalF += fuel;
                if (totalF >= dist)
                {
                    totalF -= dist;
                }
                else
                {
                    totalF = 0;
                    i = -1;
                }
                circle.Enqueue(current);
            }
            var firstEll = circle.Dequeue().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Console.WriteLine(firstEll[2]);
        }
    }
}
