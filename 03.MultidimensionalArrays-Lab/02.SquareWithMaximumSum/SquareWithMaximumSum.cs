using System;
using System.Linq;

namespace _02.SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main()
        {
            int[] matrixSize = ReadArrayFromInput(Console.ReadLine());

            int rowsCount = matrixSize[0];
            int columnsCount = matrixSize[1];

            int[,] matrix = new int[rowsCount, columnsCount];

            for (int rows = 0; rows < rowsCount; rows++)
            {
                int[] elementsPerRow = ReadArrayFromInput(Console.ReadLine());

                for (int collumns = 0; collumns < columnsCount; collumns++)
                {
                    matrix[rows, collumns] = elementsPerRow[collumns];
                }
            }

            int rowIndex = 0;
            int columnIndex = 0;
            int maxSum = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) - 1; columns++)
                {
                    int tempSum = matrix[rows, columns] + matrix[rows, columns + 1] + matrix[rows + 1, columns] + matrix[rows + 1, columns + 1];

                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        rowIndex = rows;
                        columnIndex = columns;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowIndex, columnIndex]} {matrix[rowIndex, columnIndex + 1]}");
            Console.WriteLine($"{matrix[rowIndex + 1, columnIndex]} {matrix[rowIndex + 1, columnIndex + 1]}");
            Console.WriteLine(maxSum);
        }

        static int[] ReadArrayFromInput(string input)
        {
            return input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
