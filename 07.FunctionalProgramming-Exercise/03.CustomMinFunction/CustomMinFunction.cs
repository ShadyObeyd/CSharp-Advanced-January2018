using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> smallestNum = FindSmallestNum();

            Console.WriteLine(smallestNum(numbers));
        }

        private static Func<int[], int> FindSmallestNum()
        {
            return x =>
            {
                int smallestNum = int.MaxValue;

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] < smallestNum)
                    {
                        smallestNum = x[i];
                    }
                }
                return smallestNum;
            };
        }
    }
}