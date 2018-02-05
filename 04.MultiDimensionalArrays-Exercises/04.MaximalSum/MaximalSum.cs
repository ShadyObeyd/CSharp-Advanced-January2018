using System;
using System.Linq;

namespace _04.MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            int[,] matrix = ReadMatrix();

            int maxSum = 0;
            int rowIndex = 0;
            int columnIndex = 0;

            for (int row = 0; row <  matrix.GetLength(0) - 2; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 2; column++)
                {
                    int tempSum = matrix[row, column] + matrix[row, column + 1] + matrix[row, column + 2] +
                                  matrix[row + 1, column] + matrix[row + 1, column + 1] + matrix[row + 1, column + 2] +
                                  matrix[row + 2, column] + matrix[row + 2, column + 1] + matrix[row + 2, column + 2];

                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        rowIndex = row;
                        columnIndex = column;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[rowIndex, columnIndex]} {matrix[rowIndex, columnIndex + 1]} {matrix[rowIndex, columnIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 1, columnIndex]} {matrix[rowIndex + 1, columnIndex + 1]} {matrix[rowIndex + 1, columnIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 2, columnIndex]} {matrix[rowIndex + 2, columnIndex + 1]} {matrix[rowIndex + 2, columnIndex + 2]}");
        }

        static int[,] ReadMatrix()
        {
            int[] inputData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowsCount = inputData[0];
            int columnsCount = inputData[1];

            int[,] matrix = new int[rowsCount, columnsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] elementsPerRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int column = 0; column < columnsCount; column++)
                {
                    matrix[row, column] = elementsPerRow[column];
                }
            }
            return matrix;
        }
    }
}