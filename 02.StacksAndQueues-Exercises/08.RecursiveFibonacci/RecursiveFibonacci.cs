using System;

namespace _08.RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        static long[] fibonacci;
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            fibonacci = new long[n];
            fibonacci[0] = 1;

            if (n > 1)
            {
                fibonacci[1] = 1;
            }

            long result = FindFibonacci(n - 1);

            Console.WriteLine(result);
        }

        static long FindFibonacci(long n)
        {
            if (fibonacci[n] == 0)
            {
                fibonacci[n] = FindFibonacci(n - 1) + FindFibonacci(n - 2);
            }
            return fibonacci[n];
        }
    }
}
