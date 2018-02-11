using System;
using System.Linq;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, int, bool> func = (s, i) => (s.ToCharArray().Sum(c => c) >= i);

            foreach (var name in names)
            {
                if (func(name, sum))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
