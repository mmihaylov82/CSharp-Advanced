using System;
using System.IO;

namespace _01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"..\Resources\text.txt"))
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    lineNumber++;
                }
            }
        }
    }
}