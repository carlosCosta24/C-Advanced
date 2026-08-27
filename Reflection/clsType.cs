using System;


namespace Reflection
{
    public class clsType
    {
        public static void PrintStringType() {
            Type StringType = typeof(string);

            Console.Write ("Type Info: ");
            Console.WriteLine($"Name: {StringType.Name}");
            Console.WriteLine($"Full Name: {StringType.FullName}");
            Console.WriteLine($"Is Class: {StringType.IsClass}");

            Console.ReadLine();
        }

    }
}
