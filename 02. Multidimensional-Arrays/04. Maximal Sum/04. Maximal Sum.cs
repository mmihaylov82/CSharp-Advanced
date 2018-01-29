using System;
using System.Linq;

namespace _04.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            int[,] matrix = new int[rows, columns];

            PopulateMatrix(matrix, rows, columns);

            int maxSum = 0;
            int[] maxSumIndex = new int[2];

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < columns - 2; col++)
                {
                    int currentMaxSum = 0;

                    for (int i = row; i <= row + 2; i++)
                    {
                        for (int j = col; j <= col + 2; j++)
                        {
                            currentMaxSum += matrix[i, j];
                        }
                    }

                    if (currentMaxSum > maxSum)
                    {
                        maxSumIndex[0] = row;
                        maxSumIndex[1] = col;
                        maxSum = currentMaxSum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxSumIndex[0]; i <= maxSumIndex[0] + 2; i++)
            {
                for (int j = maxSumIndex[1]; j <= maxSumIndex[1] + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void PopulateMatrix(int[,] matrix, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = inputArgs[col];
                }
            }
        }
    }
}