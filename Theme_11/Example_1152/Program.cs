using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1152
{

    abstract class A
    {
        public abstract void M();
    }

    class B : A
    {
        public override void M()
        {
            Console.WriteLine("public override void M()");  
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            B b = new B(); b.M();
            A a = new B(); a.M();
        }
    }
}
