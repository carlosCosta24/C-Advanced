using System;
using System.Reflection;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class clsCustomAttribute : Attribute
    {
        public string Description { get; }


        public clsCustomAttribute(string Description)
        {

            this.Description = Description;
        }
    }
    [clsCustom("Program Doucumntaion")]
    class clsDocumintation
    {
        [clsCustom("Adding Method With 2 Parameters")]
        public int Add(int X, int Y)
        {
            return X + Y;
        }
        [clsCustom("Printing Add Method Result")]
        public void Printer()
        {
            Console.WriteLine($"{Add(10, 20)}");
        }
    }
    class clsExcute
    {
        public static void Run()
        {
            Type type = typeof(clsDocumintation);

            object[] classAttributess = type.GetCustomAttributes(typeof(clsCustomAttribute), false);
            foreach (clsCustomAttribute attribute in classAttributess)
            {
                Console.WriteLine($"Class Attribute: {attribute.Description}");

            }
            MethodInfo Add = type.GetMethod("Add");
            object[] AddInfo = Add.GetCustomAttributes(typeof(clsCustomAttribute), false);
            foreach (clsCustomAttribute attribute in AddInfo)
            {
                Console.WriteLine($"Add Method: {attribute.Description}");

            }
            Console.ReadKey();
        }



    }


}
