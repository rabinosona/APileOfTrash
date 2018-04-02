using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GZIPArchiver
{
    static class MultithreadedArchiver
    {
        public static void MultithreadedCompress(string originalFileName, string archiveFile, int amountOfData)
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                new Thread(async () =>
                {
                    await FileArchiver.Compress(originalFileName, archiveFile, amountOfData);
                }).Start();
            }
        }

        public static void MultithreadedDecompress(string unpackFile, string result, long chunkSize)
        {
            FileArchiver.Decompress(unpackFile, result, chunkSize);

        }
    }
}
