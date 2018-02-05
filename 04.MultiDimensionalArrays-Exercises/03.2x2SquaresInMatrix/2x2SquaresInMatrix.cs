using System;
using System.Linq;

namespace _03._2x2SquaresInMatrix
{
    class _2x2SquaresInMatrix
    {
        static void Main()
        {
            char[,] matrix = ReadMatrix();

            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 1; column++)
                {
                    bool isSquare = matrix[row, column] == matrix[row, column + 1] && matrix[row + 1, column] == matrix[row, column] && matrix[row + 1, column + 1] == matrix[row, column];

                    if (isSquare)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }

        static char[,] ReadMatrix()
        {
            int[] inputData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowsCount = inputData[0];
            int columnsCount = inputData[1];

            char[,] matrix = new char[rowsCount, columnsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                char[] elementsPerRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int column = 0; column < columnsCount; column++)
                {
                    matrix[row, column] = elementsPerRow[column];
                }
            }
            return matrix;
        }
    }
}