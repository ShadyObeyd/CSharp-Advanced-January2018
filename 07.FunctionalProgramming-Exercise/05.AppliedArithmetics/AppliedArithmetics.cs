using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else if (command == "add")
                {
                    numbers = Change(numbers, n => n + 1).ToArray();
                }
                else if (command == "subtract")
                {
                    numbers = Change(numbers, n => n - 1).ToArray();
                }
                else if (command == "multiply")
                {
                    numbers = Change(numbers, n => n * 2).ToArray();
                }
                
                command = Console.ReadLine();
            }
        }

        static int[] Change(int[] numbers, Func<int, int> func)
        {
            return numbers.Select(n => func(n)).ToArray();
        }
    }
}