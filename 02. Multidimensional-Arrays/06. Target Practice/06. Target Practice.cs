using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Target_Practice
{
    class Program
    {
        static void Main()
        {
            int[] matrixTokens = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            char[][] matrix = FillMatrix(matrixTokens, snake);

            int[] shotParams = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ShootCells(matrix, shotParams);

            RearrangeMatrix(matrix);

            //PRINT
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void ShootCells(char[][] matrix, int[] shotParams)
        {
            int landRow = shotParams[0];
            int landCol = shotParams[1];
            int radius = shotParams[2];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (IsCellShooted(rowIndex, colIndex, landRow, landCol, radius))
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }
        }

        private static bool IsCellShooted(int rowIndex, int colIndex, int landRow, int landCol, int radius)
        {
            double distance = Math.Sqrt((rowIndex - landRow) * (rowIndex - landRow) 
                                + (colIndex - landCol) * (colIndex - landCol));
            return distance <= radius;
        }

        private static void RearrangeMatrix(char[][] matrix)
        {
            int rowSize = matrix.Length;
            int colSize = matrix[0].Length;

            for (int colIndex = 0; colIndex < colSize; colIndex++)
            {
                List<char> chars = new List<char>();
                for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
                {
                    if (matrix[rowIndex][colIndex] != ' ')
                    {
                        chars.Add(matrix[rowIndex][colIndex]);
                    }
                }

                int startIndex = rowSize - chars.Count;
                for (int rowIndex = 0; rowIndex < startIndex; rowIndex++)
                {
                    matrix[rowIndex][colIndex] = ' ';
                }

                int listIndex = 0;
                for (int rowIndex = startIndex; rowIndex < rowSize; rowIndex++)
                {
                    matrix[rowIndex][colIndex] = chars[listIndex];
                    listIndex++;
                }
            }
        }

        private static char[][] FillMatrix(int[] matrixTokens, string snake)
        {
            int rowSize = matrixTokens[0];
            int colSize = matrixTokens[1];
            char[][] matrix = new char[rowSize][];

            int snakeIndex = 0;
            int rowCounter = 0;

            for (int rowIndex = rowSize - 1; rowIndex >= 0; rowIndex--)
            {
                rowCounter++;
                matrix[rowIndex] = new char[colSize];

                if (rowCounter % 2 == 0)
                {
                    for (int colIndex = 0; colIndex < colSize; colIndex++)
                    {
                        matrix[rowIndex][colIndex] = snake[snakeIndex];
                        snakeIndex++;

                        if (snakeIndex > snake.Length - 1)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int colIndex = colSize - 1; colIndex >= 0; colIndex--)
                    {
                        matrix[rowIndex][colIndex] = snake[snakeIndex];
                        snakeIndex++;

                        if (snakeIndex > snake.Length - 1)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
            }

            return matrix;
        }
    }
}