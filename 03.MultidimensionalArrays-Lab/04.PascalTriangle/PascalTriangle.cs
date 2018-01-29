﻿using System;

namespace _04.PascalTriangle
{
    class PascalTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];

            for (int currentHeight = 0; currentHeight < n; currentHeight++)
            {
                triangle[currentHeight] = new long[currentHeight + 1];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][currentHeight] = 1;

                if (currentHeight >= 2)
                {
                    for (int widthCounter = 1; widthCounter < currentHeight; widthCounter++)
                    {
                        triangle[currentHeight][widthCounter] = triangle[currentHeight - 1][widthCounter - 1] + triangle[currentHeight - 1][widthCounter];
                    }
                }
            }

            for (int i = 0; i < triangle.Length; i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }
    }
}
