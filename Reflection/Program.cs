using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //clsType.PrintStringType();
            //clsStringNavigation.NavigateStringLibrary();
            //clsCreateAndInvokDynamically.CreateAndInvoke();
            //clsExcute.Run();
            clsValidation.Person NewPerson = new clsValidation.Person(100, "Carlos Costa");
            clsValidation.clsChecker.CheckPersonAge(NewPerson);

        }
    }
}
