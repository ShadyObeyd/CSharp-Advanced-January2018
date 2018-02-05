using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08.FullDirectoryTraversal
{
    class FullDirectoryTraversal
    {
        static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, double>>();
            List<string> allFiles = new List<string>();
            string dir = Console.ReadLine();

            string[] filesDir = Directory.GetFiles(dir);
            string[] subDirs = Directory.GetDirectories(dir);

            foreach (var file in filesDir)
            {
                allFiles.Add(file);
            }

            foreach (string currentDir in subDirs)
            {
                string[] currentDirFiles = Directory.GetFiles(currentDir);

                foreach (string file in currentDirFiles)
                {
                    allFiles.Add(file);
                }
            }

            foreach (string file in allFiles)
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
