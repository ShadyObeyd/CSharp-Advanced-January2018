using System;
using System.Linq;
using System.Text;

namespace _01.MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main()
        {
            int[] inputData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowsCount = inputData[0];
            int columnsCount = inputData[1];

            StringBuilder[,] matrix = new StringBuilder[rowsCount, columnsCount];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < rowsCount; row++)
            {
                for (int column = 0; column < columnsCount; column++)
                {
                    matrix[row, column] = new StringBuilder();
                    matrix[row, column].Append(alphabet[row]);
                    matrix[row, column].Append(alphabet[row + column]);
                    matrix[row, column].Append(alphabet[row]);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}