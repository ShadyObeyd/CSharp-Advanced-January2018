using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main()
        {
            string dir = Console.ReadLine();
            var data = new Dictionary<string, Dictionary<string, double>>();

            string[] filesDir = Directory.GetFiles(dir);

            foreach (string file in filesDir)
            {
                string extension = file.Substring(file.LastIndexOf('.') + 1);

                if (!data.ContainsKey(extension))
                {
                    data.Add(extension, new Dictionary<string, double>());
                }
                FileInfo info = new FileInfo(file);
                double size = info.Length / 1024.0;

                if (dir == "." || dir == "./")
                {
                    data[extension].Add(file.Substring(2), size);
                }
                else
                {
                    data[extension].Add(file.Substring(file.LastIndexOf('\\') + 1), size);
                }

            }
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string report = Path.Combine(desktopPath, "report.txt");

            using (StreamWriter writer = new StreamWriter(report))
            {
                foreach (var item in data.OrderByDescending(f => f.Value.Keys.Count).ThenBy(n => n.Key))
                {
                    string extension = item.Key;
                    Dictionary<string, double> filesData = item.Value;

                    writer.WriteLine("." + extension);

                    foreach (var files in filesData.OrderBy(s => s.Value))
                    {
                        string file = files.Key;
                        double size = files.Value;

                        writer.WriteLine($"--{file} - {size}kb");
                    }
                }
            }
        }
    }
}
