using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.TruckTour
{
    class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pump = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                pumps.Enqueue(pump);
            }

            for (int currentStart = 0; currentStart < n - 1; currentStart++)
            {
                int fuel = 0;
                bool foundBestStart = true;

                for (int pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                {
                    int[] currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);

                    int curentFuelQuantity = currentPump[0];
                    int nextPumpDistance = currentPump[1];

                    fuel += curentFuelQuantity - nextPumpDistance;

                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        foundBestStart = false;
                        break;
                    }
                }

                if (foundBestStart)
                {
                    Console.WriteLine(currentStart);
                    break;
                }
            }
        }
    }
}
