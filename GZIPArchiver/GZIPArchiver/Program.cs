using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GZIPArchiver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string action = args[0];
                string file = args[1];
                string archive = Directory.GetCurrentDirectory() + args[1] + ".gz";

                try
                {
                    if (action == "compress")
                    {
                        MultithreadedArchiver.MultithreadedCompress(file, archive, (int)MainAppConstants.chunkSize);
                        Console.WriteLine("Completed.");
                    }
                    else if (action == "decompress")
                    {
                        MultithreadedArchiver.MultithreadedDecompress(file, Path.GetFileNameWithoutExtension(file), (long)MainAppConstants.chunkSize);
                    }
                    else
                    {
                        throw new System.ArgumentException("You've entered the wrong command");
                    }
                }
                catch (System.ArgumentException e)
                {
                    Console.WriteLine("You've entered the wrong command. Exiting...");
                    Environment.Exit(0);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("You've entered wrong number of commands. Exiting...");
                Environment.Exit(0);
            }

            //MultithreadedArchiver.MultithreadedDecompress(Directory.GetCurrentDirectory() + "\\cha.exe.gz", Directory.GetCurrentDirectory() + "\\ch.exe", (int)MainAppConstants.chunkSize);
        }
    }
}
