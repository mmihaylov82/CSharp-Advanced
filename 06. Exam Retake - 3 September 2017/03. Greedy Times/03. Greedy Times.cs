using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            var inputArgs = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            long currentBagAmount = 0;

            var goldDict = new Dictionary<string, long>();
            var gemDict = new Dictionary<string, long>();
            var cashDict = new Dictionary<string, long>();

            long goldTotal = 0;
            long gemTotal = 0;
            long cashTotal = 0;

            for (int i = 0; i < inputArgs.Length - 1; i += 2)
            {
                string item = inputArgs[i];
                long amount = long.Parse(inputArgs[i + 1]);

                if (currentBagAmount + amount > bagCapacity)
                {
                    continue;
                }
                
                if (item.ToLower() == "gold")
                {
                    if (!goldDict.ContainsKey("Gold"))
                    {
                        goldDict["Gold"] = amount;
                        goldTotal += amount;
                        currentBagAmount += amount;
                    }
                    else
                    {
                        goldDict["Gold"] += amount;
                        goldTotal += amount;
                        currentBagAmount += amount;

                    }
                }
                else if (item.Length >= 4 && item.ToLower().EndsWith("gem"))
                {
                    if (!gemDict.ContainsKey(item) && (gemTotal + amount <= goldTotal))
                    {
                        gemDict[item] = amount;
                        gemTotal += amount;
                        currentBagAmount += amount;
                    }
                    else
                    {
                        if ((currentBagAmount + amount <= bagCapacity) && (gemTotal + amount <= goldTotal))
                        {
                            gemDict[item] += amount;
                            gemTotal += amount;
                            currentBagAmount += amount;
                        }
                    }
                }
                else if (item.Length == 3 && item.ToCharArray().All(x => char.IsLetter(x)))
                {
                    if (!cashDict.ContainsKey(item) && (cashTotal + amount <= gemTotal))
                    {
                        cashDict[item] = amount;
                        cashTotal += amount;
                        currentBagAmount += amount;
                    }
                    else
                    {
                        if ((currentBagAmount + amount <= bagCapacity) && (cashTotal + amount <= gemTotal))
                        {
                            cashDict[item] += amount;
                            cashTotal += amount;
                            currentBagAmount += amount;
                        }
                    }
                }
            }

            //PrintOutput
            if (goldDict.Count != 0)
            {
                Console.WriteLine($"<Gold> ${goldTotal}");
                foreach (var item in goldDict.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
            if (gemDict.Count != 0)
            {
                Console.WriteLine($"<Gem> ${gemTotal}");
                foreach (var item in gemDict.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
            if (cashDict.Count != 0)
            {
                Console.WriteLine($"<Cash> ${cashTotal}");
                foreach (var item in cashDict.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}

