using System;
using System.Linq;

namespace _02._Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            var safeArray = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int longestSeq = 0;

            for (int index = 0; index < safeArray.Length; index++)
            {
                for (int step = 1; step < safeArray.Length; step++)
                {
                    int currentIndex = index;
                    int nextIndex = (currentIndex + step) % safeArray.Length;
                    int currentSeq = 1;

                    while (safeArray[currentIndex] < safeArray[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % safeArray.Length;
                        currentSeq++;
                    }

                    if (currentSeq > longestSeq)
                    {
                        longestSeq = currentSeq;
                    }
                }
            }
            Console.WriteLine(longestSeq);
        }
    }
}
