using System;
using System.Linq;

namespace _03.Squares_in_Matrix
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

            string[,] matrix = new string[rows, columns];

            PopulateMatrix(matrix, rows, columns);

            int squaresCount = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        squaresCount++;
                    }
                }
            }

            Console.WriteLine(squaresCount);
        }

        private static void PopulateMatrix(string[,] matrix, int rows, int columns)
        {
            for (int row = 0; row < rows; row++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = inputArgs[col];
                }
            }
        }
    }
}