using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ConsoleApp1
{
    public class clsWriteToRegistry
    {
        string Path { get; set; }
        string Value { get; set; }
        string Data { get; set; }


        public clsWriteToRegistry(string FilePath, string Value, string Data) 
        {
            this.Path = FilePath;
            this.Value = Value;
            this.Data = Data;
        }

        public void AddNewRegistry() 
        {
            try
            {
                Registry.SetValue(this.Path, this.Value, this.Data);
                Console.WriteLine($"Data saved successfully: Value:{Value}, Data:{Data}");
                Console.ReadKey();
            }
            catch (Exception Error)
            {
                Console.WriteLine($"Error while saving to the registry: {Error.Message}");
                Console.ReadKey();

            }

        }
    }
}
