using System;
using System.IO;
using System.Text;

namespace _04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main()
        {
            using (FileStream source = new FileStream("../copyMe.png", FileMode.Open))
            {
                using (FileStream destination = new FileStream("./ICopiedYou.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
