using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int NumberOfIterations = 10;
            List<string> Urls = new List<string>
            {
                "https://www.cnn.com",
                "https://www.amazon.com",
                "https://www.github.com",

            };
            // parallel for
            Parallel.For(0, NumberOfIterations, (i) =>
            {
                Console.WriteLine($"Iteration {i} on thread {Task.CurrentId}");
            });

            //parallel for each
            Parallel.ForEach(Urls, url => { DownloadWebPage(url);});

            //parallel invoke

            Parallel.Invoke(Sum, Factorial);

            Console.ReadKey();
        }
        static void DownloadWebPage(string Url) 
        {
            using (WebClient Client = new WebClient()) 
            {
                string Content = Client.DownloadString(Url);
                Console.WriteLine($"{Url} char count is: {Content.Length}");
            }
            
        }
        static void Sum()
        {
            int Sum = 0;
            for (int i = 0; i < 100000; i++)
            {
                Sum += i;
            }
            Console.WriteLine($"Sum from 1 to 99999 is : {Sum}");
        }

        static void Factorial()
        {
            int Factorial = 1;
            for (int i = 10; i > 1; i--)
            {
                Factorial *= i;
            }
            Console.WriteLine($"Factorial 10 is : {Factorial}");
        }
    }
}
