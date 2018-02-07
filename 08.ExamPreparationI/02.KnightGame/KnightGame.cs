using System;

namespace _02.KnightGame
{
    class KnightGame
    {
        static char[,] board;
        static int boardSize;

        static void Main()
        {
            boardSize = int.Parse(Console.ReadLine());

            if (boardSize < 3)
            {
                Console.WriteLine('0');
                Environment.Exit(0);
            }

            board = new char[boardSize, boardSize];

            for (int row = 0; row < boardSize; row++)
            {
                char[] elemetsPerRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < boardSize; col++)
                {
                    board[row, col] = elemetsPerRow[col];
                }
            }

            int knightMaxRow = 0;
            int knightMaxCol = 0;
            int maxEliminated = 0;
            int removedKnights = 0;

            do
            {
                if (maxEliminated > 0)
                {
                    board[knightMaxRow, knightMaxCol] = '0';
                    maxEliminated = 0;
                    removedKnights++;
                }

                int currentEliminated = 0;

                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            currentEliminated = CalculateEliminated(row, col);

                            if (currentEliminated > maxEliminated)
                            {
                                maxEliminated = currentEliminated;
                                knightMaxRow = row;
                                knightMaxCol = col;
                            }
                        }
                    }
                }
            } while (maxEliminated > 0);

            Console.WriteLine(removedKnights);
        }

        static int CalculateEliminated(int row, int col)
        {
            int eliminated = 0;

            if (IsAttacked(row - 2, col - 1))
            {
                eliminated++;
            }

            if (IsAttacked(row - 2, col + 1))
            {
                eliminated++;
            }

            if (IsAttacked(row - 1, col - 2))
            {
                eliminated++;
            }

            if (IsAttacked(row - 1, col + 2))
            {
                eliminated++;
            }

            if (IsAttacked(row + 1, col - 2))
            {
                eliminated++;
            }

            if (IsAttacked(row + 1, col + 2))
            {
                eliminated++;
            }

            if (IsAttacked(row + 2, col - 1))
            {
                eliminated++;
            }

            if (IsAttacked(row + 2, col + 1))
            {
                eliminated++;
            }

            return eliminated;
        }

        static bool IsAttacked(int row, int col)
        {
            return isOnBoard(row, col) && board[row, col] == 'K';
        }

        static bool isOnBoard(int row, int col)
        {
            return IsIndexValid(row) && IsIndexValid(col);
        }

        private static bool IsIndexValid(int index)
        {
            return index >= 0 && index < boardSize;
        }
    }
}