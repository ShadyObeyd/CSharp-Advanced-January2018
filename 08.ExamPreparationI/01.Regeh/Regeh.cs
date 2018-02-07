using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Regeh
    {
        static void Main()
        {
            Regex pattern = new Regex(@"\[[^\[\s]+?<(?<firstIndex>[\d]+)REGEH(?<secondIndex>[\d]+)>[^\]\s]+?\]");

            string input = Console.ReadLine();

            MatchCollection matches = pattern.Matches(input);

            int currentIndex = 0;

            StringBuilder result = new StringBuilder();

            foreach (Match match in matches)
            {
                CheckIndex(ref currentIndex, input);

                int firstIndex = int.Parse(match.Groups["firstIndex"].ToString());
                int secondIndex = int.Parse(match.Groups["secondIndex"].ToString());

                CheckIndex(ref firstIndex, input);

                CheckIndex(ref secondIndex, input);

                currentIndex += firstIndex;

                CheckIndex(ref currentIndex, input);

                result.Append(input[currentIndex].ToString());

                currentIndex += secondIndex;

                CheckIndex(ref currentIndex, input);

                result.Append(input[currentIndex].ToString());
            }

            Console.WriteLine(result);
        }
        static void CheckIndex(ref int index, string input)
        {
            if (index >= input.Length)
            {
                index = 0;
            }
        }
    }
}