using System;
using System.IO;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../text.txt"))
            {
                string line = reader.ReadLine();

                int lineCount = 0;
                while (line != null)
                {
                    if (lineCount % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    lineCount++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
