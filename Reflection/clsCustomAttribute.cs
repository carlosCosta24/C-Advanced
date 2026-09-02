using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class clsCustomAttribute:Attribute
    {
        public string Description { get; set; }


        public clsCustomAttribute(string Description)
        {

            Description = this.Description;
        }
    }
    [clsCustom("Program Doucumntaion")]
    public class clsDocumintation 
    {
        [clsCustom("Adding Method With 2 Parameters")]
        public static int Add(int X, int Y) 
        {
            return X + Y;
        }
        [clsCustom("Printing Add Method Result")]
        public static void Printer()
        {
            Console.WriteLine($"{Add(10, 20)}");
        }
    }

}
