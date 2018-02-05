using System;

namespace _01.ActionPoint
{
    class ActionPoint
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = n => Console.WriteLine(n);

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}