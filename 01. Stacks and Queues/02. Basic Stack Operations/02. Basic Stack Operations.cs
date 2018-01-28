using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
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

            var stack = new Stack<int>(elements);

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (!stack.Any())
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
                Environment.Exit(0);
            }
            else
            {
                int smallestElement = stack.ToArray().Min();
                Console.WriteLine(smallestElement);
            }
        }
    }
}
