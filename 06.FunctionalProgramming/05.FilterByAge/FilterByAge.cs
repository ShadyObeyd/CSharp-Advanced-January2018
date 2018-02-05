using System;
using System.Collections.Generic;

namespace _05.FilterByAge
{
    class FilterByAge
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] personTokens = Console.ReadLine().Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries);

                string personName = personTokens[0];
                int age = int.Parse(personTokens[1]);

                if (!people.ContainsKey(personName))
                {
                    people.Add(personName, age);
                }
            }

            string condition = Console.ReadLine();
            int ageBorder = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> filter = CreateFilter(condition, ageBorder);
            Action<KeyValuePair<string, int>> printer = Print(format);

            foreach (var person in people)
            {
                string personName = person.Key;
                int age = person.Value;

                if (filter(age))
                {
                    printer(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> Print(string format)
        {
            if (format == "name")
            {
                return x => Console.WriteLine($"{x.Key}");
            }
            else if (format == "age")
            {
                return x => Console.WriteLine($"{x.Value}");
            }
            else
            {
                return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
        }

        static Func<int, bool> CreateFilter(string condition, int ageBorder)
        {
            if (condition == "younger")
            {
                return x => x < ageBorder;
            }
            else
            {
                return x => x >= ageBorder;
            }
        }
    }
}
