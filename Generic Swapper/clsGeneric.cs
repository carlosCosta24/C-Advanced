using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Swapper
{
    public class clsGeneric
    {
        public class Box<T> 
        {
            private T Content;

            public Box(T content)
            {
                Content = content;
            }
            public void Print() 
            {
                Console.WriteLine(this.Content);
            }
        }
    }
}
