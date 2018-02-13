using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.KeyRevolver
{
    class KeyRevolver
    {
        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int intelligenceSum = int.Parse(Console.ReadLine());


            int bulletsUsed = 0;

            int cntr = 1;

            while (true)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                if (currentBullet > currentLock)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                bulletsUsed++;

                if (cntr % barrelSize == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                }
                cntr++;

                if (!locks.Any())
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceSum - (bulletsUsed * bulletPrice)}");
                    break;
                }

                if (!bullets.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
            }
        }
    }
}