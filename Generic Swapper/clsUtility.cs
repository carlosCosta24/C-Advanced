using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Swapper
{
    public class clsUtility
    {
    /// <summary>
    /// Generic method to swap to variables
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="First"></param>
    /// <param name="Second"></param>
    /// <returns>First as second && second as first</returns>
        public static T Swapper<T>(ref T First, ref T Second) 
        {
            T Temp = First;
            First = Second;
            Second = Temp;
            return Temp;
        }
    }
}
