using System;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        private static string[] partyGuests;
        private static string[] filtered;

        static void Main()
        {
            partyGuests = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            filtered = Enumerable.Range(0, partyGuests.Length).Select(s => "").ToArray();

            string line;
            while ((line = Console.ReadLine()) != "Print")
            {
                string[] tokens = line
                    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string condition = tokens[1];
                string param = tokens[2];

                switch (condition)
                {
                    case "Starts with":
                        CommandProcess(command, n => n.StartsWith(param));
                        break;
                    case "Ends with":
                        CommandProcess(command, n => n.EndsWith(param));
                        break;
                    case "Length":
                        CommandProcess(command, n => n.Length == int.Parse(param));
                        break;
                    case "Contains":
                        CommandProcess(command, n => n.Contains(param));
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", partyGuests.Where(g => g != "")));
        }

        private static void CommandProcess(string command, Func<string, bool> func)
        {
            switch (command)
            {
                case "Add filter":
                    for (int i = partyGuests.Length - 1; i >= 0; i--)
                    {
                        if (func(partyGuests[i]))
                        {
                            filtered[i] = partyGuests[i];
                            partyGuests[i] = "";
                        }
                    }
                    break;
                case "Remove filter":
                    for (int i = filtered.Length - 1; i >= 0; i--)
                    {
                        if (func(filtered[i]))
                        {
                            partyGuests[i] = filtered[i];
                            filtered[i] = "";
                        }
                    }
                    break;
            }
        }
    }
}
