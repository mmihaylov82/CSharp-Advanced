using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> func = n => n % 2 != 0;

            Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(n => func(n))
                .ThenBy(n => n)
                .ToList()
                .ForEach(n => Console.Write(n + " "));
        }
    }
}
