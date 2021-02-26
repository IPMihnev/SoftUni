using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int curr = int.MaxValue;
            for (int i = 0; i < commands[0]; i++)
            {
                stack.Push(nums[i]);
            }
            for (int i = 0; i < commands[1]; i++)
            {
                stack.Pop();
            }
            bool rule = stack.Contains(commands[2]);
            if (rule == true)
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    foreach (var item in stack)
                    {
                        if (item < curr)
                        {
                            curr = item;
                        }
                    }
                    Console.WriteLine(curr);
                }
            }
        }
    }
}
