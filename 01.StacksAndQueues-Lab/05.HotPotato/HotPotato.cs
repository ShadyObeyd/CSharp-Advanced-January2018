using System;
using System.Collections.Generic;

namespace _05.HotPotato
{
    class HotPotato
    {
        static void Main()
        {
            string[] children = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int toss = int.Parse(Console.ReadLine());
            Queue<string> childrenQueue = new Queue<string>(children);

            while (childrenQueue.Count > 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    childrenQueue.Enqueue(childrenQueue.Dequeue());
                }
                Console.WriteLine($"Removed {childrenQueue.Dequeue()}");
            }
            Console.WriteLine($"Last is {childrenQueue.Dequeue()}");
        }
    }
}
