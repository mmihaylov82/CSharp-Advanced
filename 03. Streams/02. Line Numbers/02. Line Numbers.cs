using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\Resources\text.txt");
            StreamWriter writer = new StreamWriter(@"..\Resources\textEdited.txt");
            Console.WriteLine("Starting text editing...");
            using (reader)
            {
                using (writer)
                {
                    int lineNum = 1;
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"Line {lineNum}: " + line);
                        line = reader.ReadLine();
                        lineNum++;
                    }
                }
            }

            Console.WriteLine("Text editing finished.");
        }
    }
}
