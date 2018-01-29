using System;
using System.Linq;

namespace _03.GroupNumbers
{
    class GroupNumbers
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] jaggedArr = new int[3][];

            jaggedArr[0] = input.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            jaggedArr[1] = input.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            jaggedArr[2] = input.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[i]));
            }
        }
    }
}
