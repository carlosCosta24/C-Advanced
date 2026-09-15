using System;
using System.Threading.Tasks;

namespace Asynchronous_Programming
{
    internal class Program
    {
        static async Task Main()
        {
            Task<int> CalculationResult = PerformCalculationAsync();
            Console.WriteLine("Calculation started>>>");

            int FinalResult = await CalculationResult;

            Console.WriteLine("Calculation finished>>");
            Console.WriteLine(FinalResult);
            Console.ReadKey();
        }
        static async Task<int> PerformCalculationAsync()
        {
            int Result = 0;
            for (int i = 0; i < 500; i++)
            {
                Result += i;
            }
            await Task.Delay(500);
            return Result;
        }
    }
}
