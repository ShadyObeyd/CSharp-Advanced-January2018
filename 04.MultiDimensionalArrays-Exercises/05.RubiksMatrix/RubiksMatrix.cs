using System;
using System.Linq;

namespace _05.RubiksMatrix
{
    class RubiksMatrix
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowCount = matrixSize[0];
            int columnCount = matrixSize[1];

            int[,] matrix = new int[rowCount, columnCount];

            int number = 1;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    matrix[row, col] = number;
                    number++;
                }
            }

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] commandTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int column = 0;
                int row = 0;
                int rotationsCount = int.Parse(commandTokens[2]);

                switch (commandTokens[1])
                {
                    case "up":
                        column = int.Parse(commandTokens[0]);
                        ShiftUp(matrix, column, rotationsCount);
                        break;
                    case "down":
                        column = int.Parse(commandTokens[0]);
                        ShiftDown(matrix, column, rotationsCount);
                        break;
                    case "left":
                        row = int.Parse(commandTokens[0]);
                        ShiftLeft(matrix, row, rotationsCount);
                        break;
                    case "right":
                        row = int.Parse(commandTokens[0]);
                        ShiftRight(matrix, row, rotationsCount);
                        break;
                }
            }
            RearrangeMatrix(matrix);
        }

        static void RearrangeMatrix(int[,] matrix)
        {
            int number = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != number)
                    {
                        for (int r = 0; r < matrix.GetLength(0); r++)
                        {
                            for (int c = 0; c < matrix.GetLength(1); c++)
                            {
                                if (matrix[r, c] == number)
                                {
                                    int temp = matrix[row, col];
                                    matrix[row, col] = matrix[r, c];
                                    matrix[r, c] = temp;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    number++;
                }
            }
        }

        static void ShiftRight(int[,] matrix, int row, int rotationsCount)
        {
            for (int col = 0; col < rotationsCount % matrix.GetLength(1); col++)
            {
                int rowLastElement = matrix[row, matrix.GetLength(1) - 1];

                for (int c = matrix.GetLength(1) - 1; c > 0; c--)
                {
                    matrix[row, c] = matrix[row, c - 1];
                }
                matrix[row, 0] = rowLastElement;
            }
        }

        static void ShiftLeft(int[,] matrix, int row, int rotationsCount)
        {
            for (int col = 0; col < rotationsCount % matrix.GetLength(1); col++)
            {
                int rowFirstElement = matrix[row, 0];

                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    matrix[row, c] = matrix[row, c + 1];
                }
                matrix[row, matrix.GetLength(1) - 1] = rowFirstElement;
            }
        }

        static void ShiftUp(int[,] matrix, int column, int rotationsCount)
        {
            for (int row = 0; row < rotationsCount % matrix.GetLength(0); row++)
            {
                int columnFirstElement = matrix[0, column];

                for (int r = 0; r < matrix.GetLength(0) - 1; r++)
                {
                    matrix[r, column] = matrix[r + 1, column];
                }
                matrix[matrix.GetLength(0) - 1, column] = columnFirstElement;
            }
        }

        static void ShiftDown(int[,] matrix, int column, int rotationsCount)
        {
            for (int row = 0; row < rotationsCount % matrix.GetLength(0); row++)
            {
                int columnLastElement = matrix[matrix.GetLength(0) - 1, column];

                for (int r = matrix.GetLength(0) - 1; r > 0; r--)
                {
                    matrix[r, column] = matrix[r - 1, column];
                }
                matrix[0, column] = columnLastElement;
            }
        }
    }
}