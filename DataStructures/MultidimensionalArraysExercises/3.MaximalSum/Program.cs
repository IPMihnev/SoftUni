using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];
            long sum = long.MinValue;
            int index1 = 0;
            int index2 = 0;
            int index3 = 0;
            int index4 = 0;
            int index5 = 0;
            int index6 = 0;
            int index7 = 0;
            int index8 = 0;
            int index9 = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int a = 0; a < matrix.GetLength(0) - 2; a++)
            {
                for (int b = 0; b < matrix.GetLength(1) - 2; b++)
                {
                    int curr = matrix[a, b] + matrix[a, b + 1] + matrix[a, b + 2] +
                        matrix[a + 1, b] + matrix[a + 1, b + 1] + matrix[a + 1, b + 2] +
                        matrix[a + 2, b] + matrix[a + 2, b + 1] + matrix[a + 2, b + 2];
                    if (sum < curr)
                    {
                        sum = curr;
                        index1 = matrix[a, b];
                        index2 = matrix[a, b + 1];
                        index3 = matrix[a, b + 2];
                        index4 = matrix[a + 1, b];
                        index5 = matrix[a + 1, b + 1];
                        index6 = matrix[a + 1, b + 2];
                        index7 = matrix[a + 2, b];
                        index8 = matrix[a + 2, b + 1];
                        index9 = matrix[a + 2, b + 2];
                    }
                }
            }
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine(index1 + " " + index2 + " " + index3);
            Console.WriteLine(index4 + " " + index5 + " " + index6);
            Console.WriteLine(index7 + " " + index8 + " " + index9);
        }
    }
}
