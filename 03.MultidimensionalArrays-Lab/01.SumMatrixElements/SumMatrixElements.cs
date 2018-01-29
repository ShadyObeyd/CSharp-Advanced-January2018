using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class SumMatrixElements
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowsCount = matrixSize[0];
            int columnsCount = matrixSize[1];

            int[,] matrix = new int[rowsCount, columnsCount];

            for (int rows = 0; rows < rowsCount; rows++)
            {
                int[] elementsPerRow = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int collumns = 0; collumns < columnsCount; collumns++)
                {
                    matrix[rows, collumns] = elementsPerRow[collumns];
                }
            }

            int sum = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    sum += matrix[rows, columns];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
