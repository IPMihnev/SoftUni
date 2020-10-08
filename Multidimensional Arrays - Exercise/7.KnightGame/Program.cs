using System;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            char[,] chessboard = new char[n, n];
            FillMatrix(chessboard);
            int replaced = 0;
            int rowKill = 0;
            int colKill = 0;
            while (true)
            {
                int maxAtt = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char currSymb = chessboard[row, col];
                        int countAtt = 0;
                        if (currSymb == 'K')
                        {
                            countAtt = GetAttacks(chessboard, row, col, countAtt);
                            if (countAtt > maxAtt)
                            {
                                maxAtt = countAtt;
                                rowKill = row;
                                colKill = col;
                            }
                        }
                    }
                }
                if (maxAtt > 0)
                {
                    chessboard[rowKill, colKill] = '0';
                    replaced++;
                }
                else
                {
                    Console.WriteLine(replaced);
                    break;
                }
            }
        }

        private static int GetAttacks(char[,] chessboard, int row, int col, int countAtt)
        {
            if (IsInside(chessboard, row - 2, col + 1) && chessboard[row - 2, col + 1] == 'K')
            {
                countAtt++;
            }
            if (IsInside(chessboard, row - 2, col - 1) && chessboard[row - 2, col - 1] == 'K')
            {
                countAtt++;
            }
            if (IsInside(chessboard, row + 1, col + 2) && chessboard[row + 1, col + 2] == 'K')
            {
                countAtt++;
            }
            if (IsInside(chessboard, row + 1, col - 2) && chessboard[row + 1, col - 2] == 'K')
            {
                countAtt++;
            }
            if (IsInside(chessboard, row - 1, col + 2) && chessboard[row - 1, col + 2] == 'K')
            {
                countAtt++;
            }
            if (IsInside(chessboard, row - 1, col - 2) && chessboard[row - 1, col - 2] == 'K')
            {
                countAtt++;
            }
            if (IsInside(chessboard, row + 2, col - 1) && chessboard[row + 2, col - 1] == 'K')
            {
                countAtt++;
            }
            if (IsInside(chessboard, row + 2, col + 1) && chessboard[row + 2, col + 1] == 'K')
            {
                countAtt++;
            }

            return countAtt;
        }

        private static void FillMatrix(char[,] nums)
        {
            for (int row = 0; row < nums.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < nums.GetLength(1); col++)
                {
                    nums[row, col] = input[col];
                }
            }
        }

        private static bool IsInside(char[,] chessboard, int targerRow, int targetCol)
        {
            return targerRow >= 0 && targerRow < chessboard.GetLength(0) &&
                targetCol >= 0 && targetCol < chessboard.GetLength(1);
        }
    }
}
