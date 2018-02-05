using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, bool> isDivisible = CheckNumbers(numbers);

            for (int i = 1; i <= n; i++)
            {
                if (isDivisible(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static Func<int, bool> CheckNumbers(int[] numbers)
        {
            return x =>
            {
                bool areAllDivisible = false;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (x % numbers[i] == 0)
                    {
                        areAllDivisible = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return areAllDivisible;
            };
        }
    }
}