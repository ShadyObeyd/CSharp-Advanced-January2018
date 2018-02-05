using System;
using System.Linq;

namespace _08.CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();
            int[] oddNumbers = numbers.Where(n => n % 2 != 0).ToArray();

            Array.Sort(evenNumbers);
            Array.Sort(oddNumbers);

            numbers = evenNumbers.Concat(oddNumbers).ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}