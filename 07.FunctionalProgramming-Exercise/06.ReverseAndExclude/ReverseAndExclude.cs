using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            Func<int, bool> isDivided = RemoveNumbers(n);
            Action<int[]> reverse = x => Array.Reverse(x);

            numbers = numbers.Where(x => !isDivided(x)).ToArray();

            reverse(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static Func<int, bool> RemoveNumbers(int n)
        {
            return x => x % n == 0;
        }
    }
}