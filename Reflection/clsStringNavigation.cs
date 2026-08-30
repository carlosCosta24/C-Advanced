using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    public class clsStringNavigation
    {

        public static void NavigateStringLibirary()
        {
            Assembly StringAssembly = typeof(string).Assembly;

            Type StringType = StringAssembly.GetType("System.String");

            if (StringType != null)
            {
                Console.WriteLine("Method of String class: \n");

                var Methods = StringType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

                foreach (var Method in Methods)
                {
                    Console.WriteLine(
                    "--------------------------------\n" +
                    $"MethodName: {Method.Name}," +
                    $"\n MethodParameter: " +
                    $"{GetPrameters(Method.GetParameters())}"
                    );
                }
            }
            else
            {
                Console.WriteLine("Libirary doesnt exist");
            }
            Console.ReadKey();
        }
        private static string GetPrameters(ParameterInfo[] Parameters)
        {
            return string.Join(", ", Parameters.Select(Prameter => $"({Prameter.ParameterType} {Prameter.Name})\n"));
        }
    }
}


