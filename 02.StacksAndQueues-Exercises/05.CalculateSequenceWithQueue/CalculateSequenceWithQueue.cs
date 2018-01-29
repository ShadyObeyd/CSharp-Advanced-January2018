using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CalculateSequenceWithQueue
{
    class CalculateSequenceWithQueue
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            List<long> list = new List<long>();

            queue.Enqueue(n);
            list.Add(n);

            while (list.Count < 50)
            {
                long s2 = queue.Peek() + 1;
                long s3 = 2 * queue.Peek() + 1;
                long s4 = queue.Peek() + 2;

                queue.Enqueue(s2);
                queue.Enqueue(s3);
                queue.Enqueue(s4);
                queue.Dequeue();

                list.Add(s2);
                list.Add(s3);
                list.Add(s4);
            }

            Console.WriteLine(string.Join(" ", list.Take(50)));
        }
    }
}
