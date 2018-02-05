using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static char[,] lair;
        static void Main()
        {
            // Not finished!!!
            int[] lairSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowsCount = lairSize[0];
            int columnsCount = lairSize[1];

            lair = new char[rowsCount, columnsCount];

            PopulateLair(rowsCount, columnsCount);

            string commandInput = Console.ReadLine();

            PlayTheGame(commandInput);
        }

        static void PlayTheGame(string commandInput)
        {
            bool hasWon = false;
            bool isDead = false;
            for (int i = 0; i < commandInput.Length; i++)
            {
                int[] playerIndexes = FindPlayerPosition();

                int rowIndex = playerIndexes[0];
                int columnIndex = playerIndexes[1];

                switch (commandInput[i])
                {
                    case 'U':
                        if (rowIndex == 0)
                        {
                            hasWon = true;
                        }
                        else if (lair[rowIndex - 1, columnIndex] == 'B')
                        {
                            rowIndex = rowIndex - 1;
                            isDead = true;
                        }
                        else
                        {
                            MoveUp(rowIndex, columnIndex);
                        }
                        break;
                    case 'D':
                        if (rowIndex == lair.GetLength(0) - 1)
                        {
                            hasWon = true;
                        }
                        else if (lair[rowIndex + 1, columnIndex] == 'B')
                        {
                            rowIndex = rowIndex + 1;
                            isDead = true;
                        }
                        else
                        {
                            MoveDown(rowIndex, columnIndex);
                        }
                        break;
                    case 'L':
                        if (columnIndex == 0)
                        {
                            hasWon = true;
                        }
                        else if (lair[rowIndex, columnIndex - 1] == 'B')
                        {
                            columnIndex = columnIndex - 1;
                            isDead = true;
                        }
                        else
                        {
                            MoveLeft(rowIndex, columnIndex);
                        }
                        break;
                    case 'R':
                        if (columnIndex == lair.GetLength(1) - 1)
                        {
                            hasWon = true;
                        }
                        else if (lair[rowIndex, columnIndex + 1] == 'B')
                        {
                            columnIndex = columnIndex - 1;
                            isDead = true;
                        }
                        else
                        {
                            MoveRight(rowIndex, columnIndex);
                        }
                        break;
                }
                ReproduceBunnies();

                if (isDead)
                {
                    PrintLair();
                    Console.WriteLine($"dead: {rowIndex} {columnIndex}");
                    return;
                }
                else if (hasWon)
                {
                    int lastRowIndex = rowIndex;
                    int lastColIndex = columnIndex;
                    lair[rowIndex, columnIndex] = '.';
                    PrintLair();
                    Console.WriteLine($"won: {lastRowIndex} {lastColIndex}");
                    return;
                }
            }
        }

        static void ReproduceBunnies()
        {
            Dictionary<int, int[]> indexesAndOccurances = new Dictionary<int, int[]>();
            int occurances = 1;
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        indexesAndOccurances.Add(occurances, new int[2]);
                        indexesAndOccurances[occurances][0] = row;
                        indexesAndOccurances[occurances][1] = col;
                        occurances++;
                    }
                }
            }

            foreach (KeyValuePair<int, int[]> item in indexesAndOccurances)
            {
                int[] indexes = item.Value;

                int currentRow = indexes[0];
                int currentCol = indexes[1];

                if (currentRow != 0)
                {
                    lair[currentRow - 1, currentCol] = 'B';
                }
                if (currentRow != lair.GetLength(0) - 1)
                {
                    lair[currentRow + 1, currentCol] = 'B';
                }
                if (currentCol != 0)
                {
                    lair[currentRow, currentCol - 1] = 'B';
                }
                if (currentCol != lair.GetLength(1) - 1)
                {
                    lair[currentRow, currentCol + 1] = 'B';
                }
            }
        }

        static void MoveRight(int rowIndex, int columnIndex)
        {
            char player = lair[rowIndex, columnIndex];
            lair[rowIndex, columnIndex] = lair[rowIndex, columnIndex + 1];
            lair[rowIndex, columnIndex + 1] = player;
        }

        static void MoveLeft(int rowIndex, int columnIndex)
        {
            char player = lair[rowIndex, columnIndex];
            lair[rowIndex, columnIndex] = lair[rowIndex, columnIndex - 1];
            lair[rowIndex, columnIndex - 1] = player;
        }

        static void MoveDown(int rowIndex, int columnIndex)
        {
            char player = lair[rowIndex, columnIndex];
            lair[rowIndex, columnIndex] = lair[rowIndex + 1, columnIndex];
            lair[rowIndex + 1, columnIndex] = player;
        }

        static void MoveUp(int rowIndex, int columnIndex)
        {
            char player = lair[rowIndex, columnIndex];
            lair[rowIndex, columnIndex] = lair[rowIndex - 1, columnIndex];
            lair[rowIndex - 1, columnIndex] = player;
        }

        static int[] FindPlayerPosition()
        {
            int[] playerIndexes = new int[2];
            bool foundPlayer = false;

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'P')
                    {
                        playerIndexes[0] = row;
                        playerIndexes[1] = col;
                        foundPlayer = true;
                        break;
                    }
                }

                if (foundPlayer)
                {
                    break;
                }
            }

            return playerIndexes;
        }

        static void PopulateLair(int rowsCount, int columnsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < columnsCount; col++)
                {
                    lair[row, col] = input[col];
                }
            }
        }

        static void PrintLair()
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}