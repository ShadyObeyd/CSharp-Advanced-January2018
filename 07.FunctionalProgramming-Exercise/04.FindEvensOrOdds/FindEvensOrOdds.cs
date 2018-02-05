using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            int[] bounds = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int start = bounds[0];
            int end = bounds[1];

            string command = Console.ReadLine();

            Predicate<int> filter;

            if (command == "even")
            {
                filter = x => x % 2 == 0;
            }
            else
            {
                filter = x => x % 2 != 0;
            }

            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}