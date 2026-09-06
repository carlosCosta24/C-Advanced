using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Swapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Using swapper method to swap two int
            int X = 10;
            int Y = 25;
            Console.WriteLine($"X and Y befor swap: X: {X}, Y: {Y}");
            clsUtility.Swapper(ref X, ref Y);
            Console.WriteLine($"X and Y after swap: X: {X}, Y: {Y}");

            //using swapper method on strings 
            string FirstName = "Carlos";
            string SecondName = "Costa";
            Console.WriteLine($"FirstName and SecondName befor swap: FirstName: {FirstName}, SecondName: {SecondName}");
            clsUtility.Swapper(ref FirstName, ref SecondName);
            Console.WriteLine($"FirstName and SecondName after swap: FirstName: {FirstName}, SecondName: {SecondName}");

            //Using Generic class on int
            clsGeneric.Box<int> Int= new clsGeneric.Box<int>(10);
            Console.WriteLine($"Using generic class with int:");
            Int.Print();

            //Using Generic class on string
            clsGeneric.Box<string> String = new clsGeneric.Box<string>("Carlos Costa");
            Console.WriteLine($"Using generic class with string:");
            String.Print();

            Console.ReadKey();




        }
    }
}
