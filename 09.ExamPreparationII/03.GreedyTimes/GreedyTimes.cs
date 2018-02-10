using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GreedyTimes
{
    class GreedyTimes
    {
        static void Main()
        {
            Dictionary<string, long> goldData = new Dictionary<string, long>();
            long goldQuantity = 0;
            Dictionary<string, long> gemsData = new Dictionary<string, long>();
            long gemsQuantity = 0;
            Dictionary<string, long> cashData = new Dictionary<string, long>();
            long cashQuantity = 0;

            long bagLimit = long.Parse(Console.ReadLine());

            string[] itemsInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < itemsInput.Length; i += 2)
            {
                long bagSize = goldQuantity + gemsQuantity + cashQuantity;

                string itemName = itemsInput[i];
                long quantity = long.Parse(itemsInput[i + 1]);

                if (bagSize >= bagLimit)
                {
                    break;
                }

                if (itemName.Length == 3)
                {
                    cashQuantity += quantity;

                    if (gemsQuantity >= cashQuantity)
                    {
                        FillDictionary(cashData, itemName, quantity, bagSize, bagLimit);
                    }
                    else
                    {
                        cashQuantity -= quantity;
                    }
                }
                else if (itemName.ToLower().EndsWith("gem"))
                {
                    gemsQuantity += quantity;

                    if (goldQuantity >= gemsQuantity)
                    {
                        FillDictionary(gemsData, itemName, quantity, bagSize, bagLimit);
                    }
                    else
                    {
                        gemsQuantity -= quantity;
                    }
                }
                else if (itemName.ToLower() == "gold" && bagSize + quantity < bagLimit)
                {
                    goldQuantity += quantity;
                    FillDictionary(goldData, itemName, quantity, bagSize, bagLimit);
                }
            }

            if (goldData.Any())
            {
                PrintBag(goldData, "Gold");
            }

            if (gemsData.Any())
            {
                PrintBag(gemsData, "Gem");
            }

            if (cashData.Any())
            {
                PrintBag(cashData, "Cash");
            }
        }

        static void PrintBag(Dictionary<string, long> bag, string type)
        {
            Console.WriteLine($"<{type}> ${bag.Values.Sum()}");

            foreach (KeyValuePair<string, long> itemData in bag.OrderByDescending(n => n.Key).ThenBy(a => a.Value))
            {
                string item = itemData.Key;
                long quantity = itemData.Value;

                Console.WriteLine($"##{item} - {quantity}");
            }
        }

        static void FillDictionary(Dictionary<string, long> bag, string itemName, long quantity, long bagSize, long bagLimit)
        {

            if (bagSize + quantity <= bagLimit)
            {
                if (!bag.ContainsKey(itemName))
                {
                    bag.Add(itemName, quantity);
                }
                else
                {
                    bag[itemName] += quantity;
                }
            }
        }
    }
}