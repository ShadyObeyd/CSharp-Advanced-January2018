using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    class InfernoIII
    {
        static void Main()
        {
            List<int> gems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = Console.ReadLine();

            var filters = new Dictionary<string, Func<List<int>, List<int>>>();

            while (input != "Forge")
            {
                string[] inputTokens = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = inputTokens[0];
                string filterType = inputTokens[1];
                int filterParameter = int.Parse(inputTokens[2]);

                string dictKey = $"{filterType} {filterParameter}";

                switch (command)
                {
                    case "Exclude":
                        filters[dictKey] = CreateFunction(filterType, filterParameter);
                        break;
                    case "Reverse":
                        filters.Remove(dictKey);
                        break;
                }
                input = Console.ReadLine();
            }

            List<int> filtered = GetFiltered(gems, filters);

            gems = gems.Where(gem => !filtered.Contains(gem)).ToList();

            Console.WriteLine(string.Join(" ", gems));
        }

        static List<int> GetFiltered(List<int> gems, Dictionary<string, Func<List<int>, List<int>>> filters)
        {
            List<int> filteredGems = new List<int>();

            foreach (var filterPair in filters)
            {
                Func<List<int>, List<int>> filter = filterPair.Value;

                filteredGems.AddRange(filter(gems));
            }
            return filteredGems;
        }

        static Func<List<int>, List<int>> CreateFunction(string filterType, int filterParameter)
        {
            if (filterType == "Sum Left")
            {
                return gems => gems.Where(gem =>
                {
                    int index = gems.IndexOf(gem);
                    int leftGem;

                    if (index > 0)
                    {
                        leftGem = gems[index - 1];
                    }
                    else
                    {
                        leftGem = 0;
                    }
                    return gem + leftGem == filterParameter;
                }).ToList();
            }
            else if (filterType == "Sum Right")
            {
                return gems => gems.Where(gem =>
                {
                    int index = gems.IndexOf(gem);
                    int rightGem;

                    if (index < gems.Count - 1)
                    {
                        rightGem = gems[index + 1];
                    }
                    else
                    {
                        rightGem = 0;
                    }
                    return gem + rightGem == filterParameter;
                }).ToList();
            }
            else if (filterType == "Sum Left Right")
            {
                return gems => gems.Where(gem =>
                {
                    int index = gems.IndexOf(gem);
                    int leftGem;
                    if (index > 0)
                    {
                        leftGem = gems[index - 1];
                    }
                    else
                    {
                        leftGem = 0;
                    }

                    int rightGem;
                    if (index < gems.Count - 1)
                    {
                        rightGem = gems[index + 1];
                    }
                    else
                    {
                        rightGem = 0;
                    }
                    return gem + leftGem + rightGem == filterParameter;
                }).ToList();
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}