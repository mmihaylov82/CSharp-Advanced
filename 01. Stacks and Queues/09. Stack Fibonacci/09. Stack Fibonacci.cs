using System;
using System.Collections.Generic;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<ulong>(n);

            if (n == 0)
            {
                Console.WriteLine(0);
            }
            else if (n == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                stack.Push(0);
                stack.Push(1);

                for (int i = 1; i < n; i++)
                {
                    ulong first = stack.Pop();
                    ulong second = stack.Pop();

                    stack.Push(first);
                    stack.Push(first + second);
                }

                Console.WriteLine(stack.Peek());
            }
        }
    }
}