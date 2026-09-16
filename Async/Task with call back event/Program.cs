using System;
using System.Threading.Tasks;

namespace Task_with_call_back_event
{
    public class MyCustomArg : EventArgs
    {
        public int Age { set; get; }
        public string Name { set; get; }

        public MyCustomArg(int Age, string Name)
        {
            this.Age = Age;
            this.Name = Name;
        }
    }
    internal class Program
    {
        public delegate void CallBackHandeler(object sender, MyCustomArg e);
        public static event CallBackHandeler CallBackEvent;
        static async Task Main()
        {
            CallBackEvent += OnCallBack;

            Task PerformTask = PerformTaskAsync(CallBackEvent);

            Console.WriteLine("Running Program....");

            await PerformTask;

            Console.WriteLine("Done:-)");
            Console.ReadKey();
        }
        static async Task PerformTaskAsync(CallBackHandeler CallFunction)
        {
            await Task.Delay(500);

            MyCustomArg EventArg = new MyCustomArg(28, "Carlos");

            CallFunction?.Invoke(null, EventArg);
        }
        static void OnCallBack(object sender, MyCustomArg e)
        {
            Console.WriteLine($"Function call from event, Name: {e.Name}, Age: {e.Age}");
        }
    }
}
