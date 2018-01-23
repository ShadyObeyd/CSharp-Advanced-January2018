using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> openBracketsIndex = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openBracketsIndex.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = openBracketsIndex.Pop();
                    int length = i - startIndex + 1;
                    string result = input.Substring(startIndex, length);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
