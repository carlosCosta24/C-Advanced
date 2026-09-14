using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Prameterless thread
            //Thread FirstThread = new Thread(NewThread);

            //FirstThread.Start();
            ////Parameterized Thread

            //for (int i = 0; i < 100; i++) 
            //{
            //    if (i % 10 == 0) 
            //    {
            //        Console.WriteLine($"i:{i}");
            //        Thread.Sleep(1000);
            //    }
            //}

            //Thread SecondThread = new Thread(() => Print("Costa"));
            //SecondThread.Start();

            //void NewThread() 
            //{
            //    for(int i = 0; i < 10; i ++)
            //    { 
            //        Console.WriteLine("Carlos");
            //        Thread.Sleep(500);
            //    }
            //}
            
            //void Print(string s) 
            //{
            //    Console.WriteLine(s);
            //}
            int DownloadWebPage(string Url) 
            {
                using (WebClient Client = new WebClient()) 
                {
                    string Content = Client.DownloadString(Url);
                    return Content.Length;
                }
            }
            Console.WriteLine("Start downloading....");
            Thread t1 = new Thread(() => Console.WriteLine($"Amazon: {DownloadWebPage("https://www.amazon.com")}"));
            t1.Start();

            Thread t2 = new Thread(() => Console.WriteLine($"Cnn: {DownloadWebPage("https://www.cnn.com")}"));
            t2.Start(); 

            Thread t3 = new Thread(() => Console.WriteLine($"Linkedin: {DownloadWebPage("https://www.Linkedin.com")}"));
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("All webpages have been downloaded");
            Console.ReadKey();
        }
    }
}
