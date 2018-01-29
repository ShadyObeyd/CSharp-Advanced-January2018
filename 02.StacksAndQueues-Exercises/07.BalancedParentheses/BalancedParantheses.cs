using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParentheses
{
    class BalancedParantheses
    {
        static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            char[] openingBrackets = new char[] { '(', '{', '[' };
            char[] closingBrackets = new char[] { ')', '}', ']' };

            Stack<char> stack = new Stack<char>();

            foreach (char symbol in input)
            {
                if (openingBrackets.Contains(symbol))
                {
                    stack.Push(symbol);
                }
                else if(closingBrackets.Contains(symbol))
                {
                    char lastSymbol = stack.Pop();

                    int openingBracketIndex = Array.IndexOf(openingBrackets, lastSymbol);
                    int closingBracketIndex = Array.IndexOf(closingBrackets, symbol);

                    if (openingBracketIndex != closingBracketIndex)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
