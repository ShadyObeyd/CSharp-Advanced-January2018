using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] elementsPerRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int column = 0; column < matrixSize; column++)
                {
                    matrix[row, column] = elementsPerRow[column];
                }
            }

            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                firstDiagonalSum += matrix[i, i];
                secondDiagonalSum += matrix[i, matrix.GetLength(0) - 1 - i];
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}