using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> checkDivision = n => n % divider != 0;

            numbers.Where(n => checkDivision(n)).ToList().ForEach(n => Console.Write(n + " "));
        }
    }
}
