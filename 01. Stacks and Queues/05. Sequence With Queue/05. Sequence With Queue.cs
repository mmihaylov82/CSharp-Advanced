﻿using System;
using System.Collections.Generic;

namespace _05.Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long startNum = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            queue.Enqueue(startNum);

            for (int i = 0; i < 50; i++)
            {
                long n = queue.Dequeue();
                Console.Write(n + " ");
                queue.Enqueue(n + 1);
                queue.Enqueue(2 * n + 1);
                queue.Enqueue(n + 2);
            }
        }
    }
}