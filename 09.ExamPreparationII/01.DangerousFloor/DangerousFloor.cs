using System;
using System.Linq;

namespace _01.DangerousFloor
{
    class DangerousFloor
    {
        static char[,] board;
        static void Main()
        {
            board = new char[8, 8];

            for (int row = 0; row < 8; row++)
            {
                char[] boardRow = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = boardRow[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                char[] inputTokens = input.ToCharArray();

                char figure = inputTokens[0];

                int figureRow = int.Parse(inputTokens[1].ToString());
                int figureCol = int.Parse(inputTokens[2].ToString());

                int rowToMove = int.Parse(inputTokens[4].ToString());
                int colToMove = int.Parse(inputTokens[5].ToString());

                if (!IsOnBoard(figure, figureRow, figureCol))
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (InvalidMove(figure, figureRow, figureCol, rowToMove, colToMove))
                {
                    Console.WriteLine("Invalid move!");
                }
                else if (GetsOutOfBoard(figure, figureRow, figureCol, rowToMove, colToMove))
                {
                    Console.WriteLine("Move go out of board!");
                }
                else
                {
                    MoveFigure(figure, figureRow, figureCol, rowToMove, colToMove);
                }
                input = Console.ReadLine();
            }
        }

        static void MoveFigure(char figure, int figureRow, int figureCol, int rowToMove, int colToMove)
        {
            board[figureRow, figureCol] = 'x';
            board[rowToMove, colToMove] = figure;
        }

        static bool GetsOutOfBoard(char figure, int figureRow, int figureCol, int rowToMove, int colToMove)
        {
            if (!CheckIndex(rowToMove) || !CheckIndex(colToMove))
            {
                return true;
            }
            return false;
        }

        static bool InvalidMove(char figure, int figureRow, int figureCol, int rowToMove, int colToMove)
        {
            if (figure == 'K')
            {
                if (colToMove == figureCol + 1 && rowToMove == figureRow)
                {
                    return false;
                }
                else if (colToMove == figureCol - 1 && rowToMove == figureRow)
                {
                    return false;
                }
                else if (rowToMove == figureRow + 1 && colToMove == figureCol)
                {
                    return false;
                }
                else if (rowToMove == figureRow - 1 && colToMove == figureCol)
                {
                    return false;
                }
                else if (rowToMove == figureRow + 1 && colToMove == figureCol + 1)
                {
                    return false;
                }
                else if (rowToMove == figureRow - 1 && colToMove == figureCol - 1)
                {
                    return false;
                }
                else if (rowToMove == figureRow + 1 && colToMove == figureCol - 1)
                {
                    return false;
                }
                else if (rowToMove == figureRow - 1 && colToMove == figureCol + 1)
                {
                    return false;
                }
                return true;
            }
            else if (figure == 'R')
            {
                if (rowToMove > figureRow && colToMove == figureCol)
                {
                    return false;
                }
                else if (rowToMove < figureRow && colToMove == figureCol)
                {
                    return false;
                }
                else if (colToMove > figureCol && rowToMove == figureRow)
                {
                    return false;
                }
                else if (colToMove < figureCol && rowToMove == figureRow)
                {
                    return false;
                }
                return true;
            }
            else if (figure == 'B')
            {
                if (rowToMove > figureRow && colToMove > figureCol)
                {
                    return false;
                }
                else if (rowToMove < figureRow && colToMove < figureCol)
                {
                    return false;
                }
                else if (rowToMove > figureRow && colToMove < figureCol)
                {
                    return false;
                }
                else if (rowToMove < figureRow && colToMove > figureCol)
                {
                    return false;
                }
                return true;
            }
            else if (figure == 'Q')
            {
                int rowDiff = Math.Abs(figureRow - rowToMove);
                int colDiff = Math.Abs(figureCol - colToMove);

                if (rowToMove > figureRow && colToMove == figureCol)
                {
                    return false;
                }
                else if (rowToMove < figureRow && colToMove == figureCol)
                {
                    return false;
                }
                else if (colToMove > figureCol && rowToMove == figureRow)
                {
                    return false;
                }
                else if (colToMove < figureCol && rowToMove == figureRow)
                {
                    return false;
                }
                else if (rowToMove > figureRow && colToMove > figureCol && rowDiff == colDiff)
                {
                    return false;
                }
                else if (rowToMove < figureRow && colToMove < figureCol && rowDiff == colDiff)
                {
                    return false;
                }
                else if (rowToMove > figureRow && colToMove < figureCol && rowDiff == colDiff)
                {
                    return false;
                }
                else if (rowToMove < figureRow && colToMove > figureCol && rowDiff == colDiff)
                {
                    return false;
                }
                return true;
            }
            else if (figure == 'P')
            {
                if (rowToMove == figureRow - 1 && colToMove == figureCol)
                {
                    return false;
                }
                return true;
            }
            else
            {
                throw new FormatException();
            }
        }

        static bool IsOnBoard(char figure, int figureRow, int figureCol)
        {
            bool isOnBoard = CheckIndex(figureRow) && CheckIndex(figureCol);
            bool containsFigure = board[figureRow, figureCol] == figure;

            if (isOnBoard && containsFigure)
            {
                return true;
            }
            return false;
        }

        static bool CheckIndex(int index)
        {
            return index >= 0 && index < 8;
        }
    }
}