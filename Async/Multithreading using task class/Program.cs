using System;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_using_task_class
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task task1 = Task.Run(() => DownloadFile("Chrome"));

            Task task2 = Task.Run(() => DownloadFile("C++ config"));

            await Task.WhenAll(task1, task2);

            Console.WriteLine("All Download finished");
            Console.ReadKey();
        }

        static void DownloadFile(string FileName)
        {
            Console.WriteLine($"Downloading file: {FileName} started");
            Thread.Sleep(2000);
            Console.WriteLine("Download finished");
        }
    }
}
