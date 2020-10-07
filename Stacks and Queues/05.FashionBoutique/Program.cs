using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int cap = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(clothes);
            int racks = 0;
            int sum = 0;

            while (stack.Count > 0)
            {
                var curr = stack.Peek();
                if ((sum + curr) > cap)
                {
                    racks++;
                    sum = 0;
                    continue;
                }
                else if ((sum + curr) == cap)
                {
                    racks++;
                    sum = 0;
                    stack.Pop();
                }
                else
                {
                    sum += stack.Pop();
                }
            }
            if (sum > 0)
            {
                racks++;
            }
            Console.WriteLine(racks);
        }
    }
}
