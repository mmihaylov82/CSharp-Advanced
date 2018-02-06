using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08._Full_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();

            Traverse(path, dictionary);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputPath = desktop + "/report.txt";

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (KeyValuePair<string, Dictionary<string, double>> keyvalue in dictionary.OrderByDescending(k => k.Value.Count).ThenBy(name => name.Key))
                {
                    writer.WriteLine(keyvalue.Key);
                    foreach (KeyValuePair<string, double> pair in keyvalue.Value.OrderBy(size => size.Value))
                    {
                        writer.WriteLine("--" + pair.Key + " - {0:F3}kb", pair.Value / 1024);
                    }
                }
            }
        }

        static void Traverse(string path, Dictionary<string, Dictionary<string, double>> dictionary)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (dictionary.ContainsKey(fileInfo.Extension))
                {
                    if (dictionary[fileInfo.Extension].ContainsKey(fileInfo.Name))
                    {
                        int fileNameCount = dictionary[fileInfo.Extension]
                            .Keys
                            .Where(k => k.StartsWith(fileInfo.Name))
                            .Count();

                        dictionary[fileInfo.Extension].Add(fileInfo.Name + $" ({fileNameCount++})", fileInfo.Length);
                    }
                    else
                    {
                        dictionary[fileInfo.Extension].Add(fileInfo.Name, fileInfo.Length);
                    }
                }
                else
                {
                    Dictionary<string, double> dict = new Dictionary<string, double>();
                    dict.Add(fileInfo.Name, fileInfo.Length);
                    dictionary.Add(fileInfo.Extension, dict);
                }
            }

            string[] directories = Directory.GetDirectories(path);
            foreach (var directoryPath in directories)
            {
                Traverse(directoryPath, dictionary);
            }
        }
    }
}
