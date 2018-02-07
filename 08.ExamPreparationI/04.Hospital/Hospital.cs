using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Hospital
    {
        static void Main()
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Output")
            {
                string[] inputTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string department = inputTokens[0];
                string doctor = inputTokens[1] + " " + inputTokens[2];
                string patient = inputTokens[3];

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<string>());
                }
                departments[department].Add(patient);

                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new List<string>());
                }
                doctors[doctor].Add(patient);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string department = commandTokens[0];

                if (commandTokens.Length == 1)
                {
                    foreach (string patient in departments[department])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    int roomNum;

                    if (int.TryParse(commandTokens[1], out roomNum))
                    {
                        int toSkip = 3 * (roomNum - 1);

                        foreach (string patient in departments[department].Skip(toSkip).Take(3).OrderBy(p => p))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        foreach (string patient in doctors[input].OrderBy(p => p))
                        {
                            Console.WriteLine(patient);
                        }

                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}