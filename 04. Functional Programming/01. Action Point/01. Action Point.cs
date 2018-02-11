using System;
using System.Linq;

namespace _01._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToList();

            Action<string> printer = x => Console.WriteLine(x);

            names.ForEach(printer);
        }
    }
}
