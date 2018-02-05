using System;
using System.IO;

namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    string line = reader.ReadLine();

                    int lineCount = 1;

                    while (line != null)
                    {
                        writer.WriteLine($"Line {lineCount}: {line}");
                        lineCount++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
