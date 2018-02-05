using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main()
        {
            List<string> words = new List<string>();
            using (StreamReader wordsReader = new StreamReader("../words.txt"))
            {
                string word = wordsReader.ReadLine();

                while (word != null)
                {
                    words.Add(word);
                    word = wordsReader.ReadLine();
                }
            }
            Dictionary<string, int> wordAndOccurance = new Dictionary<string, int>();

            using (StreamReader textReader = new StreamReader("../text.txt"))
            {
                string line = textReader.ReadLine();

                while (line != null)
                {   
                    string[] lineTokens = Regex.Split(line, "[^A-Za-z']+").Select(x => x.ToLower()).ToArray();

                    foreach (string word in words)
                    {
                        int count = 1;
                        foreach (string lineToken in lineTokens)
                        {
                            if (lineToken == word)
                            {
                                if (!wordAndOccurance.ContainsKey(word))
                                {
                                    wordAndOccurance.Add(word, count);
                                }
                                else
                                {
                                    wordAndOccurance[word]++;
                                }
                            }
                        }
                    }
                    line = textReader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                foreach (KeyValuePair<string, int> item in wordAndOccurance.OrderByDescending(v => v.Value))
                {
                    string word = item.Key;
                    int occurance = item.Value;

                    writer.WriteLine($"{word} - {occurance}");
                }
            }
        }
    }
}
