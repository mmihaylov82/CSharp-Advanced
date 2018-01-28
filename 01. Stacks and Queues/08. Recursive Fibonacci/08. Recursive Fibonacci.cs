using System;

namespace _08.Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var memo = new long[n + 1];

            Console.WriteLine(recursiveFibonacciWithMemoization(n - 1, memo));
        }

        private static long recursiveFibonacciWithMemoization(int n, long[] memo)
        {
            if (n <= 1)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] = recursiveFibonacciWithMemoization(n - 1, memo) +
                            recursiveFibonacciWithMemoization(n - 2, memo);
            return memo[n];
        }
    }
}