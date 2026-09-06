using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ConsoleApp1
{
    public class clsAccessRegistry
    {
        string Path { get; set; }
        string Value { get; set; }
        string Data { get; set; }


        public clsAccessRegistry(string FilePath, string Value, string Data) 
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
               
            }
            catch (Exception Error)
            {
                Console.WriteLine($"Error while saving to the registry: {Error.Message}");

            }
                Console.ReadKey();

        }
        public void ReadRegistry()
        {
            try
            {

                string Data = Registry.GetValue(this.Path, this.Value, null) as string;
                if (Data != null)
                {
                    Console.WriteLine($"Successfully accessed,Value: {Value}, Data: {Data} ");
                }
                else
                {
                    Console.WriteLine($"Faild to accessed,Value: {Value}, Data: null ");

                }
             

            }
            catch (Exception Error) 
            {
                    Console.WriteLine($"Error: {Error.Message}");

            }
                    Console.ReadKey();

        }
        public static void DeleteKey(string Path, string Key )
        {
            
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey SubKey = baseKey.OpenSubKey(Path, true))
                    {
                        if (SubKey != null)
                        {
                            
                            SubKey.DeleteValue(Key);
                            Console.WriteLine($"Value {Key} was deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Value doesn't exist.");

                        }
                    }
                }
            }
            catch (UnauthorizedAccessException) 
            {
                Console.WriteLine("Unauthorized Access Exception!");
            }catch(Exception Errro)
            {
                Console.WriteLine($"Error: {Errro.Message}");
            }
            Console.ReadKey();
        }
        public void PrintProperties()
        {
            Console.WriteLine($"{this.Path}, {this.Value}, {this.Data}");

        }

    }
}
