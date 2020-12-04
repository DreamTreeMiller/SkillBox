using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1521
{
    public static class Class
    {
        public static void Method()
        {
            Console.Write("Data: ");
            if (Console.ReadLine() == "error" ) throw new DataException();
            
        }

    }
}
