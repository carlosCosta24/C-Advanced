using System;
using System.Text;
using System.Diagnostics;


namespace StringBuilder
{
    internal class Program
    {
        static void StringConcatenation(int Iteration)
        {
            string Sentance = "";
            for (int i = 0; i < Iteration; i++)
            {
                Sentance += (char)i;
            }

        }
        static void StringConcatenationUsingStringBuilder(int Iteration) 
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < Iteration; i++)
            {
                sb.Append((char)i);
            }
            string Result = sb.ToString();
        }
        static void Main(string[] args) 
        {

            int Iterations = 50000;

            Stopwatch FirstStopWatch = new Stopwatch();
            FirstStopWatch.Start();
            StringConcatenation(Iterations);
            FirstStopWatch.Stop();

            Console.WriteLine($"Normal string concatenation time: {FirstStopWatch.ElapsedMilliseconds}ms");

            Stopwatch SecondStopWatch = new Stopwatch();
            SecondStopWatch.Start();
            StringConcatenationUsingStringBuilder(Iterations);
            SecondStopWatch.Stop();

            Console.WriteLine($"String Builder concatenation time: {SecondStopWatch.ElapsedMilliseconds}ms");

            Console.ReadKey();


        }






    }
}
