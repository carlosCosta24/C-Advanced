using System;
using System.Net;
using System.Threading.Tasks;

namespace TaskClass
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Start Downloading.....");

            Task task1 = DownloadWebPagesAsync("https://www.cnn.com", "Cnn");
            Console.WriteLine("Start Downloading cnn");

            Task task2 = DownloadWebPagesAsync("https://www.amazong.com", "Amazon");
            Console.WriteLine("Start Downloading amazon");

            Task task3 = DownloadWebPagesAsync("https://www.github.com", "Github");
            Console.WriteLine("Start Downloading github");

            await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("All downloads finished..");
 

            Console.ReadKey();
        }
        static async Task DownloadWebPagesAsync(string Url, string Name)
        {
            int CharCountintPage = 0;
            string Content;
            using (WebClient Client = new WebClient())
            {
                Content = await Client.DownloadStringTaskAsync(Url);
                CharCountintPage = Content.Length;

            }
            Console.WriteLine($"Total number of char in {Name}: {CharCountintPage}"); 
        }
    }
}
