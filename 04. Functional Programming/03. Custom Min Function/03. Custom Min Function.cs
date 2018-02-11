using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int min = int.MaxValue;

            Func<int, bool> func = n => n < min;

            foreach (var number in numbers)
            {
                if (func(number))
                {
                    min = number;
                }
            }

            Console.WriteLine(min);
        }
    }
}
