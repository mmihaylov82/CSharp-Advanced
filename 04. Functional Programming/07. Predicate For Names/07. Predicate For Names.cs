using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {

            int sampleLength = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, bool> filter = (st) => (st.Length <= sampleLength);

            names.Where(filter).ToList().ForEach(n => Console.WriteLine(n));
        }
    }
}
