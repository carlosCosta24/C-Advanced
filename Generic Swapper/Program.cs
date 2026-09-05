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


            Console.ReadKey();




        }
    }
}
