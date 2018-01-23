using System;
using System.Collections.Generic;

namespace _03.DecimalToBinaryConverter
{
    class DecimalToBinaryConverter
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (input == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (input > 0)
            {
                stack.Push(input % 2);
                input /= 2;
            }
            Console.Write(string.Join("", stack));
            Console.WriteLine();
        }
    }
}
