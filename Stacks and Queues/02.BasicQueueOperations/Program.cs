using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int smallest = int.MaxValue;
            for (int i = 0; i < commands[0]; i++)
            {
                queue.Enqueue(nums[i]);
            }
            for (int i = 0; i < commands[1]; i++)
            {
                queue.Dequeue();
            }
            bool rule = queue.Contains(commands[2]);
            if (rule == true)
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    foreach (var item in queue)
                    {
                        if (item < smallest)
                        {
                            smallest = item;
                        }
                    }
                    Console.WriteLine(smallest);
                }
            }
        }
    }
}
