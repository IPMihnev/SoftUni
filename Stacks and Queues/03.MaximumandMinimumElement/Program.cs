using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();
            int count = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;
            for (int i = 0; i < count; i++)
            {
                string curr = Console.ReadLine();
                if (curr.Contains("1"))
                {
                    int[] comm = curr.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    stack.Push(comm[1]);
                }
                else if (curr == "2")
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    stack.Pop();
                }
                else if (curr == "3")
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    foreach (var item in stack)
                    {
                        if (max < item)
                        {
                            max = item;
                        }
                    }
                    Console.WriteLine(max);
                    max = 0;
                }
                else if (curr == "4")
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    foreach (var item in stack)
                    {
                        if (min > item)
                        {
                            min = item;
                        }
                    }
                    Console.WriteLine(min);
                    min = 0;
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}
