using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Factory_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // cancellation Tokon
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            //create and config for task factory
            TaskFactory factory = new TaskFactory
            (
            token,
            TaskCreationOptions.AttachedToParent,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default
            );

            Task t1 = factory.StartNew(() =>
            {
                int Sum = 0;
                for (int i = 0; i < 100000; i++)
                {
                    Sum += i;
                }
                Console.WriteLine($"Sum from 1 to 99999 is : {Sum}");
            });

            Task t2 = factory.StartNew(() =>
            {
                int Factorial = 1;
                for (int i = 10; i > 1; i--)
                {
                   Factorial  *= i ;
                }
                Console.WriteLine($"Factorial 10 is : {Factorial}");
            });

            try
            {
                Task.WaitAll(t1, t2);
                Console.WriteLine("All function was excuted successfully :-)");
            }
            catch (AggregateException AE) 
            {
                foreach (var E in AE.InnerExceptions) 
                {
                    Console.WriteLine($"Erorr: {E.Message}");
                }
            }
            cts.Dispose();
            Console.ReadKey();
        }
    }
}
