using System;
using System.Linq;

namespace _02.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            
            int[,] matrix = new int[n, n];

            PopulateMatrix(matrix, n);

            int sumFirstDiagonal = 0;
            int sumSecondDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                sumFirstDiagonal += matrix[i, i];
                sumSecondDiagonal += matrix[i, n - 1 - i];
            }

            int diagAbsoluteDiff = Math.Abs(sumFirstDiagonal - sumSecondDiagonal);
            Console.WriteLine(diagAbsoluteDiff);
        }

        private static void PopulateMatrix(int[,] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputArgs[col];
                }
            }
        }
    }
}