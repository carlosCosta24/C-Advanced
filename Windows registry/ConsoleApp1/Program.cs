using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            clsWriteToRegistry AddNewRegistry = new clsWriteToRegistry(@"HKEY_CURRENT_USER\SOFTWARE\HIDDEN","PraivateKey", "CARLOS COSTA");
            AddNewRegistry.AddNewRegistry();
        }
    }
}
