using System;
using System.Collections.Generic;
using System.IO;

namespace _05.SlicingFile
{
    class SlicingFile
    {
        private const int bufferSize = 4096;
        static void Main()
        {
            string sourceFile = "../sliceMe.mp4";
            List<string> files = new List<string>();

            Slice(sourceFile, string.Empty, 5, files);
            Assemble(files, string.Empty);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts, List<string> files)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                long partSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPartSize = 0;

                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = $"{destinationDirectory}Part-{i}.{extension}";
                    files.Add(currentPart);

                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferSize];

                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPartSize += bufferSize;

                            if (currentPartSize >= partSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            if (destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string assembledFile = $"{destinationDirectory}Assembled.{extension}";

            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];

                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }
    }
}
