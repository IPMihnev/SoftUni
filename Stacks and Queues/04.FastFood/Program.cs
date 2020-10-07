using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int max = int.MinValue;
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (int item in orders)
            {
                if (max < item)
                {
                    max = item;
                }
                queue.Enqueue(item);
            }
            Console.WriteLine(max);
            while (queue.Count != 0)
            {
                if (queue.Peek() <= quantity)
                {
                    int a = queue.Dequeue();
                    quantity -= a;
                }
                else
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
