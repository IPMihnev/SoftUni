using System;
using System.Collections.Generic;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[][] pascal = new long[n][];
            long cols = 1;
            for (long row = 0; row < n; row++)
            {
                pascal[row] = new long[cols];
                pascal[row][0] = 1;
                pascal[row][pascal[row].Length - 1] = 1;
                if (row > 1)
                {
                    for (long col = 1; col < pascal[row].Length - 1; col++)
                    {
                        long[] prevRow = pascal[row - 1];
                        long first = prevRow[col];
                        long second = prevRow[col - 1];
                        pascal[row][col] = first + second;
                    }
                }
                cols++;
            }
            for (long row = 0; row < pascal.Length; row++)
            {
                for (long col = 0; col < pascal[row].Length; col++)
                {

                    Console.Write(pascal[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
