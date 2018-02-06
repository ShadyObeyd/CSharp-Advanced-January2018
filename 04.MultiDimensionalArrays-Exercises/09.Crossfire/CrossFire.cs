using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire
{
    class Crossfire
    {
        static void Main()
        {
            int[] jaggedListSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowsCount = jaggedListSize[0];
            int columnsCount = jaggedListSize[1];

            List<List<int>> jaggedList = FillList(rowsCount, columnsCount);

            string command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                int[] commandTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int bombRow = commandTokens[0];
                int bombCol = commandTokens[1];
                int radius = commandTokens[2];

                BombEmGood(bombRow, bombCol, radius, jaggedList);

                command = Console.ReadLine();
            }

            for (int i = 0; i < jaggedList.Count; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedList[i]));
            }
        }

        static void BombEmGood(int bombRow, int bombCol, int radius, List<List<int>> jaggedList)
        {
            for (int i = 0; i < jaggedList.Count; i++)
            {
                List<int> currentList = jaggedList[i];

                for (int j = 0; j < currentList.Count; j++)
                {
                    if ((i == bombRow && Math.Abs(j - bombCol) <= radius) ||
                        (j == bombCol && Math.Abs(i - bombRow) <= radius))
                    {
                        jaggedList[i][j] = 0;
                    }
                }
            }

            for (int i = 0; i < jaggedList.Count; i++)
            {
                jaggedList[i].RemoveAll(n => n == 0);
                if (jaggedList[i].Count == 0)
                {
                    jaggedList.RemoveAt(i);
                    i--;
                }
            }
        }

        static List<List<int>> FillList(int rowsCount, int columnsCount)
        {
            List<List<int>> jaggedList = new List<List<int>>();
            int number = 1;

            for (int row = 0; row < rowsCount; row++)
            {
                List<int> currentList = new List<int>();

                for (int i = 0; i < columnsCount; i++)
                {
                    currentList.Add(number);
                    number++;
                }
                jaggedList.Add(currentList);
            }
            return jaggedList;
        }
    }
}