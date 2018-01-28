using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var queue = new Queue<int>(elements);

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (!queue.Any())
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
                Environment.Exit(0);
            }
            else
            {
                int smallestElement = queue.ToArray().Min();
                Console.WriteLine(smallestElement);
            }
        }
    }
}