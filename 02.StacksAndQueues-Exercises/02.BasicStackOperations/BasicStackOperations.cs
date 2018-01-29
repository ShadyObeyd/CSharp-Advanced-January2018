using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main()
        {
            int[] parameterTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            int numbersCountToPush = parameterTokens[0];
            int elementsToPopCount = parameterTokens[1];
            int elementToSearchFor = parameterTokens[2];

            for (int i = 0; i < numbersCountToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < elementsToPopCount; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stack.Contains(elementToSearchFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
