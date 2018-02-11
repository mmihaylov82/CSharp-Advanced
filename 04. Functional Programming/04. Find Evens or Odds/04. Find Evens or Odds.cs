using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string operation = Console.ReadLine();
            
            Predicate<int> predicate = number => operation == "even" ? number % 2 == 0 : number % 2 != 0;
            
            for (int i = range[0]; i <= range[1]; i++)
            {
                if (predicate(i))
                {
                    Console.Write(i + " ");
                }
            }
            
        }
    }
}
