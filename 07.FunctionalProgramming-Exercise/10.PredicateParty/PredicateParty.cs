using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class PredicateParty
    {
        static void Main()
        {
            string[] guests = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> finalGuestList = guests.ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] inputTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = inputTokens[0];
                string criteria = inputTokens[1];
                string variable = inputTokens[2];

                Func<string, bool> criteriaCheck = CheckCriteria(criteria, variable);

                switch (command)
                {
                    case "Remove":
                        finalGuestList = finalGuestList.Where(x => !criteriaCheck(x)).ToList();
                        break;
                    case "Double":
                        finalGuestList.AddRange(finalGuestList.Where(x => criteriaCheck(x)).ToList());
                        break;
                }
                input = Console.ReadLine();
            }
            if (finalGuestList.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", finalGuestList) + " " + "are going to the party!");
            }
        }

        private static Func< string, bool> CheckCriteria(string criteria, string variable)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(variable);
            }
            else if (criteria == "EndsWith")
            {
                return x => x.EndsWith(variable);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(variable);
            }
            else
            {
                return null;
            }
        }
    }
}