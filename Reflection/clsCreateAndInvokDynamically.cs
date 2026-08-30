using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class clsCreateAndInvokDynamically
    {
        class Object
        {
            public int ID { get; set; } 
            public string Name { get; set; }

            public void PrintID()
            {
                Console.WriteLine($"Object ID: {this.ID}");

            }
            public void PrintDetails(string Name, int ID)
            {
                Console.WriteLine($"Object Properties: Name:{this.Name}, ID:{this.ID}");
            }
        }
        static string GetPrametersList(ParameterInfo [] Prameters)
        {
            return string.Join(", ", Prameters.Select(Parameter => $"Paramete Name: {Parameter.Name}, Parameter Type: {Parameter.ParameterType}"));
        }
        public static void CreateAndInvoke() 
        {
            Type ObjectDetails = typeof( Object );

            Console.WriteLine($"ObjectName: {ObjectDetails.FullName}\n");
            Console.WriteLine($"ObjectName: {ObjectDetails.Name}\n");


            Console.WriteLine("Printing all Object Propereties.....\n");

            foreach (var Property in ObjectDetails.GetProperties()) 
            {
                Console.WriteLine($"Property: {ObjectDetails.GetProperties()}, Type: {ObjectDetails.GetType()}");
            }


            foreach (var Method in ObjectDetails.GetMethods())
            {
                Console.WriteLine($"Method Type: {Method.ReturnType}, Parameters: {GetPrametersList(Method.GetParameters())}");
            }

            Console.WriteLine("Setting Object ID...");

            //createing an istanse from Object 
            object InstansOfObjectDetails = Activator.CreateInstance(ObjectDetails);

            ObjectDetails.GetProperty("ID").SetValue(InstansOfObjectDetails, 1);

            Console.WriteLine("Setting Object Name...");

            ObjectDetails.GetProperty("Name").SetValue(InstansOfObjectDetails, "Carlos");

            Console.WriteLine("Printing ID and Name: ");
            string Name = (string)ObjectDetails.GetProperty("Name").GetValue(InstansOfObjectDetails);
            Console.WriteLine(Name);

            int ID = (int)ObjectDetails.GetProperty("ID").GetValue(InstansOfObjectDetails);
            Console.WriteLine(ID);

            Console.WriteLine("Invoking PrintDetails Method: ");

            object[] InvokeParameters = { "Carlos", 101 };
            ObjectDetails.GetMethod("PrintDetails").Invoke(InstansOfObjectDetails, InvokeParameters);

            Console.ReadKey();

        }
    }
}
