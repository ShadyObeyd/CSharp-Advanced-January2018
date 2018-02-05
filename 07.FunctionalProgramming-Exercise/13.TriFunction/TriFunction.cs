using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.TriFunction
{
    class TriFunction
    {
        static void Main()
        {
            int sum = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string name = names.Where(n => n.ToCharArray().Sum(c => c) >= sum).FirstOrDefault();

            Console.WriteLine(name);
        }
    }
}