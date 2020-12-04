using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1142
{
    class C : B
    {
        

        public override void M()
        {
            Console.WriteLine("C.M()");
        }
    }


    class D : C
    {
        public override void M()
        {
            Console.WriteLine("D.M()");
        }
    }
}
