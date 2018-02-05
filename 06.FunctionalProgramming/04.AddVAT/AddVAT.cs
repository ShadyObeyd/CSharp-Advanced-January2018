using System;
using System.Linq;

namespace _04.AddVAT
{
    class AddVAT
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToArray();

            foreach (double num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}
