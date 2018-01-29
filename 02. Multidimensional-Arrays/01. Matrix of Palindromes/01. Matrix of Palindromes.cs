using System;
using System.Linq;

namespace _01.Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = input[0];
            int columns = input[1];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string[,] matrix = new string[rows, columns];

            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < columns; currentColumn++)
                {
                    matrix[currentRow, currentColumn] =
                        alphabet[currentRow].ToString() +
                        alphabet[currentRow + currentColumn].ToString() +
                        alphabet[currentRow];

                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}