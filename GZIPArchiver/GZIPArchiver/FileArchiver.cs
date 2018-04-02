using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Threading;

namespace GZIPArchiver
{
    static class FileArchiver
    {
        static object lock_ = new object();
        private static SemaphoreSlim processingSemaphore = new SemaphoreSlim(1, 1);

        public static async Task Compress(string originalFileName, string archiveFile, int amountOfData)
        {
            lock (lock_)
            {
                using (FileStream originalFile = new FileStream(originalFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (FileStream archFile = new FileStream(archiveFile, FileMode.Create, FileAccess.Write, FileShare.Write))
                    {
                        using (GZipStream compressionStream = new GZipStream(archFile, CompressionMode.Compress))
                        {
                            for (int i = 0; i < originalFile.Length / amountOfData; i++)
                            {
                                var buffer = new byte[amountOfData]; // create a buffer for a read data
                                int bytesRead;

                                // if there are some bytes read, then we write those bytes which was read in a buffer to the file.

                                for (int x = 0; x < originalFile.Length / amountOfData; x++)
                                {
                                    new Thread(async () =>
                                        {
                                            await processingSemaphore.WaitAsync();
                                            try
                                            {
                                                if ((bytesRead = await originalFile.ReadAsync(buffer, 0, buffer.Length)) > 0)
                                                {
                                                    Console.WriteLine(bytesRead.ToString()); // Debug feature. It writes a block which was read from a file.
                                                    await compressionStream.WriteAsync(buffer, 0, buffer.Length); // write to the archive through a compression stream.
                                                }
                                            }
                                            finally
                                            {
                                                processingSemaphore.Release();
                                            }
                                        }).Start();
                                }
                            }
                        }
                    }
                }
            }

        }

        public static async Task Decompress(string unpackFile, string result, long chunkSize)
        {
            lock (lock_)
            {
                using (FileStream resultingFile = new FileStream(result, FileMode.Create, FileAccess.Write, FileShare.Write))
                {
                    using (FileStream unpFile = new FileStream(unpackFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (GZipStream decompressionStream = new GZipStream(unpFile, CompressionMode.Decompress))
                        {
                            for (int x = 0; x < unpFile.Length / chunkSize; x++)
                            {
                                byte[] buffer = new byte[chunkSize];
                                int bytesRead;

                                if ((bytesRead = decompressionStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    Console.WriteLine(bytesRead.ToString());
                                    resultingFile.WriteAsync(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
