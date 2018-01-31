using System;
using System.Linq;

namespace _07.Lego_Blocks
{
    class Program
    {
        static void Main()
        {
            int rowSize = int.Parse(Console.ReadLine());

            int[][] firstMatrix = new int[rowSize][];
            int[][] secondMatrix = new int[rowSize][];

            for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
            {
                firstMatrix[rowIndex] = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
            {
                secondMatrix[rowIndex] = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();
            }

            bool hasMatched = true;
            int requiredLength = firstMatrix[0].Length + secondMatrix[0].Length;

            for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
            {
                int firstMatrixCurrRow = firstMatrix[rowIndex].Length;
                int secondMatrixCurrRow = secondMatrix[rowIndex].Length;
                int currRow = firstMatrixCurrRow + secondMatrixCurrRow;

                if (currRow != requiredLength)
                {
                    hasMatched = false;
                    break;
                }
            }

            if (hasMatched)
            {
                for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
                {
                    string first = string.Join(", ", firstMatrix[rowIndex]);
                    string second = string.Join(", ", secondMatrix[rowIndex]);

                    Console.WriteLine($"[{first}, {second}]");
                }
            }
            else
            {
                int count = 0;
                for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
                {
                    count += firstMatrix[rowIndex].Length + secondMatrix[rowIndex].Length;
                }

                Console.WriteLine($"The total number of cells is: {count}");
            }
        }
    }
}