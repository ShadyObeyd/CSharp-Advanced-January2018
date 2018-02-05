using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class PartyReservationFilterModule
    {
        static void Main()
        {
            List<string> guests = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            HashSet<string> filtered = new HashSet<string>();

            List<string> tempGuestList = guests.ToList();

            while (input != "Print")
            {
                string[] inputTokens = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string command = inputTokens[0];
                string filterType = inputTokens[1];
                string filterParameter = inputTokens[2];

                Func<string, bool> isFiltered = GetFilter(filterType, filterParameter);

                switch (command)
                {
                    case "Add filter":
                        FilterList(guests, tempGuestList, filtered, isFiltered);
                        break;
                    case "Remove filter":
                        RemoveFilter(guests, filtered, isFiltered);
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", guests));
        }

        static void RemoveFilter(List<string> guests, HashSet<string> filtered, Func<string, bool> isFiltered)
        {
            foreach (string filteredGuest in filtered)
            {
                if (isFiltered(filteredGuest))
                {
                    guests.Add(filteredGuest);
                }
            }
        }

        private static void FilterList(List<string> guests, List<string> temp, HashSet<string> filtered, Func<string, bool> isFiltered)
        {
            foreach (string guest in temp)
            {
                if (isFiltered(guest))
                {
                    guests.Remove(guest);
                    filtered.Add(guest);
                }
            }
        }

        static Func<string, bool> GetFilter(string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                return x => x.StartsWith(filterParameter);
            }
            else if (filterType == "Ends with")
            {
                return x => x.EndsWith(filterParameter);
            }
            else if (filterType == "Length")
            {
                return x => x.Length == int.Parse(filterParameter);
            }
            else if (filterType == "Contains")
            {
                return x => x.Contains(filterParameter);
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}