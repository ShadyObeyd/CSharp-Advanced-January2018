using System;
using System.Linq;

namespace _03.CountUpperCaseWords
{
    class CountUpperCaseWords
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToArray();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}