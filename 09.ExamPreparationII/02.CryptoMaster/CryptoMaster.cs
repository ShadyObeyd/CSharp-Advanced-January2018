using System;
using System.Linq;

namespace _02.CryptoMaster
{
    class CryptoMaster
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


            int maxSeq = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {
                    int currentIndex = index;
                    int nextIndex = (index + step) % numbers.Length;
                    int currentSeq = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                        currentSeq++;
                    }

                    if (currentSeq > maxSeq)
                    {
                        maxSeq = currentSeq;
                    }
                }
            }

            Console.WriteLine(maxSeq);
        }
    }
}