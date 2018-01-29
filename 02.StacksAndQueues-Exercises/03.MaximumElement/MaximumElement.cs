using System;
using System.Collections.Generic;

namespace _03.MaximumElement
{
    class MaximumElement
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbersStack = new Stack<int>();
            Stack<int> maxStack = new Stack<int>();

            maxStack.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "1")
                {
                    int element = int.Parse(input[1]);
                    numbersStack.Push(element);
                    if (element >= maxStack.Peek())
                    {
                        maxStack.Push(element);
                    }
                }
                else if (input[0] == "2")
                {
                    int poppedElement = numbersStack.Pop();
                    if (poppedElement == maxStack.Peek())
                    {
                        maxStack.Pop();
                    }
                }
                else if (input[0] == "3")
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}
