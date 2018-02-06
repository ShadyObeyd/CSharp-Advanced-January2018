using System;
using System.Linq;

namespace _08.RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static char[,] lair;
        static int playerRow;
        static int playerCol;
        static int rowsCount;
        static int columnsCount;

        static void Main()
        {
            int[] lairSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            rowsCount = lairSize[0];
            columnsCount = lairSize[1];

            lair = new char[rowsCount, columnsCount];

            PopulateLair(rowsCount, columnsCount);

            string commandInput = Console.ReadLine();

            foreach (char command in commandInput)
            {
                int[] previousLocation = MovePlayer(command);
                ReproduceBunnies();

                if (PlayerIsInLair())
                {
                    if (lair[playerRow, playerCol] == 'B')
                    {
                        PlayerDies();
                    }
                    continue;
                }

                PlayerWins(previousLocation);
            }
        }

        private static void PlayerWins(int[] previousLocation)
        {
            int row = previousLocation[0];
            int col = previousLocation[1];

            PrintLair();
            Console.WriteLine($"won: {row} {col}");
            Environment.Exit(0);
        }

        static void PlayerDies()
        {
            PrintLair();
            Console.WriteLine($"dead: {playerRow} {playerCol}");
            Environment.Exit(0);
        }

        static bool PlayerIsInLair()
        {
            bool rowIsValid = playerRow >= 0 && playerRow < rowsCount;
            bool colIsValid = playerCol >= 0 && playerCol < columnsCount;

            if (rowIsValid && colIsValid)
            {
                return true;
            }
            return false;
        }

        static void ReproduceBunnies()
        {
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        if (row > 0)
                        {
                            CreateNewBunny(row - 1, col);
                        }

                        if (row < rowsCount - 1)
                        {
                            CreateNewBunny(row + 1, col);
                        }

                        if (col > 0)
                        {
                            CreateNewBunny(row, col - 1);
                        }

                        if (col < columnsCount - 1)
                        {
                            CreateNewBunny(row, col + 1);
                        }
                    }
                }
            }

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    if (lair[row, col] == 'A')
                    {
                        lair[row, col] = 'B';
                    }
                }
            }
        }

        static void CreateNewBunny(int rowIndex, int colIndex)
        {
            if (lair[rowIndex, colIndex] != 'B')
            {
                lair[rowIndex, colIndex] = 'A';
            }
        }

        static int[] MovePlayer(char command)
        {
            int[] previousLocation = { playerRow, playerCol };

            switch (command)
            {
                case 'U':
                    playerRow--;
                    break;
                case 'D':
                    playerRow++;
                    break;
                case 'L':
                    playerCol--;
                    break;
                case 'R':
                    playerCol++;
                    break;
            }

            if (PlayerIsInLair() && lair[playerRow, playerCol] != 'B')
            {
                lair[playerRow, playerCol] = 'P';
            }

            int oldPlayerRow = previousLocation[0];
            int oldPlayerCol = previousLocation[1];

            lair[oldPlayerRow, oldPlayerCol] = '.';

            return previousLocation;
        }

        static void PopulateLair(int rowsCount, int columnsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                char[] elementsPerRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < columnsCount; col++)
                {
                    lair[row, col] = elementsPerRow[col];
                    if (elementsPerRow[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }

        static void PrintLair()
        {
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}