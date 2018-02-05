using System;
using System.Linq;

namespace _06.TargetPractice
{
    class TargetPracice
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowCount = matrixSize[0];
            int columnCount = matrixSize[1];
            string snake = Console.ReadLine();
            int[] shot = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[rowCount, columnCount];

            FillMatrix(matrix, snake, rowCount, columnCount);
            Shoot(matrix, shot);
            RemoveEmptySpaces(matrix);
            PrintMatrix(matrix);
        }

        private static void RemoveEmptySpaces(string[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int emptyRows = 0;

                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == " ")
                    {
                        emptyRows++;
                    }
                    else if(emptyRows > 0)
                    {
                        matrix[row + emptyRows, col] = matrix[row, col];
                        matrix[row, col] = " ";
                    }
                }
            }
        }

        static void Shoot(string[,] matrix, int[] shot)
        {
            int row = shot[0];
            int column = shot[1];
            int radius = shot[2];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int a = row - r;
                    int b = column - col;

                    double distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

                    if (distance <= radius)
                    {
                        matrix[r, col] = " ";
                    }
                }
            }
        }

        static void FillMatrix(string[,] matrix, string snake, int rowCount, int columnCount)
        {
            bool isGoingLeft = true;
            int snakeIndex = 0;

            for (int row = rowCount - 1; row >= 0; row--)
            {
                int index = isGoingLeft ? matrix.GetLength(1) - 1 : 0;
                int increment = isGoingLeft ? -1 : 1;

                for (int i = 0; i < columnCount; i++)
                {
                    matrix[row, index] = snake[snakeIndex].ToString();
                    snakeIndex++;
                    if (snakeIndex >= snake.Length)
                    {
                        snakeIndex = 0;
                    }
                    index += increment;
                }
                isGoingLeft = !isGoingLeft;
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int  col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
