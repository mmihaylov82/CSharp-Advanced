using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] days = new int[plants.Length];
            Stack<int> previousPlants = new Stack<int>();
            previousPlants.Push(0);

            for (int i = 1; i < numberOfPlants; i++)
            {
                int maxDays = 0;

                while (previousPlants.Count > 0 && plants[previousPlants.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[previousPlants.Pop()]);
                }
                if (previousPlants.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                previousPlants.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}