using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockChain
{
    class CryptoBlockChain
    {
        static void Main()
        {
            Regex pattern = new Regex(@"{[^\[\]\{\}]*?(?<numbers>\d{3,})[^\[\]\{\}]*}|\[[^\[\]\{\}]*?(?<numbers>\d{3,})[^\[\]\{\}]*\]");

            int n = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                result.Append(input);
            }

            MatchCollection matches = pattern.Matches(result.ToString());

            StringBuilder finalResult = new StringBuilder();

            foreach (Match match in matches)
            {
                string numbers = match.Groups["numbers"].Value;
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < numbers.Length; i += 3)
                {
                    char firstDigit = numbers[i];
                    char secondDigit = numbers[i + 1];
                    char thirdDigit = numbers[i + 2];

                    string number = firstDigit.ToString() + secondDigit.ToString() + thirdDigit.ToString();

                    int numberResult = int.Parse(number);

                    int wantedAsciiCode = numberResult - match.Length;
                    finalResult.Append((char)wantedAsciiCode);
                }
            }

            Console.WriteLine(finalResult);
        }
    }
}