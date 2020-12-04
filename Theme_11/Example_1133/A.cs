using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1133
{
    class  A
    {
        public void M()
        {
            Console.WriteLine("A.M()");
        }
    }


    class B : A
    {
        public new void M()
        {
            Console.WriteLine("B.M()");
        }

    }

}
