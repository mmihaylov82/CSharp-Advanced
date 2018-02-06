using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader(@"..\Resources\words.txt");
            StreamReader reader2 = new StreamReader(@"..\Resources\text.txt");
            StreamWriter writer = new StreamWriter(@"..\Resources\result.txt");
            Console.WriteLine("Procesing sample text...");

            using (reader1)
            {
                using (reader2)
                {
                    using (writer)
                    {
                        StringBuilder sb1 = new StringBuilder();
                        StringBuilder sb2 = new StringBuilder();

                        var line = reader1.ReadLine();
                        while (line != null)
                        {
                            sb1.Append(line.ToLower() + " ");
                            line = reader1.ReadLine();
                        }

                        line = reader2.ReadLine();
                        while (line != null)
                        {
                            sb2.Append(line.ToLower() + " ");
                            line = reader2.ReadLine();
                        }

                        var wordsFileElements = sb1
                            .ToString()
                            .Split(new[] { ' ', '!', '?', '.', '-', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
                        var textFileElements = sb2
                            .ToString()
                            .Split(new[] { ' ', '!', '?', '.', '-', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                        var results = wordsFileElements.Intersect(textFileElements);

                        var dict = new Dictionary<string, int>();

                        foreach (var word in results)
                        {
                            var count = textFileElements.Where(x => x == word).Count();
                            dict[word] = count;
                        }

                        foreach (var entry in dict.OrderByDescending(d => d.Value))
                        {
                            writer.WriteLine($"{entry.Key} - {entry.Value}");
                        }
                    }
                }
            }

            Console.WriteLine("Done.");
        }
    }
}
