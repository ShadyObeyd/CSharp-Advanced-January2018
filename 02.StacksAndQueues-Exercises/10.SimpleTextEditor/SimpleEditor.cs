using System;
using System.Collections.Generic;
using System.Text;

namespace _10.SimpleTextEditor
{
    class SimpleEditor
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> undoLog = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] inputTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputTokens[0] == "1")
                {
                    undoLog.Push(text.ToString());
                    string toAppend = inputTokens[1];

                    text.Append(toAppend);
                }
                else if (inputTokens[0] == "2")
                {
                    undoLog.Push(text.ToString());
                    int count = int.Parse(inputTokens[1]);

                    text = text.Remove(text.Length - count, count);
                }
                else if (inputTokens[0] == "3")
                {
                    int index = int.Parse(inputTokens[1]) - 1;
                    Console.WriteLine(text[index]);
                }
                else if (inputTokens[0] == "4")
                {
                    text.Clear();
                    text.Append(undoLog.Pop().ToString());
                }

            }
        }
    }
}
