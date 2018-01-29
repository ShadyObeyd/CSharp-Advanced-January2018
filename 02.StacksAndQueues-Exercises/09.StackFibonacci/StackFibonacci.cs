using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    class StackFibonacci
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            long sum = 0;
            
            for (int i = 1; i < n; i++)
            {
                long lastNum = stack.Pop();
                long previousNum = stack.Pop();

                sum = lastNum + previousNum;

                stack.Push(lastNum);
                stack.Push(sum);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
