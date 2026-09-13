using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(NewThread);

            t.Start();
            for (int i = 0; i < 100; i++) 
            {
                if (i % 10 == 0) 
                {
                    Console.WriteLine($"i:{i}");
                    Thread.Sleep(1000);
                }
            }

            void NewThread() 
            {
                for(int i = 0; i < 10; i ++)
                { 
                    Console.WriteLine("Calos");
                    Thread.Sleep(500);
                }
            }
            Console.ReadKey();
        }
    }
}
