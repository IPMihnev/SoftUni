using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int sum = 0;

            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int a = 0; a < matrix.GetLength(0) - 1; a++)
            {
                for (int b = 0; b < matrix.GetLength(1) - 1; b++)
                {
                    int curr = matrix[a, b] + matrix[a, b + 1] + matrix[a + 1, b] + matrix[a + 1, b + 1];

                    if (matrix[a, b] == matrix[a, b + 1] &&
                        matrix[a, b] == matrix[a + 1, b] &&
                        matrix[a, b] == matrix[a + 1, b + 1])
                    {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
