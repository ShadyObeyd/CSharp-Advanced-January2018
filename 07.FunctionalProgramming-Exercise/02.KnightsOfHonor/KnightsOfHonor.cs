using System;

namespace _02.KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = n => Console.WriteLine($"Sir {n}");

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}