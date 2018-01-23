using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            Stack<string> stack = new Stack<string>(input);
            
            while (stack.Count > 1)
            {
                int leftOperand = int.Parse(stack.Pop());
                string operatorr = stack.Pop();
                int rightOperand = int.Parse(stack.Pop());

                string result = string.Empty;

                switch (operatorr)
                {
                    case "+":
                        result = (leftOperand + rightOperand).ToString();
                        stack.Push(result);
                        break;
                    case "-":
                        result = (leftOperand - rightOperand).ToString();
                        stack.Push(result);
                        break;
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
