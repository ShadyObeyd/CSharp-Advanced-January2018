using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class HitList
    {
        static void Main()
        {
            var info = new Dictionary<string, Dictionary<string, string>>();

            int targetIndex = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                string[] inputTokens = input.Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputTokens[0];

                if (!info.ContainsKey(name))
                {
                    info.Add(name, new Dictionary<string, string>());
                }

                for (int i = 1; i < inputTokens.Length; i++)
                {
                    string[] keyAndValue = inputTokens[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    string key = keyAndValue[0];
                    string value = keyAndValue[1];

                    if (!info[name].ContainsKey(key))
                    {
                        info[name].Add(key, string.Empty);
                    }
                    info[name][key] = value;
                }

                input = Console.ReadLine();
            }

            string[] nameToKill = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string wantedName = nameToKill[1];

            Console.WriteLine($"Info on {wantedName}:");

            int infoIndex = GetKeysLengths(info[wantedName]) + GetValuesLengths(info[wantedName]);

            foreach (KeyValuePair<string, string> infos in info[wantedName].OrderBy(k => k.Key))
            {
                string currentKey = infos.Key;
                string currentValue = infos.Value;

                Console.WriteLine($"---{currentKey}: {currentValue}");
            }
            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - infoIndex} more info.");
            }
        }

        static int GetValuesLengths(Dictionary<string, string> dictionary)
        {
            int valuesSum = 0;
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                string currentValue = item.Value;
                valuesSum += currentValue.Length;
            }
            return valuesSum;
        }

        private static int GetKeysLengths(Dictionary<string, string> dictionary)
        {
            int keysSum = 0;
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                string currentKey = item.Key;
                keysSum += currentKey.Length;
            }
            return keysSum;
        }
    }
}