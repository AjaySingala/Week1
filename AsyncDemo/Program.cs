using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleAsyncDemo();
            FileAsyncDemo();
            //ParallelForDemo();

            Console.WriteLine("Press <ENTER>...");
            Console.ReadLine();
        }

        static void FileAsyncDemo()
        {
            // Start the async method.
            Task<int> task = HandleFileAsync();

            // Control returns here before HandleFileAsync returns.
            Console.WriteLine("Be patient. Processing the file...");

            // Do something at the same time as the file is being read + processed.
            Console.WriteLine("This is where you perform your logic while the file is processed.");
            Console.WriteLine("Enter some text: ");
            string text = Console.ReadLine();
            Console.WriteLine($"You entered: {text}");
            Console.WriteLine();

            // Wait for the HandleFile task to complete.
            // Display its results.
            task.Wait();

            var x = task.Result;
            Console.WriteLine("Count: " + x);

            Console.WriteLine("[DONE]");
        }

        // static async Task<IList<Customer>> ReadCustomers()
        // {

        // }
        static async Task<int> HandleFileAsync()
        {
            Console.WriteLine("Entering HandleFileAsync()...");

            string file = @"D:\Users\AjayS\Tryouts\dotNET_Basics\BasicDemos\AsyncDemo\DemoFile.txt";
            int count = 0;

            // Read the specified file.
            using (StreamReader reader = new StreamReader(file))
            {
                string content = await reader.ReadToEndAsync();

                count += content.Length;

                // A slow running process.
                for (int i = 0; i < 10000; i++)
                {
                    int x = content.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("Exiting HandleFileAsync()...");
            return count;
        }

        // The example displays output like the following:
        //       Hello from thread 'Main'.
        //       Hello from taskA.            
        static void SimpleAsyncDemo()
        {
            Thread.CurrentThread.Name = "Main";

            // Define and run the task.
            // Using Task.Run().
            //Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA."));
            Task taskA = Task.Run(() => HoldOn("taskA"));

            // // Better: Create and start the task in one operation. 
            // // Using Task.Factory.StartNew().
            // Task taskA = Task.Factory.StartNew(() => Console.WriteLine("Hello from taskA."));

            // Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.",
                                Thread.CurrentThread.Name);
            taskA.Wait();
        }

        static void HoldOn(string taskName)
        {
            Thread.Sleep(10000);
            Console.WriteLine($"Hello from {taskName} -> HoldOn().");
        }

        // The example displays output like the following:
        //       Directory 'c:\windows\':
        //       32 files, 6,587,222 bytes
        static void ParallelForDemo()
        {
            long totalSize = 0;

            String path = @"D:\Temp";
            if (!Directory.Exists(path))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            // Parallel.For method enumerates the files in the directory 
            // and determine their file sizes.
            // Each file size is then added to the totalSize variable.
            // Note that the addition is performed by calling the Interlocked.
            // Add so that the addition is performed as an atomic operation.
            // Otherwise, multiple tasks could try to update the totalSize variable
            // simultaneously.
            String[] files = Directory.GetFiles(path);
            Parallel.For(0, files.Length,
                         index =>
                         {
                             FileInfo fi = new FileInfo(files[index]);
                             long size = fi.Length;
                             Interlocked.Add(ref totalSize, size);
                         });
            Console.WriteLine("Directory '{0}':", path);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
        }
    }
}
