using System;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    class TreasureMap
    {
        static void Main()
        {
            Regex pattern = new Regex(@"#[^!#]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?!|![^!#]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?#");



            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = pattern.Matches(input);

                Match matchNeeded = matches[matches.Count / 2];

                string streetName = matchNeeded.Groups["streetName"].Value;
                string streetNumber = matchNeeded.Groups["streetNumber"].Value;
                string password = matchNeeded.Groups["password"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }
    }
}