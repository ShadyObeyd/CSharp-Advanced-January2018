using System;
using System.Linq;

namespace _07.LegoBlocks
{
    class LegBlocks
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] firstJagged = ReadInput(n);
            int[][] secondJagged = ReadInput(n);

            ReverseArray(secondJagged);
            int[][] result = ConcatArrays(firstJagged, secondJagged);

            int cellsCount = 0;

            for (int i = 0; i < result.Length; i++)
            {
                int[] currentArr = result[i];

                cellsCount += currentArr.Length;
            }

            for (int i = 0; i < result.Length - 1; i++)
            {
                int[] currentArr = result[i];
                int[] nextArr = result[i + 1];

                if (currentArr.Length != nextArr.Length)
                {
                    Console.WriteLine($"The total number of cells is: {cellsCount}");
                    return;
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("[" + string.Join(", ", result[i]) + "]");
            }
        }

        private static int[][] ConcatArrays(int[][] firstJagged, int[][] secondJagged)
        {
            int[][] result = new int[firstJagged.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                int[] firstCurrentArr = firstJagged[i];
                int[] secondCurrentArr = secondJagged[i];

                result[i] = firstCurrentArr.Concat(secondCurrentArr).ToArray();
            }

            return result;
        }

        static void ReverseArray(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Array.Reverse(arr[i]);
            }
        }

        static int[][] ReadInput(int n)
        {
            int[][] jaggedArr = new int[n][];

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArr[i] = new int[input.Length];

                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    jaggedArr[i][j] = input[j];
                }
            }

            return jaggedArr;
        }
    }
}