using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char>(snake);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 != 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = queue.Dequeue();
                        queue.Enqueue(matrix[row, col]);
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = queue.Dequeue();
                        queue.Enqueue(matrix[row, col]);
                    }
                }
            }

            for (int f = 0; f < matrix.GetLength(0); f++)
            {
                for (int g = 0; g < matrix.GetLength(1); g++)
                {
                    Console.Write(matrix[f, g]);
                }
                Console.WriteLine();
            }
        }
    }
}

