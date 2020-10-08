using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int resultA = 0;
            int resultB = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                resultA += matrix[y, y];
                resultB += matrix[y, matrix.GetLength(0) - 1 - y];
            }
            Console.WriteLine(Math.Abs(resultA - resultB));
        }
    }
}
