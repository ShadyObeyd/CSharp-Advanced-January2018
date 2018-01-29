using System;
using System.Collections.Generic;

namespace _01.ReverseNumbersWithAStack
{
    class ReverseNumbersWithAStack
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(numbers);

            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }
        }
    }
}
