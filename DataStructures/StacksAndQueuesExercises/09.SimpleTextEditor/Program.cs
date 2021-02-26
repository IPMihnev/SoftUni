using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            for (long i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 0)
                {
                    continue;
                }
                long comm = long.Parse(input[0]);

                if (comm == 1)
                {
                    stack.Push(text.ToString());
                    text.Append(input[1]);
                }
                else if (comm == 2)
                {
                    int times = int.Parse(input[1]);
                    stack.Push(text.ToString());
                    text.Remove(text.Length - times, times);
                }
                else if (comm == 3)
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text.ToString().ElementAt(index - 1));
                }
                else if (comm == 4)
                {
                    text = new StringBuilder(stack.Pop());
                }
            }
        }
    }
}
