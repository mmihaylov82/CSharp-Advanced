using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
           .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
           .ToList();

            string line;

            while ((line = Console.ReadLine()) != "Party!")
            {
                string[] tokens = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string condition = tokens[1];

                switch (condition)
                {
                    case "StartsWith":
                        CommandProcess(names, command, n => n.StartsWith(tokens[2]));
                        break;
                    case "EndsWith":
                        CommandProcess(names, command, n => n.EndsWith(tokens[2]));
                        break;
                    case "Length":
                        CommandProcess(names, command, n => n.Length == int.Parse(tokens[2]));
                        break;
                }
            }

            string result = names.Count > 0 ? $"{string.Join(", ", names)} are going to the party!" : "Nobody is going to the party!";
            Console.WriteLine(result);
        }

        private static void CommandProcess(List<string> names, string command, Func<string, bool> func)
        {
            for (int i = names.Count - 1; i >= 0; i--)
            {
                if (func(names[i]))
                {
                    switch (command)
                    {
                        case "Remove":
                            names.RemoveAt(i);
                            break;
                        case "Double":
                            names.Add(names[i]);
                            break;
                    }
                }
            }

        }
    }
}
