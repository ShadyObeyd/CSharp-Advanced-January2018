using System;
using System.Collections.Generic;

namespace _06.TrafficLight
{
    class TrafficLight
    {
        static void Main()
        {
            int carsPerGreenLight = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> carQueue = new Queue<string>();

            int cntr = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    PassCars(carsPerGreenLight, carQueue, ref cntr);
                }
                else
                {
                    carQueue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{cntr} cars passed the crossroads.");
        }

        private static void PassCars(int carsPerGreenLight, Queue<string> carQueue, ref int cntr)
        {
            int carsToPass = Math.Min(carsPerGreenLight, carQueue.Count);

            for (int i = 0; i < carsToPass; i++)
            {
                Console.WriteLine($"{carQueue.Dequeue()} passed!");
                cntr++;
            }
        }
    }
}
