using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            decimal[][] arr = new decimal[n][];

            for (int row = 0; row < arr.Length; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
                arr[row] = new decimal[input.Length];
                for (int col = 0; col < arr[row].Length; col++)
                {
                    arr[row][col] = input[col];
                }
            }
            for (int g = 0; g < arr.Length - 1; g++)
            {
                if (arr[g].Length == arr[g + 1].Length)
                {
                    for (int f = 0; f < arr[g].Length; f++)
                    {
                        arr[g][f] *= 2;
                        arr[g + 1][f] *= 2;
                    }
                }
                else
                {
                    for (int f = 0; f < arr[g].Length; f++)
                    {
                        arr[g][f] /= 2;
                    }
                    for (int h = 0; h < arr[g + 1].Length; h++)
                    {
                        arr[g + 1][h] /= 2;
                    }
                }
            }
            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] comm = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(comm[1]);
                int col = int.Parse(comm[2]);
                decimal value = decimal.Parse(comm[3]);

                if (row < 0 || row >= arr.Length ||
                    col < 0 || col >= arr[row].Length)
                {
                    continue;
                }
                if (comm[0] == "Add")
                {
                    arr[row][col] += value;
                }
                else if (comm[0] == "Subtract")
                {
                    arr[row][col] -= value;
                }
            }
            for (int b = 0; b < arr.Length; b++)
            {
                Console.Write(string.Join(" ", arr[b]));
                Console.WriteLine();
            }
        }
    }
}
