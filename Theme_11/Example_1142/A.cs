using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1142
{
    class A
    {
        public virtual void M()
        {
            Console.WriteLine("A.M()");
        }
    }


    class B : A
    {
        public override void M()
        {
            Console.WriteLine("B.M()");
        }
    }

}
