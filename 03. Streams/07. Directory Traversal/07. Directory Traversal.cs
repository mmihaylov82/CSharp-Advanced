using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07._Directory_Traversal
{
    class Program
    {
        static void Main()
        {
            string directory = Console.ReadLine();
            string[] files = Directory.GetFiles(directory);
            Dictionary<string, Dictionary<string, double>> dictionary = 
                    new Dictionary<string, Dictionary<string, double>>();
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (dictionary.ContainsKey(fileInfo.Extension))
                {

                    dictionary[fileInfo.Extension].Add(fileInfo.Name, fileInfo.Length);
                }
                else
                {
                    Dictionary<string, double> dict = new Dictionary<string, double>();
                    dict.Add(fileInfo.Name, fileInfo.Length);
                    dictionary.Add(fileInfo.Extension, dict);
                }
            }

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = desktop + "/report.txt";
            
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                foreach (KeyValuePair<string, Dictionary<string, double>> keyvalue in 
                    dictionary.OrderByDescending(k => k.Value.Count).ThenBy(name => name.Key))
                {
                    writer.WriteLine(keyvalue.Key);
                    foreach (KeyValuePair<string, double> pair in keyvalue.Value.OrderBy(size => size.Value))
                    {
                        writer.WriteLine("--" + pair.Key + " - {0:F3}kb", pair.Value / 1024);
                    }
                }
            }
        }
    }
}
