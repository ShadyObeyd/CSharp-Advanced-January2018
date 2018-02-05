using System;
using System.Linq;

namespace _07.PredicateOfNames
{
    class PredicateOfNames
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isTheRightLength = x => x.Length <= length;
            Action<string> print = x => Console.WriteLine(x);

            foreach (string name in names)
            {
                if (isTheRightLength(name))
                {
                    print(name);
                }
            }
        }
    }
}