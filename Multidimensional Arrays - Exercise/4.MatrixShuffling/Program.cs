using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandParts = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandParts.Length < 5 || commandParts.Length > 5 || commandParts[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int x1 = int.Parse(commandParts[1]);
                int x2 = int.Parse(commandParts[2]);
                int x3 = int.Parse(commandParts[3]);
                int x4 = int.Parse(commandParts[4]);

                if (x1 < 0 || x1 > rows - 1 || x2 < 0 || x2 > cols - 1 ||
                    x3 < 0 || x3 > rows - 1 || x4 < 0 || x4 > cols - 1)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                var temp = matrix[x1, x2];
                matrix[x1, x2] = matrix[x3, x4];
                matrix[x3, x4] = temp;

                for (int a = 0; a < matrix.GetLength(0); a++)
                {
                    for (int d = 0; d < matrix.GetLength(1); d++)
                    {
                        Console.Write(matrix[a, d] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
