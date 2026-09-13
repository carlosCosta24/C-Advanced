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
            //Prameterless thread
            Thread FirstThread = new Thread(NewThread);

            FirstThread.Start();
            //Parameterized Thread

            for (int i = 0; i < 100; i++) 
            {
                if (i % 10 == 0) 
                {
                    Console.WriteLine($"i:{i}");
                    Thread.Sleep(1000);
                }
            }

            Thread SecondThread = new Thread(() => Print("Costa"));
            SecondThread.Start();

            void NewThread() 
            {
                for(int i = 0; i < 10; i ++)
                { 
                    Console.WriteLine("Carlos");
                    Thread.Sleep(500);
                }
            }
            
            void Print(string s) 
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
