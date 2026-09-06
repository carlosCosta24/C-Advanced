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
            
            clsAccessRegistry NewRegistry = new clsAccessRegistry(@"HKEY_CURRENT_USER\SOFTWARE\HIDDEN","PraivateKe", "CARLOS COSTA");
            //NewRegistry.AddNewRegistry();
            NewRegistry.ReadRegistry();

        }
    }
}
