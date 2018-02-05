using System;
using System.Linq;

namespace _02.SumNumbers
{
    class SumNumbers
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}