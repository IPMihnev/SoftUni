using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Stack<char> stack = new Stack<char>();


            for (int i = 0; i < text.Length; i++)
            {
                var symbol = text[i];

                if (stack.Any())
                {
                    if (symbol == '}' && stack.Peek() == '{')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (symbol == ')' && stack.Peek() == '(')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (symbol == ']' && stack.Peek() == '[')
                    {
                        stack.Pop();
                        continue;
                    }
                }

                stack.Push(symbol);
            }

            Console.WriteLine(!stack.Any() ? "YES" : "NO");

        }
    }
}
