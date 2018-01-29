using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main()
        {
            int[] parameterTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] sequence = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            int numbersCountToPush = parameterTokens[0];
            int elementsToRemoveCount = parameterTokens[1];
            int elementToSearchFor = parameterTokens[2];

            for (int i = 0; i < numbersCountToPush; i++)
            {
                queue.Enqueue(sequence[i]);
            }

            for (int i = 0; i < elementsToRemoveCount; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(elementToSearchFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
